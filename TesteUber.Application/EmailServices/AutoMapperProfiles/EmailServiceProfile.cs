using AutoMapper;
using TesteUber.Application.EmailServices.Commands;
using TesteUber.Core.Emails.Model;

namespace TesteUber.Application.EmailServices.AutoMapperProfiles
{
    public class EmailServiceProfile : Profile
    {
        public EmailServiceProfile()
        {
            CreateMap<EmailCommand, Email>();
        }
    }
}
