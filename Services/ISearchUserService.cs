using Core.DTOs;

namespace Services
{
    public interface ISearchUserService
    {
        ValueTask<List<UserDto>> SearchUser(string queryToSearch);
    }
}