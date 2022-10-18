using UnityEngine;

namespace Game
{
    public class PlayerEngine : MonoBehaviour
    {
        public float maxSpeed;
        public float increaseSpeedAcceleration;
        public float decreaseSpeedAcceleration;

        private Vector3 _speed;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            MoveStep();
        }

        private void MoveStep()
        {
            AccelerateOn(Input.GetAxisRaw("Vertical") < 0, Vector3.down);
            AccelerateOn(Input.GetAxisRaw("Vertical") > 0, Vector3.up);
            AccelerateOn(Input.GetAxisRaw("Horizontal") < 0, Vector3.left);
            AccelerateOn(Input.GetAxisRaw("Horizontal") > 0, Vector3.right);

            Move();

            CheckBounds();
        }

        private void AccelerateOn(bool accelerate, Vector3 direction)
        {
            Vector3 value = direction * Time.deltaTime;

            if (accelerate)
            {
                IncreaseSpeedBy(value * increaseSpeedAcceleration);
            }
            else
            {
                DecreaseSpeedBy(value * decreaseSpeedAcceleration);
            }
        }

        private void Move()
        {
            transform.position += _speed * Time.deltaTime;
        }

        private void CheckBounds()
        {
            float yBound = _mainCamera.orthographicSize;
            float xBound = _mainCamera.aspect * yBound;

            var newPos = transform.position;

            float ToBound(float pos, float bound) => Mathf.Max(Mathf.Min(pos, bound), -bound);

            newPos.y = ToBound(newPos.y, yBound);
            newPos.x = ToBound(newPos.x, xBound);

            transform.position = newPos;
        }

        private void IncreaseSpeedBy(Vector3 value)
        {
            _speed += value;

            if (_speed.magnitude > maxSpeed)
            {
                _speed *= maxSpeed / _speed.magnitude;
            }
        }

        private void DecreaseSpeedBy(Vector3 value)
        {
            float DecreaseComponent(float component, float change) =>
                component * (-change) < 0
                    ? (component > 0 ? Mathf.Max(component - change, 0) 
                        : Mathf.Min(component - change, 0))
                    : component;

            _speed = new Vector3(
                DecreaseComponent(_speed.x, value.x), 
                DecreaseComponent(_speed.y, value.y),
                DecreaseComponent(_speed.z, value.z));
        }
    }
}