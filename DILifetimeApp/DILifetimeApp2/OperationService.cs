using System;
namespace DILifetimeApp2
{
    public class OperationService : ITransientService,
    IScopedService,
    ISingletonService
    {
        Guid id;
        public OperationService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetOperationID()
        {
            return id;
        }
    }
}
