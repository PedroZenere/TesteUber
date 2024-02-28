using System.Net;
using TesteUber.Core.Emails.Model;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces
{
    public interface IMailGateway
    {
        public Task<HttpStatusCode> SendEmail(Email email, CancellationToken cancellationToken);
    }
}
