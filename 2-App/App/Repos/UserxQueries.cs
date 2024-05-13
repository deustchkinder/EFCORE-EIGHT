using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repos
{
    public class UserxQueries
    {
        private readonly MyDbContext _db;
        public UserxQueries(MyDbContext db)
        {
            _db = db;
        }
        public List<Userx> GetAll()
        {
            return _db.Users.ToList();
        }
    }
}
