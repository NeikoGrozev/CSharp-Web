namespace IRunesNew.ViewModels.Albums
{
    using System.Collections.Generic;

    public class AllDetailAlbumViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}
