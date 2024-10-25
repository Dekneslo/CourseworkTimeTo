using Domain.Contracts.UserContracts;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfileService
    {
        Task<UserProfileResponse> GetProfileByUserIdAsync(int userId);
        Task<ServiceResult> CreateOrUpdateProfileAsync(int userId, UpdateProfileRequest request);
        Task<ServiceResult> ChangeUserLanguageAsync(int userId, string languageCode);
    }
}
