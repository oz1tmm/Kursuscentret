using System;
using System.Collections.Generic;


namespace Kursuscentret {
    [Serializable]
    public class Liste {
        private static readonly List<Underviser> _undervisere = new List<Underviser>(); 
        private static readonly List<Kursus> _kurser = new List<Kursus>();
        private static readonly List<Kursist> _kursister = new List<Kursist>();
        private static Liste instance;

        private Liste() { }

        public static Liste Instance {
            get {
                if (instance == null) {
                    instance = new Liste();
                }
                return instance;
            }
        }
        
        public static int AntalUndervisere {
            get { return _undervisere.Count; }
        }

        public static int AntalKurser {
            get { return _kurser.Count; }
        }

        public static int AntalKursister {
            get { return _kursister.Count; }
        }

        public static void Add(Kursist kursist) {
            _kursister.Add(kursist);
        }

        public static void Add(Underviser underviser) {
            _undervisere.Add(underviser);
        }

        public static void Add(Kursus kursus) {
            _kurser.Add(kursus);
        }
        
        // Todo: Evt opbygge med StringBuilder.
        public static string[] ListKursister() {
            var n = _kursister.Count;
            string[] kursister = new string[n+1];
                // n+1 fordi det returnerende array også skal indeholde en headerlinje til info om hvad der står i kolonnerne.
            string[] header = new string[2] {"Navn", "Alder"};
            kursister[0] = $"{header[0],30}{header[1],5}";
            int i = 0;
            foreach (var kursist in _kursister) {
                kursister[i + 1] = $"{kursist.Name,30} {kursist.Age,5}";
                i++;
            }
            return kursister;
        }

        public static string[] ListUndervisere() {
            var n = _undervisere.Count;
            string[] undervisere = new string[n]; 
            string[] header = new string[4] {"Navn","Alder","Aktiv","Kompetencer"};
            //undervisere[0] = $"{header[0],-30}{header[1],-5}{header[2],-3}{header[3],-40}";
            for (var i = 0; i < n; i++) {
                undervisere[i] =
                    $"{i+1} - {_undervisere[i].Name}, {_undervisere[i].Age}, {_undervisere[i].Active}, {_undervisere[i].Kompetencer}";
            }

            return undervisere;
        }

        public static string[] ListKurser() {
            int n = _kurser.Count;
            string[] kurser = new string[n];
            //kurser[0] = String.Empty;
            for (var i = 0; i < n; i++) {
                kurser[i] = $"{i + 1} - {_kurser[i].Name}, {_kurser[i].Description}";
            }
            return kurser;
        }
        
        private static bool KursusExist(string navn, out string[] result) {
            var tmp = false;
            result = null;       
            foreach (var kursus in _kurser) {
                if (kursus.Name.Contains(navn)) {
                    tmp = true;
                    result[result.Length+1] = kursus.Name;
                }
            }
            return tmp;
        }
        
        // Vil gerne lave en metode til at tilgå Undervisere, så de kan sættes aktive/inaktive fra menu-klassen. Property?

    }
}