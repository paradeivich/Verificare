using System;

namespace LibrarieModele
{
    public class Carte
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int NUME = 1;
        private const int AUTOR = 2;

        private int idBook; 
        private string nume;
        private string autor;

        public Carte()
        {
            nume = autor = string.Empty;
        }

        public Carte(int idBook, string nume, string autor)
        {
            this.idBook = idBook;
            this.nume = nume;
            this.autor = autor;
        }

        public Carte(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            idBook = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            autor = dateFisier[AUTOR];
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Nume:{1} Autor: {2}",
                idBook.ToString(),
                (nume ?? " NECUNOSCUT "),
                (autor ?? " NECUNOSCUT "));

            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectCartePentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idBook.ToString(),
                (nume ?? " NECUNOSCUT "),
                (autor ?? " NECUNOSCUT "));

            return obiectCartePentruFisier;
        }

        public int GetIdBook()
        {
            return idBook;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetAutor()
        {
            return autor;
        }

        public void SetIdBook(int idBook)
        {
            this.idBook = idBook;
        }
    }
}
