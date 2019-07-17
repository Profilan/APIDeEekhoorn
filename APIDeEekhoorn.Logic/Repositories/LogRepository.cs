using APIDeEekhoorn.Logic.Models;
using APIDeEekhoorn.Logic.SharedKernel;
using APIDeEekhoorn.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDeEekhoorn.Logic.Repositories
{
    public class LogRepository : IRepository<Log, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Log GetById(int id)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var log = session.Get<Log>(id);
                return log;
            }
        }

        public void Insert(Log entity)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }
        public IEnumerable<Log> List()
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from l in session.Query<Log>()
                            select l;

                return query.ToList();
            }
        }

        public IEnumerable<Log> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public void Update(Log entity)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
