using Microsoft.EntityFrameworkCore;

namespace SteveTenadjangMS2D4.Models
{
    public class Produit
    {
        public int ID { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Prix { get; set; } = 0;
        public DateTime DatePeremption { get; set; } = DateTime.Now.AddYears(2);

    }
}
