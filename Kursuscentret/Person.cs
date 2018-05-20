using System;

namespace Kursuscentret {
    abstract class Person {
        private string _name;
        private DateTime _birthdate;
        private int _id;
        private static int _idx = 0;

        public string Name {
            get { return _name; }
            set { }
        }

        protected int Id {
            get { return _id; }
            set { }
        }

        //protected int Age => _birthdate.Subtract(DateTime.Now).Hours/86400;
        public int Age {                                 
            get {
                DateTime fdag = DateTime.Now;
                int age = fdag.Year - _birthdate.Year;
                if (fdag.Month < _birthdate.Month || (fdag.Month == _birthdate.Month && fdag.Day < _birthdate.Day)) {   // Til håndtering af hvis fødselsdag er aktuel måned. 
                    age--;
                }
                return age;
            }
        }

        public DateTime BirthDate {
            get { return _birthdate; }
        }


        // Consr
        protected Person() { } // Should never be used, but needed.

        protected Person(string name, DateTime birthdate, int id) {
            _name = name;
            _birthdate = birthdate;
            _id = ++_idx;
        }


    }
}