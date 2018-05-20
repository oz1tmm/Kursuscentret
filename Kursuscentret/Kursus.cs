using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;


namespace Kursuscentret
{
    class Kursus {
        // Fields.
        private string _kursusNavn;
        private int _kursusId;
        private DateTime _kursusStart;
        private int _varighed;
        private string _description;
        private List<Kursist> tilmeldteKursister = new List<Kursist>(); 

        private static int idx = 500;

        public string Name {
            get { return _kursusNavn; }
        }   
        public string Description {
            get { return _description; }
        }

        public static string Kurser {
            get {
                string kurser;
                kurser = "ID\tNavn\t\t\tBeskrivelse\n";
                foreach (var s in Liste.ListKurser()) {
                    kurser += s + "\n";
                }
                return kurser;
            }
        }

        // consr
        private Kursus() : this("Ikke-navngivet kursus", DateTime.Today, 5, "Et defaultkursus") {
        }

        private Kursus(string navn) {
            _kursusNavn = navn;
            _kursusId = ++idx;  
            _kursusStart = DateTime.Today;
            _varighed = 5;
        }

        private Kursus(string navn, DateTime dato, int varighed, string desc) { 
            _kursusNavn = navn;
            _kursusId = ++idx;
            _kursusStart = dato;
            _varighed = varighed;
            _description = desc;
        }


        
        public static void Add(string navn, DateTime startDato, int varighed, string desc) {
            Liste.Add(new Kursus(navn, startDato, varighed, desc));  
        }
    }
}