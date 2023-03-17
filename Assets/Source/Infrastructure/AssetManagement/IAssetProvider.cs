using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Source.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Task Initialize();
        Task<T> Load<T>(string address) where T : class;
        Task<T> Load<T>(AssetReference reference) where T : class;
        void CleanUp();
    }
}