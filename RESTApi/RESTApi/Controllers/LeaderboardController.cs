using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApi.Models;

namespace RESTApi.Controllers
{
    public class LeaderboardController : ApiController
    {
        // Gets Leaderboard
        public IEnumerable<Leaderboard> Get()
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Leaderboards.ToList();
            }
        }

        public void Create(Leaderboard leaderboard)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                entities.Leaderboards.Add(leaderboard);
                entities.SaveChanges();
            }
        }

        public Leaderboard FindEntryToEdit(int id)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                return entities.Leaderboards.Find(id);
            }
        }

        public void EditEntry(Leaderboard leaderboard)
        {
            using (UserAPIEntities entities = new UserAPIEntities())
            {
                entities.Entry(leaderboard).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
    }
}
