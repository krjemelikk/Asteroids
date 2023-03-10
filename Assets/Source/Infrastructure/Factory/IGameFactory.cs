using Source.GameLogic.Asteroids;
using UnityEngine;

namespace Source.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateShip(Vector3 at);
        GameObject CreateHUD();
        GameObject CreateAsteroid(AsteroidTypeId typeId, Vector3 position);
    }
}