using Microsoft.AspNetCore.Mvc;
using SteveTenadjangMS2D4.Models;
using SteveTenadjangMS2D4.Service;

namespace SteveTenadjangMS2D4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            var produits = await _produitService.GetAllProduitsAsync();
            return produits is null ? NoContent() : Ok(produits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduitById(int id)
        {
            var produit = await _produitService.GetProduitByIdAsync(id);
            return produit is null ? NotFound() : Ok(produit);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Produit>> GetProduitByCode(string code)
        {
            var produit = await _produitService.GetProduitByCodeAsync(code);
            return produit is null ? NotFound() : Ok(produit);
        }

        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            if (produit is null)
                return BadRequest();

            if (await _produitService.CodeProduitExiste(produit.Code))
                return Conflict();

            if (await _produitService.ProduitExiste(produit.ID))
                return Conflict();

            await _produitService.AddProduitAsync(produit);
            return Ok(produit);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Produit>> PutProduit(int id, Produit produit)
        {
            if (produit is null)
                return BadRequest();

            if (id != produit.ID)
                return BadRequest();

            if (await _produitService.CodeProduitExiste(produit.Code))
                return Conflict();

            if (await _produitService.ProduitExiste(produit.ID))
                return Conflict();

            await _produitService.UpdateProductAsync(produit);

            return Ok(produit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            Produit? produit = await _produitService.GetProduitByIdAsync(id);
            if (produit is null)
                return BadRequest();
            await _produitService.DeleteProduitAsync(produit);
            return NoContent();
        }
    }
}
