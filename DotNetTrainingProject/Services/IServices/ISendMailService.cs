﻿using DotNetTrainingProject.MailUtilities;

namespace DotNetTrainingProject.Services.IServices
{
    public interface ISendMailService
    {
        Task<string> SendMail(string userName);
    }
}
