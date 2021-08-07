using System;

namespace DILifetimeApp2
{
    public interface ITransientService
    {
        Guid GetOperationID();
    }
}