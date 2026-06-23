namespace Rivers_Dams_Bulgaria.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Reservoir
{
    [Key]
    public int ReservoirId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(1, 1000)]
    public double Area { get; set; }

    [Required]
    [Range(1, 1000000)]
    public double Capacity { get; set; }

    [Required]
    [ForeignKey(nameof(Dam))]
    public int DamId { get; set; }

    public Dam Dam { get; set; }
}



