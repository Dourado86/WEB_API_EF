using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apiweb.Context;
using Apiweb.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Apiweb.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController (AgendaContext context)
        {
            _context = context;
        }
        //MÉTODO CRUD QUE CRIA UM NOVO RECURSO OU INFORMAÇÃO NA API, ATUALIZANDO NA TABELA DO BANCO DE DADOS 
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
        }
        //MÉTODO CRUD QUE BUSCA UM RECURSO OU INFORMAÇÃO NA API,QUE ESTA NO BANCO DE DADOS PELO "ID"
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();

                return Ok (contato);
        }

        //MÉTODO CRUD QUE BUSCA UM RECURSO OU INFORMAÇÃO NA API, QUE ESTA NO BANCO DE DADOS PELO "NOME"
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x=>x.Nome.Contains(nome));
            return Ok (contatos);
        }


        //MÉTODO CRUD QUE ATUALIZA UM RECURSO OU INFORMAÇÃO NA API, QUE ESTA NO BANCO DE DADOS PELO "ID"
         [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound();
            //SE A INFORMAÇÃO FOR VERDADEIRA SERÁ FEITO A ATUALIZAÇÃO DAS INFORMAÇ~ES ABAIXO
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo; 

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok (contatoBanco);
        }


        //MÉTODO CRUD QUE DELETA UM RECURSO OU INFORMAÇÃO NA API, QUE ESTA NO BANCO DE DADOS PELO "ID"
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
            return NotFound();

            _context.Contatos.Remove(contatoBanco);   
            _context.SaveChanges();

            return NoContent ();
        }
        
    }
}