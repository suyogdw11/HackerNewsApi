using System.Collections.Generic;
using System.Threading.Tasks;
using HackerNewsApi.Model;

namespace HackerNewsApi.Services{
    public interface IHackerNewsService
    {
        Task<IEnumerable<OutputStory>> GetBestOrderedStories(bool disableCache);

        void CleanCache();
    }
}