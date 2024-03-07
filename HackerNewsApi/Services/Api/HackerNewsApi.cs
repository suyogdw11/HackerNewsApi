using System.Threading.Tasks;
using HackerNewsApi.Model;
using Refit;

namespace HackerNewsApi.Services.Api{
    public interface IHackerNewsApi{
        [Get("/v0/beststories.json")]
        Task<int[]> GetBestStories();

        [Get("/v0/item/{id}.json")]
        Task<Story> GetStoryById(int id);
    }
}