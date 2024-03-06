using APICatalogo.Context;
using APICatalogo.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public Categoria Delete(int id)
    {
        //Find vai na memória, não no banco
        var categoria = _context.Categorias.Find(id);
        
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return categoria;
    }

    public IEnumerable<Categoria> Get()
    {
        return _context.Categorias.Take(10).AsNoTracking().ToList();
    }

    public Categoria Get(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

    }

    public IEnumerable<Categoria> GetCategoriasProdutos()
    {
        return _context.Categorias.Include(p => p.Produtos).Where(p => p.CategoriaId < 5).AsNoTracking().ToList();
    }

    public Categoria Post(Categoria categoria)
    {

        if (categoria == null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return categoria;

    }
    public Categoria Put(int id, Categoria categoria)
    {
        if (categoria == null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return categoria;
    }
}
