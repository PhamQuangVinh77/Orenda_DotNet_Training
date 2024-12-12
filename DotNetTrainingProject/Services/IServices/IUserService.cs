using DotNetTrainingProject.Models.Requests;

namespace DotNetTrainingProject.Services.IServices
{
    public interface IUserService
    {
        Task<bool> Register(RequestForRegister request);
        Task<string> Login(RequestForLogin request);
    }
}
