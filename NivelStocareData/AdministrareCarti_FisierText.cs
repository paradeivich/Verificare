using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareCarti_FisierText
    {
        private const int NR_MAX_CARTI = 50;
        private string numeFisier;

        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddCarte(Carte carte)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(carte.ConversieLaSir_PentruFisier());
            }
        }

        public Carte[] GetCarte(out int nrBook)
        {
            Carte[] carti = new Carte[NR_MAX_CARTI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrBook = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    carti[nrBook++] = new Carte(linieFisier);
                }
            }

            return carti;
        }
    }
}