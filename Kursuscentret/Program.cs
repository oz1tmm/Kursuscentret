﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursuscentret {
    class Program {
        static void Main(string[] args) {
            Menu menu = new Menu();
            Liste list = new Liste();
            //list = list.HentData();
            menu.Start(ref list);

        }
    }
}
