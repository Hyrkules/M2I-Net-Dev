using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModelDemo.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Prix { get; set; }

        public bool IsAvaiable => Stock > 0;

        public string StockStatus
        {
            get
            {
                if (Stock == 0) return "Rupture";
                if (Stock < 5) return "Stock Faible";
                return "En Stock";
            }
        }
        public string StockCssClass
        {
            get
            {
                if (Stock == 0) return "bg-danger";
                if (Stock < 5) return "bg-warning";
                return "bg-success";
            }
        }

        public string PriceFormated => $"{Prix.ToString("C")}";
        public bool IsExpensive => Prix >= 500;
        public string PriceCssClass
        {
            get
            {
                if (Prix >= 500) return "text-danger";
                return "text-success";
            }
        }

    }
}
