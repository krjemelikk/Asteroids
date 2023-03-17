using System.Threading.Tasks;

namespace Source.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Task Initialize();
        Task<T> Load<T>(string address) where T : class;
        void CleanUp();
    }
}