using System.ComponentModel.DataAnnotations;

namespace Superheroes.Tech.API.Http.Models.Request
{
    public class BattleRequest
    {
        [Required(ErrorMessage = "Character is required.")]
        [MinLength(1, ErrorMessage = "Character cannot be empty.")]
        public required string Character { get; set; }

        [Required(ErrorMessage = "Rival is required.")]
        [MinLength(1, ErrorMessage = "Rival cannot be empty.")]
        public required string Rival { get; set; }
    }
}
