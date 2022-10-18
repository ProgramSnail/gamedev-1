using System;
using UnityEngine;

namespace Game
{
    public class PlayerAbilities : MonoBehaviour
    {
        public int maxEnergy = 100;
        public float energyRegenerationSpeed = 0.1f;
        public int energy { get; private set; }

        private float _energyFractionalPart;

        private void Awake()
        {
            energy = 0; // maxEnergy;
        }

        private void FixedUpdate()
        {
            RegenerateEnergy();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ActivateAbility();
            }
        }

        private void RegenerateEnergy()
        {
            _energyFractionalPart += Time.deltaTime * energyRegenerationSpeed;
            
            int energyCeilAdded = Mathf.CeilToInt(_energyFractionalPart);
            energy = Mathf.Min(energy + energyCeilAdded, maxEnergy);
            _energyFractionalPart -= energyCeilAdded;
        }

        private void ActivateAbility()
        {
            throw new NotImplementedException();
        }

        public void AddEnergy(int energyAdded)
        {
            energy = Mathf.Min(energy + energyAdded, maxEnergy);
        }
    }
}