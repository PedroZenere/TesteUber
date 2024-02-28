using AutoMapper;
using MediatR;
using System.Net;
using TesteUber.Core.Emails.Model;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces;

namespace TesteUber.Application.EmailServices.Commands
{
    public class EmailCommand : IRequest<HttpStatusCode>
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }

    public sealed class EmailCommandHandler : IRequestHandler<EmailCommand, HttpStatusCode>
    {
        private readonly IMailGateway _mailGateway;
        private readonly IMapper _mapper;

        public EmailCommandHandler(IMailGateway mailGateway, IMapper mapper)
        {
            _mailGateway = mailGateway;
            _mapper = mapper;
        }

        public async Task<HttpStatusCode> Handle(EmailCommand request, CancellationToken cancellationToken)
        {
            var email = _mapper.Map<Email>(request);

            return await _mailGateway.SendEmail(email, cancellationToken);
        }
    }
}
