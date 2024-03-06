﻿using APICatalogo.Context;
using APICatalogo.Domains;
using APICatalogo.Filters;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepository _repository;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(ICategoriaRepository repository, ILogger<CategoriasController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        var categoriasProdutos = _repository.GetCategoriasProdutos();
        return Ok(categoriasProdutos);
    }

    [HttpGet]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _repository.Get();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _repository.Get(id);

        if (categoria is null)
        {
            _logger.LogWarning($"Categoria com id = {id} não encontrada...");
            return NotFound($"Categoria com id= {id} não encontada...");
        }

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Categoria> Post(Categoria categoria)
    {
        if (categoria is null)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        var categoriaCriada = _repository.Post(categoria);
        return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaCriada.CategoriaId }, categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if(id != categoria.CategoriaId)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        _repository.Put(id, categoria);
        return Ok(categoria);
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _repository.Get(id);

        if (categoria is null)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        var categoriaExcluida = _repository.Delete(id);
        return Ok(categoriaExcluida);


    }
}
