using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Models;

namespace LearningPlatform.Application.Contracts.Infrastructure.Mail;
public interface IEmailSender
{
    Task SendEmailAsync(Email email);
}
