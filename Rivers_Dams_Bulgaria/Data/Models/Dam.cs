namespace Rivers_Dams_Bulgaria.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dam
{
    [Key]
    public int DamId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(1, 500)]
    public double Height { get; set; }

    [Required]
    [Range(1, 10000)]
    public double Length { get; set; }

    [Required]
    public int YearBuilt { get; set; }

    [Required]
    [ForeignKey(nameof(River))]
    public int RiverId { get; set; }

    public River River { get; set; }

    public List<Reservoir> Reservoirs { get; set; } = new();
}
