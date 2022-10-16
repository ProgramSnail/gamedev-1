using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10;
        
        public Camera mainCamera
        {
            get => _mainCamera;

            set
            {
                _cameraIsSet = true;
                _mainCamera = value;
            }
        }

        private Camera _mainCamera;
        private bool _cameraIsSet;

        private Vector2 _topBoundaries = Vector2.positiveInfinity;
        private Vector2 _bottomBoundaries = Vector2.negativeInfinity;

        private void FixedUpdate()
        {
            var direction = transform.up;
            var newPosition = transform.position + direction * (speed * Time.deltaTime);
            transform.position = newPosition;

            CheckBoundaries();
        }

        private void CheckBoundaries()
        {
            if (!_cameraIsSet)
            {
                return;
            }

            if (Mathf.Abs(transform.position.y) > _mainCamera.orthographicSize ||
                Mathf.Abs(transform.position.x) > _mainCamera.orthographicSize * _mainCamera.aspect)
            {
                Destroy(gameObject);
            }
        }
    }
}