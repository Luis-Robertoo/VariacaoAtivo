using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoAtivo.API.Entities;

public class AssetValue
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
}
