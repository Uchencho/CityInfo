using System;
namespace CityInfo.API.Services
{
	public class CloudMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Sending mail from {_mailFrom} to address: {_mailTo} with {nameof(CloudMailService)}");
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"message: {message}");
        }
    }
}

