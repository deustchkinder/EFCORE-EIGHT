using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class UserxCommands
    {
        private readonly MyDbContext _db;
        public UserxCommands() {  _db = new(); }
        public void AddUser(Userx user)
        {
            using (_db)
            {
                _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _db.SaveChanges();
            }

        }
        public void AddUsers(List<Userx> users)
        {
            using (_db)
            {
                _db.Users.AddRange(users);
                _db.SaveChanges();
            }
        }
        public void UpdateUser(Userx user)
        {
            using (_db)
            {
                /*
                Userx? userxDb = _db.Users.FirstOrDefault(u => u.Name == user.Name);
                if (userxDb != null)
                {
                    userxDb.Name = user.Name;
                    userxDb.Age = user.Age;
                    _db.SaveChanges();
                }
                */
                _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public void DeleteUser(Userx user)
        {
            
            using (_db)
            {
                Userx? userxDb = _db.Users.FirstOrDefault(u => u.Name == user.Name);
                if (userxDb != null)
                {
                   _db.Entry(userxDb).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                   _db.SaveChanges(); 
                }

            }
        }
        public void DeleteUser(int id)
        {

            using (_db)
            {
                Userx? userxDb = _db.Users.Find(id);
                if (userxDb != null)
                {
                    _db.Remove(userxDb);
                    //_db.Entry(userxDb).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _db.SaveChanges();
                }

            }
        }
    }
}
