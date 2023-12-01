using System.Collections.ObjectModel;

namespace APICatalogo.Domains;

public class Categoria
{

    public Categoria()
    {
        //Boa prática inicializar a coleção
        Produtos = new Collection<Produto>();    
    }

    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }  //Indica que uma categoria possui vários produtos
}
