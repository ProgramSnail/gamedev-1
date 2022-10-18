using System;
using UnityEngine;

namespace Game
{
    public class DamageOnTrigger : MonoBehaviour
    {
        public int damage = 10;
        public String enemyTag = "Player";

        public bool destroyOnTrigger = true;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            var enemyBody = col.gameObject.GetComponent<ShipBody>();
            
            if (enemyBody != null && enemyBody.CompareTag(enemyTag))
            {
                enemyBody.Damage(damage);

                if (destroyOnTrigger)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
