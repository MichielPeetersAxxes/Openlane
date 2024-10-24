namespace Openlane.Shared.Interfaces
{
    public interface IBikeService
    {
        Task HandleBikeUpdate(string id);
        Task HandleBikeDeletion(string id);
    }
}
