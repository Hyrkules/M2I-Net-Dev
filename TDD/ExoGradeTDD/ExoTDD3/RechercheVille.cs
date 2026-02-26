using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExoTDD3
{
    public class RechercheVille
    {
        private List<string> _villes = new List<string> { "Budapest", "Valence", "Vancouver" };

        public List<string> Rechercher(string mot)
        {
            if (mot == "*")
                return new List<string>(_villes);
            if (mot.Length < 2)
            {
                throw new NotSupportedException("Le mot doit comporter au moins 3 caractères.");
            }

            return _villes
                .Where(v => v.Contains(mot, StringComparison.OrdinalIgnoreCase))
                .ToList();

        }
    }
}
