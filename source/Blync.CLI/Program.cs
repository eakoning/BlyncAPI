using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blync.CLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BlyncTester tester = new BlyncTester();

            tester.Start().Wait();
        }
    }

    public class BlyncTester
    {
        private const string apiBaseUrl = "http://localhost:42987/api";
        private readonly HttpClient _client;

        public BlyncTester()
        {
            _client = new HttpClient();
        }

        public async Task Start()
        {
            for (int i = 0; i < 10; i++)
            {
                await TurnOn();
                Thread.Sleep(1000);
                await TurnOff();
                Thread.Sleep(1000);
            }
        }

        public async Task TurnOn()
        {
            string requestUri = $"{apiBaseUrl}/Blync/On/0/255/255/255";
            await _client.PostAsync(requestUri, null);
        }

        public async Task TurnOff()
        {
            string requestUri = $"{apiBaseUrl}/Blync/On/0/0/0/0";
            await _client.PostAsync(requestUri, null);
        }
    }
}