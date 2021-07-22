using System;
using System.Collections.Generic;
using System.Text;

namespace IoCAppNW
{
    public class NormalWay
    {
        public void Demonstarte()
        {
            var client = new Client();
            client.Start();
        } 
    }

    public class Service
    {
        public void Serve()
        {
            Console.WriteLine("Service Called");

            Console.WriteLine("Service Service.Serve is doing stuff");
        }
    }
    public class Client
    {
        private Service _service;

        public Client()
        {
            this._service = new Service();
        }

        public void Start()
        {
            Console.WriteLine("Service Started");
            this._service.Serve();

            Console.WriteLine("Client.Start is doing stuff");
            //To Do: Some Stuff
        }
    }
}
