namespace Rivers_Dams_Bulgaria.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class River
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RiverId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(1, 3000)]
    public double Length { get; set; }

    [Required]
    [StringLength(100)]
    public string SourceLocation { get; set; }

    [Required]
    [StringLength(100)]
    public string MouthLocation { get; set; }

   

    public List<Dam> Dams { get; set; } = new();
}




