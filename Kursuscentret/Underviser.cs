using System;
using System.Linq;

namespace Kursuscentret
{
    class Underviser : Person {
        private string[] _kompetencer;
        private bool _active;
        

        
        // Properties
        public string Kompetencer {
            get {
                string s = null;
                for (var i = 0; i < _kompetencer.Length; i++) {
                    s = $"{_kompetencer[i]}";
                    if (i + 1 != _kompetencer.Length) {
                        s += ",";
                    }
                }
                return s;
            }
        }

        public bool Active {
            get { return _active; }
        }

        // Consr
        public Underviser() {
            Name = "Tom constructor benyttet.";
            _kompetencer = new string[] { }; // Empty array of strings
            _active = false;
        }

        public Underviser(string navn, bool active, string[] kompetencer) {
            Name = navn;
            _kompetencer = kompetencer;
            _active = active;
        }


        // Member functions

        public static void Add(string navn) {
            //Add(s, new string[]{});
            Liste.Add(new Underviser(navn, false, new string[]{}));
        }

        public static void Add(string navn, bool aktiv, string[] kompetencer) {
            Liste.Add(new Underviser(navn, aktiv, kompetencer));
        }

//        public static string ListUndervisere() {
//            int numUndervisere = .Count;
//            string s = "nr\tNavn\t\t\tAktiv\tFag\n";
//            if (numUndervisere != 0) {
//                for(int i = 0; i < numUndervisere; i++) {
//                    s += $"{i + 1}.\t{undervisere[i]._name}\t\t\t{undervisere[i]._active}\t{string.Join(',', undervisere[i]._kompetencer)}\n";
//                }
//            }
//            s += $"\t\t\t\t{numUndervisere} undervisere i alt.";
//            return s;
//        }
        
        public static void SwitchStatus(int objId) {
            
        }
    }
}