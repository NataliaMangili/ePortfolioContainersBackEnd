using Identity.API.Ports;
using MimeKit;
namespace MailKit;

public class SendEmailService : INotification
{
    private readonly SmtpSettings _smtpSettings;

    public SendEmailService(SmtpSettings smtpSettings) => _smtpSettings = smtpSettings;

    public async Task<bool> SendAsync(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = body
        };

        return true;
        //using (var client = new SmtpClient())
        //{
        //    await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
        //    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
        //    await client.SendAsync(message);
        //    await client.DisconnectAsync(true);
        //}
    }
}