using System;
using System.Collections.Generic;
using System.Text;

namespace IoCAppSL
{
    class ServiceLocator
    {
        public void Demonstarte()
        {
            var client = new Client();
            client.Start();
        }
    }


    public interface IService
    {
        void Serve();
    }

    public class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service Called");
            Console.WriteLine("Service Service.Serve is doing stuff");
            //To Do: Some Stuff
        }
    }

    public static class LocateService
    {
        public static IService _Service { get; set; }

        public static IService GetService()
        {
            if (_Service == null)
                _Service = new Service();

            return _Service;
        }
    }

    public class Client
    {
        private IService _service;

        public Client()
        {
            this._service = LocateService.GetService();
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
