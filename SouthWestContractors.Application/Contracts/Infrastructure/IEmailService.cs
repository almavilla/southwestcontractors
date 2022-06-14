using SouthWestContractors.Application.Models.Mail;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
