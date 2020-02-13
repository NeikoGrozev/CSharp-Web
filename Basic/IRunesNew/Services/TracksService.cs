using IRunesNew.Data;
using IRunesNew.Models;
using IRunesNew.ViewModels.Tracks;
using System.Linq;

namespace IRunesNew.Services
{
    public class TracksService : ITracksService
    {
        private readonly IRunesDbContex db;

        public TracksService(IRunesDbContex db)
        {
            this.db = db;
        }

        public void CreateTrack(string name, string link, decimal price, string albumId)
        {
            var track = new Track
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId,
            };

            var allTrackInAlbum = this.db.Tracks
                .Where(x => x.Id == albumId)
                .Sum(x => x.Price) + price;

            var album = this.db.Albums.FirstOrDefault(x => x.Id == albumId);
            album.Price = allTrackInAlbum * 0.87M;

            this.db.Tracks.Add(track);
            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string albumId, string trackId)
        {
            var viewModel = this.db.Tracks.Where(x => x.Id == trackId)
                  .Select(x => new DetailsViewModel
                  {
                      Name = x.Name,
                      Link = x.Link,
                      Price = x.Price,
                      AlbumId = x.AlbumId,
                  }).FirstOrDefault();

            return viewModel;
        }
    }
}
