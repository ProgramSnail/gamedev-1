using UnityEngine;

namespace Game
{
    public class PlayerGuns : Guns
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }
        }
    }
}