using System.Linq.Expressions;
using UsersManager.Models.Entities;

namespace UsersManager.Services.Interfaces
{
    public interface IUserService
    {
        List<TagToUser?> GetAllUsers(Expression<Func<TagToUser, bool>>? filter = null,
                                        string? includeProperties = null, int pageSize = 0,
                                        int pageNumber = 1);
        User? GetUser(Expression<Func<User, bool>> filter);
        List<Tag?> GetUserTags(string userId);
    }
}