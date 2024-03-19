﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба10
{
    public class sort : IComparer
    {
        public int Compare(object x, object y)
        {
            MusicalInstrument mus1 = x as MusicalInstrument;
            MusicalInstrument mus2 = y as MusicalInstrument;

            string name1 = mus1.Name;     
            string name2 = mus2.Name;     

            
            return name1.CompareTo(name2);
        }
    }
}