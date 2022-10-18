using Game.Utils;
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
            var tmpTransform = transform;
            
            var direction = tmpTransform.up;
            var newPosition = tmpTransform.position + direction * (speed * Time.deltaTime);
            tmpTransform.position = newPosition;

            CheckBoundaries();
        }

        private void CheckBoundaries()
        {
            if (!_cameraIsSet)
            {
                return;
            }
            
            if (!GameUtils.InCameraBoundaries(_mainCamera, transform.position))
            {
                Destroy(gameObject);
            }
        }
    }
}