using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorClient.Data
{
    public class GreeterService
    {
        public async Task<string> SayHello(string name)
        {
            AppContext.SetSwitch(
               "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
               true);

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50051");

            var client = GrpcClient.Create<grpcGreeter.Greeter.GreeterClient>(httpClient);
            grpcGreeter.HelloReply reply = await client.SayHelloAsync(new grpcGreeter.HelloRequest() { Name = name });
            return reply.Message;
        }
    }
}
