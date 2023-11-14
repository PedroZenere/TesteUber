using TesteUber.Core.Emails.Model;

namespace TesteUber.Infra.EmailGateway.AmazonMailService.Interfaces
{
    public interface IMailGateway
    {
        public Task SendEmail(Email email);
    }
}
