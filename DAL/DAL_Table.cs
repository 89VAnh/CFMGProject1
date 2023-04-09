using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Table
    {
        QLCPEntities db = new QLCPEntities();
        public List<Ban> GetTableCoffees()
        {
            return db.Bans.ToList();
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
