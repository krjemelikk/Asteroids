using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Source.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

        public async Task Initialize()
        {
            var handle = Addressables.InitializeAsync();
            await handle.Task;
        }

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_completedCache.TryGetValue(address, out AsyncOperationHandle cacheHandle))
                return cacheHandle.Result as T;

            var handle = Addressables.LoadAssetAsync<T>(address);

            return await RunWithCacheOnComplete(handle, address);
        }

        public async Task<T> Load<T>(AssetReference reference) where T : class
        {
            if (_completedCache.TryGetValue(reference.AssetGUID, out AsyncOperationHandle cacheHandle))
                return cacheHandle.Result as T;

            var handle = Addressables.LoadAssetAsync<T>(reference);

            return await RunWithCacheOnComplete(handle, reference.AssetGUID);
        }

        public void CleanUp()
        {
            foreach (var list in _handles.Values)
            {
                foreach (var handle in list)
                {
                    Addressables.Release(handle);
                }
            }

            _completedCache.Clear();
            _handles.Clear();
        }

        private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string key) where T : class
        {
            handle.Completed += completeHandle => { _completedCache[key] = completeHandle; };

            AddHandle<T>(key, handle);

            return await handle.Task;
        }

        private void AddHandle<T>(string key, AsyncOperationHandle handle) where T : class
        {
            if (_handles.TryGetValue(key, out List<AsyncOperationHandle> handles))
                handles.Add(handle);

            else
                _handles[key] = new List<AsyncOperationHandle>() { handle };
        }
    }
}