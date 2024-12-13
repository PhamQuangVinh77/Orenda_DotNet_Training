using DotNetTrainingProject.MailUtilities;

namespace DotNetTrainingProject.Services.IServices
{
    public interface ISendMailService
    {
        Task<bool> SendMail(string userName);
    }
}
