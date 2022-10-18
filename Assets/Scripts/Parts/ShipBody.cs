using UnityEngine;

namespace Game
{
    public class ShipBody : MonoBehaviour
    {
        public bool damageable = true;
        
        public int maxStrength = 100;
        public int strength { get; private set; }

        private DamageReaction _damageReaction;
        
        private void Awake()
        {
            strength = maxStrength;
        }

        private void Start()
        {
            _damageReaction = GetComponent<DamageReaction>();
        }

        public void Damage(int damage)
        {
            if (!damageable)
            {
                return;
            }
            
            strength -= damage;

            if (strength <= 0)
            {
                Destroy(gameObject);
            }

            // TODO: change on event
            if (_damageReaction != null)
            {
                _damageReaction.OnDamage();
            }
        }

        public void AddStrength(int strengthAdded)
        {
            strength = Mathf.Min(strength + strengthAdded, maxStrength);
        }
    }
}