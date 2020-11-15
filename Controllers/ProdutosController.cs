using Loja.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Loja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        Loja.Data.MongoDB _mongoDB;
        private IMongoCollection<Data.Collections.Produtos> _produtosCollection;
        public ProdutosController(Loja.Data.MongoDB mongoDB)
        {
            this._mongoDB =mongoDB;
            _produtosCollection = _mongoDB.DB.GetCollection<Data.Collections.Produtos>(typeof(Data.Collections.Produtos).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody]Produtos dto)
        {
            var produto = new Loja.Data.Collections.Produtos(dto.Nome, dto.Preco);

            _produtosCollection.InsertOne(produto);

            return StatusCode(201, "Infectado adicionado com sucesso!");
        }
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _produtosCollection.Find(Builders<Data.Collections.Produtos>.Filter.Empty).ToList();

            return Ok(infectados);
        }
    }
}