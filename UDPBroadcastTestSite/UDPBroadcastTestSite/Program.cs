using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace UDPBroadcastTestSite {
    internal class Program{
        private static string testSiteName;
        private static int nextId = 1;
        static void Main(string[] args) {
            Console.WriteLine("UDP Broadcast Started");

            Random rand = new Random();

            using (UdpClient socket = new UdpClient()){
                while (true){
                    TestSite testData = new TestSite(){Id=nextId++, Name = "Copenhagen", WaitingTime = rand.Next(0, 45)};

                    string serializedData = JsonSerializer.Serialize(testData);

                    byte[] data = Encoding.UTF8.GetBytes(serializedData);

                    socket.Send(data, data.Length, "255.255.255.255", 10100);

                    Console.WriteLine("Send JSON: " + serializedData);

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
