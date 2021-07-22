using System;
using System.Collections.Generic;
using System.Text;

namespace IoCAppDI
{
    class IoCDI
    {
        public void Demonstarte()
        {
            var client = new Client(new Service());
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

    public class Client
    {
        private IService _service;

        public Client(IService service)
        {
            this._service = service;
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
