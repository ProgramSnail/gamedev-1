using UnityEngine;

namespace Game
{
    public class Guns : MonoBehaviour
    {

        protected ShipGun[] _guns;

        protected void Start()
        {
            _guns = GetComponentsInChildren<ShipGun>();
        }

        public void Shoot()
        {
            foreach (var gun in _guns)
            {
                gun.Fire();
            }
        }
    }
}