using UnityEngine;

namespace Game
{
    public class MoveDown : MonoBehaviour
    {
        public float speed = 1.0f;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            transform.position = transform.position + Vector3.down * (speed * Time.deltaTime);
            if (transform.position.y < -_mainCamera.orthographicSize)
            {
                Destroy(gameObject);
            }
        }
    }
}
