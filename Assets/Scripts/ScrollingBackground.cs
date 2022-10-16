using UnityEngine;

namespace Game.GUI
{
    public class ScrollingBackground : MonoBehaviour
    {
        public float speed = 4.0f;

        private Vector3 _initPos;
        private float _sizeX;
        private float _sizeY;

        private Camera _mainCamera;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _mainCamera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _initPos = transform.position;
        }

        private void FixedUpdate()
        {
            UpdateSize();
            Move();
        }

        private void UpdateSize()
        {
            _sizeY = _mainCamera.orthographicSize;
            _sizeX = _mainCamera.aspect * _sizeY;
            _spriteRenderer.size = new Vector2(2 * _sizeX, 4 * _sizeY);
        }

        private void Move()
        {
            float newY = Mathf.Repeat(speed * Time.time, _sizeY);
            transform.position = _initPos + Vector3.down * newY;
        }
    }
}