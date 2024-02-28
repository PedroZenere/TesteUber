using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using TesteUber.Core.Emails.Model;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces;
using System.Net;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Services
{
    public class MailGateway : IMailGateway
    {
        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;

        public MailGateway(IAmazonSimpleEmailService service)
        {
            _amazonSimpleEmailService = service;
        }
        public async Task<HttpStatusCode> SendEmail(Email email, CancellationToken cToken)
        {
            var body = new SendEmailRequest
            {
                Destination = new Destination
                {
                    ToAddresses = new List<string>() { email.to }
                },
                Message = new Message
                {
                    Body = new Body
                    {
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = email.body
                        }
                    },
                    Subject = new Content
                    {
                        Charset = "UTF-8",
                        Data = email.subject
                    }
                },
                Source = "pedrinhozenere99@gmail.com"
            };
            try
            {
                var response = await _amazonSimpleEmailService.SendEmailAsync(body, cToken);

                return response.HttpStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
