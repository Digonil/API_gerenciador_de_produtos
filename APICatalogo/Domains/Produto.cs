﻿using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Domains;

[Table("Produtos")]
public class Produto  
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    [PrimeiraLetraMaiuscula]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }
    
    public int CategoriaId { get; set; }

    [JsonIgnore] //Usado para que o Swagger omitir os dados da categoria Json de resposta.
    public Categoria? Categoria { get; set; }//Propriedade de navegação que indica que Categoria está vinculado ao Produto

}
