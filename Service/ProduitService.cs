using Microsoft.EntityFrameworkCore;
using SteveTenadjangMS2D4.Data;
using SteveTenadjangMS2D4.Models;

namespace SteveTenadjangMS2D4.Service
{
    public class ProduitService : IProduitService
    {
        protected readonly AppDbContext _context;

        public ProduitService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Produit>> GetAllProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit?> GetProduitByIdAsync(int idProduit)
        {
            return await _context.Produits.FirstOrDefaultAsync(p => p.ID == idProduit);
        }

        public async Task<Produit?> GetProduitByCodeAsync(string code)
        {
            return await _context.Produits.FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task AddProduitAsync(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Produit produit)
        {
            _context.Entry(produit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitAsync(Produit produit)
        {
            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProduitExiste(int idProduit)
        {
            var produit = await _context.Produits.FirstOrDefaultAsync(p => p.ID == idProduit);
            return produit != null;
        }

        public async Task<bool> CodeProduitExiste(string code)
        {
            var produit = await _context.Produits.FirstOrDefaultAsync(p => p.Code == code);
            return produit != null;
        }

    }
}
