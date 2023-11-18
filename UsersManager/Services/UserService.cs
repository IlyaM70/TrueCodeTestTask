using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UsersManager.Data;
using UsersManager.Models.Entities;
using UsersManager.Services.Interfaces;

namespace UsersManager.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public User? GetUser(Expression<Func<User, bool>> filter)
        {
            return _db.Users.Where(filter).FirstOrDefault();
        }

        public List<Tag?> GetUserTags(string userId)
        {
            return _db.TagToUser
                .Include(x => x.Tag)
                .Where(x => x.UserId.ToString() == userId)
                .Select(x => x.Tag).ToList();
        }


        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="includeProperties">Properties inculed. Format: "Propery1,Property2..."</param>
        public List<TagToUser?> GetAllUsers(Expression<Func<TagToUser, bool>>? filter = null,
                                        string? includeProperties = null, int pageSize = 0,
                                        int pageNumber = 1)
        {

            IQueryable<TagToUser> query = _db.TagToUser;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            
            if (pageSize > 0)
            {
                query = query.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
            }

            return query.AsEnumerable().DistinctBy(x => x.UserId).ToList();

        }

    }
}
