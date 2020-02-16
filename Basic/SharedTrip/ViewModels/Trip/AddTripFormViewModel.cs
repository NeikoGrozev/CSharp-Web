namespace SharedTrip.ViewModels.Trip
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddTripFormViewModel
    {
        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int Seats { get; set; }

        public string Description { get; set; }
    }
}
