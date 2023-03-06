using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    class StaticDataService : IStaticDataService
    {
        private const string ShipDataPath = "StaticData/Ship"; 
        public ShipData ForShip() =>
            Resources.Load<ShipData>(ShipDataPath);
    }
}