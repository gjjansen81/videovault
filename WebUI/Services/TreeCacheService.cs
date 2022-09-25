using VideoVault.WebApi;

namespace VideoVault.WebUI.Services
{
    public class TreeCacheService : ITreeCacheService
    {
        public MappingNodeDto DraggingNode { get; set; } = null;
        public MappingNodeDto DraggingParentNode { get; set; } = null;
    }
}
