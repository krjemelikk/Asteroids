using Source.GameLogic.Asteroids;
using Source.StaticData;

namespace Source.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        ShipData ForShip();
        BulletData ForBullet();
        AsteroidData ForAsteroid(AsteroidTypeId id);
        AsteroidSpawnerData ForSpawner();
    }
}