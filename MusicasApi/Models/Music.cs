using System.ComponentModel.DataAnnotations;

namespace MusicasApi.Models;

public class Music
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "O nome da música deve conter no máximo 50 caracteres")]
    public string Name { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "O nome da banda deve conter no máximo 30 caracteres")]
    public string Band { get; set; }

    [Required]
    [Range(120, 1000, ErrorMessage = "A duração da música deve conter no máximo 1000 segundos")]
    public int Duration { get; set; }


}
