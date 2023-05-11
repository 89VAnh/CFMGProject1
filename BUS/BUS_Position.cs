using DAL;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_Position
    {
        private DAL_Position dalPosition = new DAL_Position();

        public List<Quyen> GetAll()
        {
            return dalPosition.GetAll();
        }
    }
}