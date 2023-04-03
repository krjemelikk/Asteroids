using UnityEngine;

namespace Source.GameLogic
{
    public class ScreenWrap : MonoBehaviour
    {
        private float _maxX;
        private float _maxY;

        private float _minX;
        private float _minY;

        private float _offset = 0.5f;
        private float _teleportOffset = 0.25f;

        private void Awake()
        {
            var screen = Camera.main;
            UpdateScreenBounds(screen);
        }

        private void Update()
        {
            if (!InBounds())
            {
                var wrappedPosition = CalculateWrappedPosition(transform.position);
                Teleport(wrappedPosition);
            }
        }

        private void Teleport(Vector2 targetPosition) =>
            transform.position = targetPosition;

        private bool InBounds() =>
            InBoundsXAxis() && InBoundsYAxis();

        private bool InBoundsYAxis() =>
            transform.position.y > _minY &&
            transform.position.y < _maxY;

        private bool InBoundsXAxis() =>
            transform.position.x > _minX &&
            transform.position.x < _maxX;

        private void UpdateScreenBounds(Camera screen)
        {
            var screenHeight = screen.orthographicSize * 2;
            var screenWidth = screenHeight * screen.aspect;

            _maxY = screen.transform.position.y + screenHeight / 2 + _offset;
            _minY = screen.transform.position.y - screenHeight / 2 - _offset;

            _maxX = screen.transform.position.x + screenWidth / 2 + _offset;
            _minX = screen.transform.position.x - screenWidth / 2 - _offset;
        }

        private Vector2 CalculateWrappedPosition(Vector2 worldPosition)
        {
            var signVector = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

            var xBounds = InBoundsXAxis();
            var yBounds = InBoundsYAxis();

            if (!xBounds && !yBounds)
            {
                return
                    Vector2.Scale(worldPosition, -1 * Vector2.one) +
                    Vector2.Scale(new Vector2(_teleportOffset, _teleportOffset), signVector);
            }

            else if (!xBounds)
            {
                return new Vector2(-1 * worldPosition.x, worldPosition.y) +
                       new Vector2(_teleportOffset * signVector.x, 0);
            }

            else if (!yBounds)
            {
                return new Vector2(worldPosition.x, -1 * worldPosition.y) +
                       new Vector2(0, _teleportOffset * signVector.y);
            }

            return worldPosition;
        }
    }
}