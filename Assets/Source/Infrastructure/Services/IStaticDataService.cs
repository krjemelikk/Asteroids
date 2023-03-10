using Source.GameLogic.Asteroids;
using Source.StaticData;

namespace Source.Infrastructure.Services
{
    public interface IStaticDataService
    { 
        ShipData ForShip();
        BulletData ForBullet();
        AsteroidData ForAsteroid(AsteroidTypeId id);
    }
}