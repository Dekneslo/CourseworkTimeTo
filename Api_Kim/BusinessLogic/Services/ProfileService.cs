using Domain.Interfaces;
using Domain.Results;
using Domain.Models;
using Domain.Contracts.UserContracts;
using Domain.Wrapper;
using Mapster;

namespace BusinessLogic.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProfileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<UserProfileResponse> GetProfileByUserIdAsync(int userId)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(userId);
            if (user == null) return null;

            return user.Adapt<UserProfileResponse>();
        }

        public async Task<ServiceResult> CreateOrUpdateProfileAsync(int userId, UpdateProfileRequest request)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(userId);
            if (user == null)
            {
                return ServiceResult.ErrorResult("Пользователь не найден");
            }

            request.Adapt(user);
            await _repositoryWrapper.User.UpdateAsync(user);
            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Профиль успешно обновлен", user);
        }

        public async Task<ServiceResult> ChangeUserLanguageAsync(int userId, string languageCode)
        {
            var user = await _repositoryWrapper.User.GetByIdAsync(userId);
            if (user == null)
            {
                return ServiceResult.ErrorResult("Пользователь не найден");
            }

            var userLanguage = await _repositoryWrapper.UserLanguage.GetByUserIdAsync(userId);

            if (userLanguage == null)
            {
                // Если язык для пользователя еще не настроен, создаем запись
                userLanguage = new UserLanguage
                {
                    IdUser = userId,
                    Language = languageCode
                };

                await _repositoryWrapper.UserLanguage.CreateAsync(userLanguage);
            }
            else
            {
                // Если уже существует, обновляем язык
                userLanguage.Language = languageCode;
                await _repositoryWrapper.UserLanguage.UpdateAsync(userLanguage);
            }

            await _repositoryWrapper.SaveAsync();

            return ServiceResult.SuccessResult("Язык пользователя успешно изменен");
        }

    }
}
