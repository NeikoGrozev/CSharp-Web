using IRunesNew.ViewModels.Tracks;

namespace IRunesNew.Services
{
    public interface ITracksService
    {
        void CreateTrack(string name, string link, decimal price, string albumId);

        DetailsViewModel GetDetails(string albumId, string trackId);
    }
}
