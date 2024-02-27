using TesteUber.Core.Emails.Model;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces
{
    public interface IMailGateway
    {
        public Task SendEmail(Email email);
    }
}
