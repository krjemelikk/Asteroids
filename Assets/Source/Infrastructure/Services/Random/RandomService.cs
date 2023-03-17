﻿namespace Source.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        public int Next(int min, int max) =>
            UnityEngine.Random.Range(min, max);

        public float Next(float min, float max) =>
            UnityEngine.Random.Range(min, max);
    }
}