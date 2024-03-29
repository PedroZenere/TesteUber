﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon.SimpleEmail;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServiceAmazonSES(this IServiceCollection services, IConfiguration cfg)
        {
            ConfigureKeysAWS(cfg);
            services.AddDefaultAWSOptions(cfg.GetAWSOptions());
            services.AddAWSService<IAmazonSimpleEmailService>();
        }

        static void ConfigureKeysAWS(IConfiguration configuration)
        {
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", configuration["AWS:AWS_ACCESS_KEY_ID"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", configuration["AWS:AWS_SECRET_ACCESS_KEY"]);
        }
    }
}
