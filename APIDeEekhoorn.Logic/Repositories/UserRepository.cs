using APIDeEekhoorn.Logic.Models;
using APIDeEekhoorn.Logic.SharedKernel;
using APIDeEekhoorn.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDeEekhoorn.Logic.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from u in session.Query<User>()
                            select u;

                query = query.Where(u => u.Username == username);

                var users = query.ToList();

                if (users.Count > 0)
                {
                    return query.ToList().Last();
                }
                else
                {
                    return null;
                }
            }
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
