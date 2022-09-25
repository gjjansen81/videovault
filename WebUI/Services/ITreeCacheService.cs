using VideoVault.WebApi;

namespace VideoVault.WebUI.Services
{
    public interface ITreeCacheService
    {
        MappingNodeDto DraggingNode { get; set; }
        MappingNodeDto DraggingParentNode { get; set; }
    }
}
