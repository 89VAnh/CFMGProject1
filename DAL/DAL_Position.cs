using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Position
    {
        private QLCPEntities db = new QLCPEntities();

        public List<Quyen> GetAll()
        {
            return db.Quyens.ToList();
        }
    }
}