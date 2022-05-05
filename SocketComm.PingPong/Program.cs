// See https://aka.ms/new-console-template for more information
using SocketComm;
using static SocketComm.Cmd;
if (args.Length < 1)
{
    return;
}
FPipe p = new FPipe(args[0]);
await p.ReadCmdAsync();
await p.WriteCmdAsync(Cmd.Error);
await foreach (var cmd in p)
{
    Console.WriteLine($"Received: {cmd}");
    Console.Write($"Replying [{cmd}]..");
    await p.WriteCmdAsync(cmd);
    Console.WriteLine(".OK");
}
//for(int i = 0; i < 10; i++)
//{
//    Console.WriteLine("Awaiting Go");
//    if (Go == await p.ReadCmdAsync())
//    {
//        Console.WriteLine("Received: Go");
//    }
//    else throw new InvalidOperationException("Unexpected [Go]");

//    Console.WriteLine("Sending Done");
//    await p.WriteCmdAsync(Done);
//    Console.WriteLine("Sent: Done");
//}