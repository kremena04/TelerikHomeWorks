﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    public class Score
    {
        private string name;
        private int points;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Score()
        {
        }

        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
