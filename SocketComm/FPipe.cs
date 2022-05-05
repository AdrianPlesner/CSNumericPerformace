using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketComm;

using static Cmd;

public class FPipe : IDisposable, IAsyncDisposable, IEnumerable<Cmd>, IAsyncEnumerable<Cmd>
{
    public ILogger<FPipe> L { get; }
    Socket s;

    public FPipe(string file, ILogger<FPipe> logger = default)
    {

        this.L = logger ?? (LoggerFactory.Create(b => {
            b.AddConsole();
        }).CreateLogger<FPipe>());
        L.LogInformation("Creating socket endpoint");
        UnixDomainSocketEndPoint ep = new UnixDomainSocketEndPoint(file);
        L.LogInformation("Creating socket");
        if (File.Exists(file))
        {
            s = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
            L.LogInformation("Connecting...");
            s.Connect(ep);
            ShakeHands(s);
        }
        else
        {
            Socket FileSocket;
            L.LogInformation("Serving...");
            FileSocket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
            FileSocket.Bind(ep);
            FileSocket.Listen();
            L.LogInformation("Listening");
            s = FileSocket.Accept();
            FileSocket.Disconnect(false);
            FileSocket.Dispose();
        }
        L.LogInformation("Connected..");
        

    }
    const Int32 MagicHandshakeValue = 25;

    public async Task ShakeHandsAsync(Socket socket)
    {
        var data = BitConverter.GetBytes(MagicHandshakeValue);
        await socket.SendAsync(data, SocketFlags.None);
        await socket.ReceiveAsync(data, SocketFlags.None);
        ValidateHandshake(data);
    }

    void ValidateHandshake(byte[] data)
    {
        Int32 result = BitConverter.ToInt32(data);
        //L.LogInformation($"[{nameof(ShakeHands)}]: {MagicHandshakeValue}/{result}");
        byte[] rev = new byte[data.Length ];
        Array.Copy(data, rev, rev.Length);
        Array.Reverse(rev);
        if(result == MagicHandshakeValue)
        {
            L.LogInformation($"Handshake OK {MagicHandshakeValue}/{result}");
            return;
        }

        int revResult = BitConverter.ToInt32(rev);
        if (revResult == MagicHandshakeValue)
        {
            L.LogError($"Other side uses {(BitConverter.IsLittleEndian ? "BigEndian" : "LittleEndian")} -- {MagicHandshakeValue}/{result}");
            return;
        }
        throw new InvalidDataException("Bad handshake..." + result);
    }

    public void ShakeHands(Socket socket)
    {
        Int32 n = 25;
        Int32 result;
        var data = BitConverter.GetBytes(n);
        socket.Send(data, SocketFlags.None);
        socket.Receive(data, SocketFlags.None);
        ValidateHandshake(data);
    }

    public void ReceiveHandshake(Socket socket)
    {
        byte[] data=new byte[4];
        Int32 n = 25;
        Int32 result;
        socket.Receive(data, SocketFlags.None);
        result = BitConverter.ToInt32(data);
        socket.Send(data);
        ValidateHandshake(data);
    }

    Cmd cmd(byte[] buffer)
    {
        sbyte result = (sbyte)buffer[0];
        return (Cmd)result;
    }
    public async Task<Cmd> ReadCmdAsync(CancellationToken ct = default)
    {
        try
        {
            var buffer = new byte[1];
            var count = await s.ReceiveAsync(buffer, SocketFlags.None, ct);
            return cmd(buffer);
        }
        catch(Exception e) {
            L.LogError(e.Message);
            return Error; 
        }
    }
    public async Task<bool> WriteCmdAsync(Cmd cmd, CancellationToken cancellationToken = default)
    {
        try
        {
            L.LogTrace($"Sending {cmd}");
            var data = bytes(cmd);
            L.LogTrace($"data: {Convert.ToHexString(data)}");
            var sent = await s.SendAsync(data, SocketFlags.None, cancellationToken);
            L.LogTrace($"Sent: {sent}");
            return true;
        }
        catch(Exception ex)
        {
            L.LogError(ex.Message);
            return false;
        }
    }

    byte[] bytes(Cmd c) {
        var b = new byte[] { (byte)c };
        L.LogTrace($"{nameof(bytes)}: {c} ==> {Convert.ToHexString(b)} ({b.Length}b)");
        return b;
    }

    public Cmd ReadCmd()
    {
        try
        {
            byte[] buffer = new byte[1];
            s.Receive(buffer);
            return cmd(buffer);
        }
        catch (Exception e)
        {
            L.LogError(e.Message);
            return Error;
        }
    }
    public bool WriteCmd(Cmd cmd)
    {
        try
        {
            s.Send(bytes(cmd));
            return true;
        }
        catch (Exception e){
            L.LogError(e.Message);
            return false;
        }
    }

    public void Dispose()
    {
        s?.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        s?.Dispose();
        return ValueTask.CompletedTask;
    }

    public IEnumerator<Cmd> GetEnumerator()
    {
        Cmd r;
        do
        {
            r = ReadCmd();
            yield return r; 
        } while (r > Exit); 
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public async IAsyncEnumerator<Cmd> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        Cmd r;
        do
        {
            r = await ReadCmdAsync(cancellationToken);
            yield return r;
        } while(r > Exit);
    }
}
