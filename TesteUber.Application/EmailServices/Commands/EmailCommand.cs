using AutoMapper;
using MediatR;
using TesteUber.Core.Emails.Model;
using TesteUber.Infra.EmailGateway.AmazonMailService.Interfaces;

namespace TesteUber.Application.EmailServices.Commands
{
    public class EmailCommand : IRequest
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }

    public sealed class EmailCommandHandler : IRequestHandler<EmailCommand>
    {
        private readonly IMailGateway _mailGateway;
        private readonly IMapper _mapper;

        public EmailCommandHandler(IMailGateway mailGateway, IMapper mapper)
        {
            _mailGateway = mailGateway;
            _mapper = mapper;
        }

        public async Task Handle(EmailCommand request, CancellationToken cancellationToken)
        {
            var email = _mapper.Map<Email>(request);

            await _mailGateway.SendEmail(email);
        }
    }
}
