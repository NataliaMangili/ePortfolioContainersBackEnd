namespace Identity.API.Ports;

public interface INotification
{
    //redirect = email
    Task<bool> SendAsync(string redirect, string subject, string body);
}
