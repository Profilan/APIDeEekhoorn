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
    public class DashboardRepository : IRepository<Dashboard, Int64>
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Dashboard GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Dashboard entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dashboard> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dashboard> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dashboard> SalesPerMonthListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.AmountSortOrder < 26 && d.Type == "M")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.AmountSortOrder);

                return query.ToList();
            }
        }

        public IEnumerable<Dashboard> SalesPerQuarterListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.AmountSortOrder < 26 && d.Type == "Q")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.AmountSortOrder);

                return query.ToList();
            }
        }

        public IEnumerable<Dashboard> SalesPerYearListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.AmountSortOrder < 26 && d.Type == "Y")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.AmountSortOrder);

                return query.ToList();
            }
        }

        public IEnumerable<Dashboard> QuantityPerMonthListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.QuantitySortOrder < 26 && d.Type == "M")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.QuantitySortOrder);

                return query.ToList();
            }
        }

        public IEnumerable<Dashboard> QuantityPerQuarterListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.QuantitySortOrder < 26 && d.Type == "Q")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.QuantitySortOrder);

                return query.ToList();
            }
        }

        public IEnumerable<Dashboard> QuantityPerYearListByDebcode(string debcode)
        {
            using (ISession session = SessionFactory.GetNewSession())
            {
                var query = from d in session.Query<Dashboard>()
                            select d;

                query = query.Where(d => d.QuantitySortOrder < 26 && d.Type == "Y")
                    .Where(d => d.DebCode == debcode).OrderBy(d => d.QuantitySortOrder);

                return query.ToList();
            }
        }

        public void Update(Dashboard entity)
        {
            throw new NotImplementedException();
        }
    }
}
