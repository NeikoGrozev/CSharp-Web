namespace IRunesNew.Services
{
    using Data;
    using ViewModels.Albums;
    using System.Collections.Generic;
    using System.Linq;
    using IRunesNew.Models;

    public class AlbumsService : IAlbumsService
    {
        private readonly IRunesDbContex db;

        public AlbumsService(IRunesDbContex db)
        {
            this.db = db;
        }

        public void CreateAlbum(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0M,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumNameViewModel> GetAllAlbums()
        {
            var allAlbums = this.db.Albums
                .Select(x => new AlbumNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            return allAlbums;
        }

        public AllDetailAlbumViewModel GetDetails(string id)
        {
            var viewModel = this.db.Albums.Where(x => x.Id == id)
                .Select(x => new AllDetailAlbumViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(t => new TrackInfoViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                    })
                }).FirstOrDefault();

            return viewModel;
        }
    }
}
