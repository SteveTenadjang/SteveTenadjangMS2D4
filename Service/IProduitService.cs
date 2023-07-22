using SteveTenadjangMS2D4.Models;

namespace SteveTenadjangMS2D4.Service
{
    public interface IProduitService
    {
        Task<List<Produit>> GetAllProduitsAsync();
        Task<Produit?> GetProduitByIdAsync(int idProduit);
        Task<Produit?> GetProduitByCodeAsync(string code);
        Task AddProduitAsync(Produit produit);
        Task UpdateProductAsync(Produit produit);
        Task DeleteProduitAsync(Produit produit);
        Task<bool> ProduitExiste(int idProduit);
        Task<bool> CodeProduitExiste(string code);

    }
}
