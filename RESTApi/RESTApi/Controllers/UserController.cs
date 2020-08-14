using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApi.Models;
using System.Data.Entity;

namespace RESTApi.Controllers
{
    public class UserController : ApiController
    {
        // Gets all users
        public IEnumerable<User> Get()
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Users.ToList();
            }
        }

        // Gets user by id
        public User Get(int id)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Users.FirstOrDefault(u => u.UserId == id);
            }
        }

        // Gets user by id
        public int GetTotalUserCount()
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Users.Count();
            }
        }

        public void Create(User user)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                entities.Users.Add(user);
                entities.SaveChanges();
            }
        }

        public User FindUserToEdit(int id)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Users.Find(id);
            }
        }

        public void EditUser(User editUser)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                entities.Entry(editUser).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
    }
}
