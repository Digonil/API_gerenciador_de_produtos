using APICatalogo.Domains;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Repository;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategoriasProdutos();
    IEnumerable<Categoria> Get();
    Categoria Get(int id);
    Categoria Post(Categoria categoria);
    Categoria Put(int id, Categoria categoria);
    Categoria Delete(int id);

}
