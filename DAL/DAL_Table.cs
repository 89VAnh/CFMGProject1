using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Table
    {
        private QLCPEntities db = new QLCPEntities();

        public List<Ban> GetAll()
        {
            return db.Bans.ToList();
        }

        public Ban GetByID(int id)
        {
            return db.Bans.Find(id);
        }

        public void Add(Ban tableCoffee)
        {
            db.Bans.Add(tableCoffee);
            db.SaveChanges();
        }

        public void Update(Ban tableCoffee)
        {
            Ban t = db.Bans.Find(tableCoffee.Ma);
            t.Ten = tableCoffee.Ten;
            db.SaveChanges();
        }

        public void Delete(Ban tableCoffee)
        {
            db.Bans.Remove(tableCoffee);
            db.SaveChanges();
        }
    }
}