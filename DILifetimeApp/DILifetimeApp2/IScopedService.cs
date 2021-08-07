using System;

namespace DILifetimeApp2
{
    public  interface IScopedService
    {
        Guid GetOperationID();
    }
}