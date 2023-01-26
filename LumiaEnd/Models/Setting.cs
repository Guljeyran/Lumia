using System.ComponentModel.DataAnnotations;

namespace LumiaEnd.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string? Key { get; set; }
        [StringLength(maximumLength: 100)]
        public string Value { get; set; }
    }
}
