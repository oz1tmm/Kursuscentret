using System;
using System.Linq;

namespace Kursuscentret
{
    public class Underviser : Person {
        private string[] _kompetencer;
        private bool _active;



        // Properties
        public string Kompetencer {
            get {
                var s = "[";
                for (var index = 0; index < _kompetencer.Length; index++) {
                    s += $"{_kompetencer[index]}";
                    if (index != _kompetencer.Length - 1) {
                        s += ",";
                    }
                }

                s += "]";
                return s;
            }
            set {
                if (!value.Equals("")) {
                    value.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries);
                }

            }
        }

        public bool Active {
            get { return _active; }
            set { _active = !_active; }
        }

        // Consr
        private Underviser() {
            Name = "Tom constructor benyttet.";
            _kompetencer = new string[] { }; // Empty array of strings
            _active = false;
        }

        private Underviser(string navn, DateTime birthDateTime, bool active, string[] kompetencer) : base(navn,
            birthDateTime) {
            _kompetencer = kompetencer;
            _active = active;
        }


        // Member functions

        public static void Add(string navn) {
            Liste.Add(new Underviser(navn, DateTime.Today, false, new string[] { }));
        }

        public static void Add(string navn, DateTime fDag, bool aktiv, string[] kompetencer) {
            //Underviser tmp = new Underviser(navn, fDag, aktiv, kompetencer);
            Liste.Add(new Underviser(navn, fDag, aktiv, kompetencer));
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

        
        public static string SwitchStatus(int id) {
            //Liste.SwitchStatusUnderviser(id);
            return Liste.SwitchStatusUnderviser(id);
        }

        public static void ModificerKompetencer(int id, string[] kompetencer) {
            Underviser tmpUnderviser = Liste.GetUnderviser(id);
            tmpUnderviser._kompetencer = kompetencer;
            Liste.GemNyeKompetencer(tmpUnderviser, kompetencer);
        }
    }
}