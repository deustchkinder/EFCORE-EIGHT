using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repos
{
    public class UserxQueries
    {
        private readonly MyDbContext _db;
        public UserxQueries()
        {
            _db = new();
        }

        public Userx? GetUser(int id)
        {
            using (_db)
            {
                return _db.Users.Find(id);
            }
        }
        public List<Userx> GetUsers()
        {
            using (_db)
            {
                return _db.Users.ToList();
            }
        }
        public List<Userx> GetUsers(string name)
        {
            using (_db)
            {
                return _db.Users.Where(u => u.Name == name).ToList();
            }
        }
        public List<Userx> GetUsers(int page = 1, int pageSize = 10)
        {
            using (_db)
            {
                var resul = _db.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return resul;
            }
        }
        public List<Userx> GetUsers(Expression<Func<Userx, bool>> exp)
        {
            using (_db)
            {
                return _db.Users.Where(exp).ToList();
            }
        }

    }
}
