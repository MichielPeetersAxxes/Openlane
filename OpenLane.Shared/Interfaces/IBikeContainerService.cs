namespace Openlane.Shared.Interfaces
{
    public interface IBikeContainerService
    {
        Task HandleContainerPublish(string id);
        Task HandleContainerDeletion(string id);
    }
}
