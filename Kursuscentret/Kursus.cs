﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;


namespace Kursuscentret
{
    public class Kursus {
        // Fields.
        private string _kursusNavn;
        private int _kursusId;
        private DateTime _kursusStart;
        private int _varighed;
        private string _description;
        //private List<Kursist> tilmeldteKursister = new List<Kursist>(); 
        private Underviser _underviser;

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
        private Kursus() : this("Ikke-navngivet kursus") {
        }

        private Kursus(string navn) : this(navn, DateTime.Today, 5, "Default Kursus") {
        }

        private Kursus(string navn, DateTime dato, int varighed, string desc) { 
            _kursusNavn = navn;
            _kursusId = ++idx;
            _kursusStart = dato;
            _varighed = varighed;
            _description = desc;
        }

        private Kursus(string navn, DateTime dato, int varighed,string desc, Underviser u) :this(navn, dato, varighed, desc) {
            _underviser = u;
        }

    
        public static void Add(string navn, DateTime startDato, int varighed, string desc) {
            Liste.Add(new Kursus(navn, startDato, varighed, desc));
        }

        public static void Add(string navn, DateTime startDato, int varighed, string desc, Underviser underviser) {
            Liste.Add(new Kursus(navn, startDato, varighed, desc, underviser));
        }
    }
}