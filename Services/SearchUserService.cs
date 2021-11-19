using Core.DTOs;
using Core.Entities.User.Exceptions;
using Core.Extentions;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class SearchUserService : ISearchUserService
    {
        private readonly IUserRepo _userRepo;

        public SearchUserService(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        public async ValueTask<List<UserDto>> SearchUser(string queryToSearch)
        {
            var cleanQueryToSearch = queryToSearch.RemoveEspecialCharacters();
            var maybeUsers = await this._userRepo.GetAll()
                .Where(x => EF.Functions.Like(x.Fullname, $"%{cleanQueryToSearch}%")
                         || EF.Functions.Like(x.Username, $"%{cleanQueryToSearch}%"))
                .OrderBy(x => x.Fullname).ThenBy(x => x.Username)
                .Select(x => new UserDto(x))
                .ToListAsync();

            if (!maybeUsers.Any())
            {
                throw new UserNotFoundException();
            }

            return maybeUsers;
        }
    }
}
