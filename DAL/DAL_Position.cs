﻿using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_Position
    {
        QLCPEntities db = new QLCPEntities();
        public List<Quyen> GetPositions()
        {
            return db.Quyens.ToList();
        }
    }
}