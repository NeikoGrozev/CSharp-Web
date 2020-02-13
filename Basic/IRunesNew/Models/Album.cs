namespace IRunesNew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
