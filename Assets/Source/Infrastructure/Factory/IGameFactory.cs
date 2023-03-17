using System.Threading.Tasks;
using UnityEngine;

namespace Source.Infrastructure.Factory
{
    public interface IGameFactory
    {
        Task<GameObject> CreateShip(Vector3 at);
        Task<GameObject> CreateHUD();
    }
}