namespace gps.codingtest.core.ServiceInterfaces
{
    public interface ISmsService
    {
        bool IsServiceRunning();
        bool Send(string to, string from, string message);
    }
}
