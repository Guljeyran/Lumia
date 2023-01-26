using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LumiaEnd.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string Fullname { get; set; }
        public string Desc { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        [StringLength(maximumLength: 150)]
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [StringLength(maximumLength: 150)]
        public string? RedirectUrl1 { get; set; }
        [StringLength(maximumLength: 150)]
        public string? RedirectUrl2 { get; set; }
        [StringLength(maximumLength: 150)]
        public string? RedirectUrl3 { get; set; }
        [StringLength(maximumLength: 150)]
        public string? RedirectUrl4 { get; set; }

    }
}
