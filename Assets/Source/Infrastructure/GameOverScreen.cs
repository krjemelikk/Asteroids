using UnityEngine;

namespace Source.Infrastructure
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Transform _screen;

        public void Show() =>
            _screen.gameObject.SetActive(true);

        public void Hide() =>
            _screen.gameObject.SetActive(false);
    }
}