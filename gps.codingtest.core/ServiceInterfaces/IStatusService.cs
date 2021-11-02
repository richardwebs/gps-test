using System;

namespace gps.codingtest.core.ServiceInterfaces
{
    public interface IStatusService
    {
        void SetStatus(Guid id, string status);
        string GetStatus(Guid id);
    }
}
