using UnityEngine;

namespace Source.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateShip(Vector3 at);
    }
}