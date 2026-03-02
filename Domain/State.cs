using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class State
{
    [Key]
    public int Id { get;set; }
    public string Name { get; set; }


    [ForeignKey("Country")]
    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public bool IsActive { get; set; } = true;
}
