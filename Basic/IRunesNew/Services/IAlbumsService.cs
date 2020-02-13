namespace IRunesNew.Services
{
    using ViewModels.Albums;
    using System.Collections.Generic;

    public interface IAlbumsService
    {
        IEnumerable<AlbumNameViewModel> GetAllAlbums();

        void CreateAlbum(string name, string cover);

        AllDetailAlbumViewModel GetDetails(string id);
    }
}
