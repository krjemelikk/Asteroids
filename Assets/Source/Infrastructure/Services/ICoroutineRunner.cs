using System.Collections;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}