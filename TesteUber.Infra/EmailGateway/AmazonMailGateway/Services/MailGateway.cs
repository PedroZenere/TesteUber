using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using TesteUber.Core.Emails.Model;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Services
{
    public class MailGateway : IMailGateway
    {
        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;

        public MailGateway(IAmazonSimpleEmailService service)
        {
            _amazonSimpleEmailService = service;
        }
        public async Task SendEmail(Email email, CancellationToken cToken)
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
                var response = await _amazonSimpleEmailService.SendEmailAsync(body, cToken) ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while send email", ex.InnerException);
            }
        }
    }
}
