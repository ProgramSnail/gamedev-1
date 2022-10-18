using System;
using UnityEngine;

namespace Game
{
    public abstract class PowerUp : MonoBehaviour
    {
        public String targetTag = "Player";

        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(targetTag))
            {
                Upgrade(col.gameObject);
                Destroy(gameObject);
            }
        }

        protected abstract void Upgrade(GameObject obj);
    }
}