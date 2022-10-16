using UnityEngine;

namespace Game
{
    public class ShipGun : MonoBehaviour
    {

        public Bullet bullet;

        public float timeout = 2.0f;

        private float _lastShootTime;

        private SpawnPoint[] _spawnPoints;

        private Camera _mainCamera;
        
        private void Start()
        {
            _mainCamera = Camera.main;
            
            _lastShootTime = Time.time - timeout;
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        }

        public void Fire()
        {
            if (Time.time - _lastShootTime < timeout)
            {
                return;
            }
            
            InstantiateBullets();

            _lastShootTime = Time.time;
        }

        private void InstantiateBullets()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                var bulletInstance = Instantiate(bullet, spawnPoint.transform);
                bulletInstance.mainCamera = _mainCamera;
                bulletInstance.transform.SetParent(null);
            }
        }
    }
}