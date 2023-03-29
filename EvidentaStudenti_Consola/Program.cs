using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaCarti_Consola
{
    class Program
    {
        static void Main()
        {
            Carte carte = new Carte();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareCarti_FisierText adminCarti = new AdministrareCarti_FisierText(numeFisier);
            int nrBook = 0;
            adminCarti.GetCarte(out nrBook);

            string optiune;
            do
            {
                Console.WriteLine("I. Introducere informatii despre Carte");
                Console.WriteLine("A. Afisarea a ultimiii carti introduse");
                Console.WriteLine("F. Afisare carte din fisier");
                Console.WriteLine("S. Salvare carte in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Z. Informatie autor");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        carte = CitireCarteTastatura();

                        break;
                    case "A":
                        AfisareCarte(carte);

                        break;
                    case "F":
                        Carte[] carti = adminCarti.GetCarte(out nrBook);
                        AfisareCarti(carti, nrBook);

                        break;
                    case "S":
                        int idBook = nrBook + 1;
                        carte.SetIdBook(idBook);
                       
                        adminCarti.AddCarte(carte);

                        nrBook = nrBook + 1;

                        break;
                    case "X":

                        return;
                    case "Z":
                        Console.WriteLine("Program realizat de Ghilescu Dumitru, grupa 3121B");
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void AfisareCarte(Carte carte)
        {
            string infoCarte = string.Format("Cartea cu id-ul #{0} este: {1}; autor: {2}",
                   carte.GetIdBook(),
                   carte.GetNume() ?? " NECUNOSCUT ",
                   carte.GetAutor() ?? " NECUNOSCUT ");

            Console.WriteLine(infoCarte);
        }

        public static void AfisareCarti(Carte[] carte, int nrBook)
        {
            Console.WriteLine("Cartile sunt:");
            for (int contor = 0; contor < nrBook; contor++)
            {
                AfisareCarte(carte[contor]);
            }
        }

        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Introduceti denumirea cartii: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti autorul cartii: ");
            string autor = Console.ReadLine();

            Carte carte = new Carte(0, nume, autor);

            return carte;
        }
    }
}
