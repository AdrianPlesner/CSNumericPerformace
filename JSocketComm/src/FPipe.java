import jdk.jshell.spi.ExecutionControl;

import java.io.File;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.StandardProtocolFamily;
import java.net.UnixDomainSocketAddress;
import java.nio.ByteBuffer;
import java.nio.IntBuffer;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;
import java.nio.file.Files;
import java.nio.file.Path;

public class FPipe {
    final int MagicHandshakeValue = 25;
    SocketChannel channel;

    public FPipe(String file) throws IOException {
        UnixDomainSocketAddress address = UnixDomainSocketAddress.of(file);
        if (Files.exists(Path.of(file)))
        {
            channel = SocketChannel.open(StandardProtocolFamily.UNIX);
            channel.connect(address);
            ShakeHands(channel);
        } else{
            ServerSocketChannel ss = ServerSocketChannel.open(StandardProtocolFamily.UNIX);
            ss.bind(address);
            channel = ss.accept();
            ss.close();
            ReceiveHand(channel);
        }
    }

    public Cmd ReadCmd() throws IOException{
        ByteBuffer bb = ByteBuffer.allocate(1);
        channel.read(bb);
        bb.rewind();
        return Cmd.forValue(bb.get(0));
    }

    public void WriteCmd(Cmd cmd) throws IOException, ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("WriteCmd not implemented");
    }

    public void ShakeHands(SocketChannel channel) throws IOException
    {
        ByteBuffer bb = ByteBuffer.allocate(4);
        bb.putInt(MagicHandshakeValue);
        bb.rewind();
        channel.write(bb);
        bb.rewind();
        channel.read(bb);
        bb.rewind();
        int rec = bb.getInt();
        System.out.println("chk: received:"+rec+", expected: "+MagicHandshakeValue);
    }

    public void ReceiveHand(SocketChannel channel) throws IOException{
        ByteBuffer bb = ByteBuffer.allocate(4);
        channel.read(bb);
        int rec = bb.rewind().getInt();
        System.out.println("chk: received:"+rec+", expected: "+MagicHandshakeValue);
        bb.rewind().putInt(MagicHandshakeValue).rewind();
        channel.write(bb);
    }

}
