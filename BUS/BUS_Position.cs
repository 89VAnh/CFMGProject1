﻿using DAL;
using System.Collections.Generic;
namespace BUS
{
    public class BUS_Position
    {
        DAL_Position dalPosition = new DAL_Position();

        public List<Quyen> GetPositions()
        {
            return dalPosition.GetPositions();
        }
    }
}