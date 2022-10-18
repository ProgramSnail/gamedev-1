using UnityEngine;

namespace Game
{
    public class PlayerGuns : Guns
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             Shoot();
            }
        }
    }
}