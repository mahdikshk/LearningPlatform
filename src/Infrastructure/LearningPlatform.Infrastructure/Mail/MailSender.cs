using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Infrastructure.Mail;
using LearningPlatform.Application.Models;

namespace LearningPlatform.Infrastructure.Mail;
internal class MailSender : IEmailSender
{
    public Task SendEmailAsync(Email email)
    {
        throw new NotImplementedException();
    }
}
