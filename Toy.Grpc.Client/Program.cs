using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Toy.Grpc.Client
{
    // https://docs.microsoft.com/ko-kr/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-5.0&tabs=visual-studio

    // before to do
    //Install-Package Grpc.Net.Client
    //Install-Package Google.Protobuf
    //Install-Package Grpc.Tools

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
