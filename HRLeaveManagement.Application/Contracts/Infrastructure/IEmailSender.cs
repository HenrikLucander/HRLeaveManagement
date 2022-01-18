using HRLeaveManagement.Application.Models;

namespace HRLeaveManagement.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
