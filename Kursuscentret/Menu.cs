using System;
using System.Text.RegularExpressions;

namespace Kursuscentret {
    class Menu {

        private int _valg;
        private int _valgtKursus;
        private int _valgtUnderviser;


        // Member functions
        public void Start() {
            do {
                Console.Clear();
                Console.WriteLine("****************************************************");
                Console.WriteLine("*    Menuvalg for Kursuscentret                    *");
                Console.WriteLine("****************************************************");
                Console.WriteLine("    Login som:                                      ");
                Console.WriteLine("    1. Kursusleder                                  ");
                Console.WriteLine("    2. Kursist                                      ");
                Console.WriteLine("    3. Administration                               ");
                Console.WriteLine("                                                    ");
                Console.WriteLine("    0. Afbryd                                       ");
                Console.WriteLine(" -------------------------------------------------- ");
                Console.WriteLine();
                Console.Write(" Valg: ");
                _valg = int.Parse(Console.ReadLine());
                switch (_valg) {
                    case 1:
                        LederMenu();
                        break;
                    case 2:
                        KusrsistMenu();
                        break;
                    case 3:
                        Administrationsmenu();
                        break;
                    default:
                        break;
                }
            } while (_valg != 0);
        }

        private void LederMenu() {
            Console.WriteLine("Dette er Undervsermenuen.");
            do {
                Console.Clear();
                Console.WriteLine("1. Se oprettede Kurser");
                Console.WriteLine("2. Vælg kursus");
                Console.WriteLine("3. Se tilmeldte kursister på valgt kursus ");
                Console.WriteLine("4. Opret Kursus.");
                Console.WriteLine("5. ");
                Console.WriteLine("");
                Console.WriteLine("0. Afslut");
                Console.WriteLine();
                Console.Write(" Valg: ");
                _valg = int.Parse(Console.ReadLine());
                switch (_valg) {
                    case 1:
                        // todo: Lave liste over indhold i _kurser i Kurser-klassen. Property i Kursus()
                        Console.WriteLine(Kursus.Kurser);
                        break;
                    case 2:
                        // Samme liste som i 1, men nu med mulighed for at vælge et kursus.
                        // _valgtKursus = kursusId-ish.
                        break;
                    case 3:
                    // Liste med tilmeldte kursister på _tilmeldte.Antal (Laves som property i Kursus()?)
                        break;
                    default:
                        break;
                }

            } while (_valg != 0);
        }

        private void KusrsistMenu() {
            Console.Clear();
            Console.WriteLine("Dette er Kursistmenuen.");
            // Todo: Skrive kursistmenu her.
        }

        private void Administrationsmenu() {
            do {
                Console.Clear();
                Console.WriteLine("!!  Administration !!");
                Console.WriteLine();
                Console.WriteLine("  1. Tilføj Underviser ");
                Console.WriteLine("  2. Vælg underviser fra liste");
                Console.WriteLine("  3  Ændre data for valgt underviser");
                Console.WriteLine("  4. Gør valgte underviser aktiv/inaktiv");
                Console.WriteLine("  5. Opret kursus");
                Console.WriteLine("  6. Ændre Kursus");
                Console.WriteLine();
                Console.WriteLine("  9. Tilbage");
                Console.WriteLine("  0. Afslut");
                Console.WriteLine();
                Console.WriteLine(
                    $"Valgt Underviser er: {_valgtUnderviser}"); // Indsæt evt også navnet på den valgte underviser her... 
                Console.Write(" Valg: ");
                _valg = int.Parse(Console.ReadLine());
                switch (_valg) {
                    case 1: // Tilføj ny underviser
                        TilfoejUnderviser();
                        break;
                    case 2: // Vælg aktiv underviser fra liste ---
                        //Console.WriteLine(Liste.ListUndervisere());
                        var list = Liste.ListUndervisere();
                        foreach (var u in list) {
                            Console.WriteLine(u);
                        }
                        Console.Write("Vælg nu hvilken underviser der skal være den aktive: ");
                        string sInput = Console.ReadLine();
                        if (Regex.IsMatch(sInput, @"^\d+$")) {
                            _valgtUnderviser = int.Parse(sInput);
                        }
                        else {
                            Console.WriteLine("Du skal vælge en underviser fra listen.");
                        }

                        break;
                    case 3:
                         // Ændre data for valgt underviser  ---- List alle variable med nuværende værdi som std, men mulighed for at sætte en ny.

                        break;
                    case 4: // Skift status for valgt underviser
                        Underviser.SwitchStatus(_valgtUnderviser - 1);
                        break;
                    case 5: // Opret kursus
                        TilfoejKursus();
                        break;
                    case 6: // Ændre Kursus
                        break;
                    case 9:
                        Start();
                        break;
                    default:
                        Console.WriteLine("Du skal væælge 1 til 6.");
                        break;
                }
            } while (_valg != 0);
        }

        private void TilfoejUnderviser() {
            string tilfoejFlere = "n";
            Console.Clear();
            do {
                Console.WriteLine();
                Console.Write("Hvad hedder den nye underviser?: ");
                string navn = Console.ReadLine();
                Console.Write("Skal underviseren tilføjes som aktiv? (j/n): ");
                string tmp = Console.ReadLine().ToLower();
                bool aktiv = tmp.Equals("j");
                Console.Write($"Hvilke fag skal tilknyttes {navn}? (Hvis flere fag, adskil med komma): ");
                tmp = Console.ReadLine();
                // todo: for-løkke med strip på hver enkelt element for mellemrum.
                string[] kompetencer;
                if (tmp.Contains(",")) {
                    kompetencer = tmp.Split(',');
                    for (int i = 0; i < kompetencer.Length; i++) {
                        kompetencer[i].Trim();
                    }
                }
                else {
                    kompetencer = new string[] {tmp};
                }
                Underviser.Add(navn, aktiv, kompetencer);
                Console.WriteLine("Vil du tilføje flere undervisere?");
                tilfoejFlere = Console.ReadLine();
            } while (tilfoejFlere == "j");
        }
        private void TilfoejKursus() {
            Console.WriteLine("Navn på kursus: ");
            string navn = Console.ReadLine();
            Console.WriteLine("Hvornår starter kurset?: ");
            DateTime startDato = DateTime.Today;
            try {
                startDato = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("Ikke en dato. I stedet indsættes dags dato.");
                startDato = DateTime.Today;
            }
            Console.WriteLine("Hvor mange dage varer kurset?: ");
            int varighed;
            if (int.TryParse(Console.ReadLine(), out int result)) {
                varighed = result;
            }
            else {
                varighed = 1;
            }
            Console.WriteLine("Tilføj en beskrivelse for kurset:");
            string description = Console.ReadLine();
            Kursus.Add(navn, startDato, varighed, description);
        }
    }
}


