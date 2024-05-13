using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repos
{
    public class UserxCommands
    {
        private readonly MyDbContext _db;
        public UserxCommands(MyDbContext db)
        {
            _db = db;
        }
        public void Add(Userx userx)
        {
            _db.Users.Add(userx);
            _db.SaveChanges();
        }
    }
}
