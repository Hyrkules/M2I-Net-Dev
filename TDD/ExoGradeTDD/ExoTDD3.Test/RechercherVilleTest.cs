namespace ExoTDD3.Test
{
    [TestClass]
    public sealed class RechercherVilleTest
    {
        [TestMethod]
        public void Rechercher_LessThan_2Car_NotFoundException()
        {
            RechercheVille rechercheVille = new RechercheVille();
            Assert.Throws<NotSupportedException>(() => rechercheVille.Rechercher("O"));
        }

        [TestMethod]
        public void Rechercher_Va_ValenceVancouver()
        {
            RechercheVille rechercheVille = new RechercheVille();
            List<string> res = rechercheVille.Rechercher("Va");
            CollectionAssert.AreEquivalent(new List<string> { "Valence", "Vancouver" }, res);
        }

        [TestMethod]
        public void Rechercher_CaseInsensitive()
        {
            RechercheVille rechercheVille = new RechercheVille();
            string mot = "Valence";
            List<string> res = rechercheVille.Rechercher(mot);
            List<string> resLow = rechercheVille.Rechercher(mot.ToLower());
            List<string> resUp = rechercheVille.Rechercher(mot.ToUpper());
            CollectionAssert.AreEqual(res, resLow);
            CollectionAssert.AreEqual(res, resUp);
        }

        [TestMethod]
        public void Rechercher_ape_Budapest()
        {
            RechercheVille rechercheVille = new RechercheVille();
            List<string> res = rechercheVille.Rechercher("ape");
            CollectionAssert.AreEquivalent(new List<string> { "Budapest" }, res);
        }

        [TestMethod]
        public void Rechercher_Asterisk_AllCities()
        {
            RechercheVille rechercheVille = new RechercheVille();
            List<string> res = rechercheVille.Rechercher("*");
            CollectionAssert.AreEquivalent(new List<string> { "Valence", "Vancouver", "Budapest" }, res);
        }
    }
}