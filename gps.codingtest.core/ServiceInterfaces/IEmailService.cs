namespace gps.codingtest.core.ServiceInterfaces
{
    public interface IEmailService
    {
        bool IsServiceRunning();
        bool Send(string to, string from, string subject, string message);
    }
}
