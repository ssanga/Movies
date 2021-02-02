using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Data
{
    public class MoviesDto : ICloneable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public int Year { get; set; }
        [Column("Portrait URL")]
        public string PortraitUrl { get; set; }

        public object Clone()
        {
            var result = new MoviesDto
            {
                Id          = this.Id,
                Name        = this.Name,
                Year        = this.Year,
                PortraitUrl = this.PortraitUrl
            };

            return result;
        }
    }
}
