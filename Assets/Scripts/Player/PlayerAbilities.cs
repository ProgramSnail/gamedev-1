using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class PlayerAbilities : MonoBehaviour
    {
        public float superweaponDuration = 10.0f;
        public int superweaponCost = 100;
        
        public int maxEnergy = 100;
        public float energyRegenerationSpeed = 0.1f;
            
        public int energy { get; private set; }

        public GameObject superweapon;

        private float _energyFractionalPart;

        private bool _superweaponActive;
        private float _superweaponLastActivationTime;
        
        private void Awake()
        {
            energy = 0;
        }

        private void Start()
        {
            _superweaponLastActivationTime = Time.time - superweaponDuration;
        }

        private void FixedUpdate()
        {
            if (_superweaponLastActivationTime + superweaponDuration > Time.time)
            {
                return;
            }

            if (_superweaponActive)
            {
                DeactivateAbility();
            }
            
            RegenerateEnergy();
            if (Input.GetKeyDown(KeyCode.Q) && energy >= superweaponCost)
            {
                energy -= superweaponCost;
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

        private void DeactivateAbility()
        {
            superweapon.SetActive(false); 
            _superweaponActive = false;
        }

        private void ActivateAbility()
        {
            if (superweapon.activeSelf)
            {
                return;
            }
            
            superweapon.SetActive(true);
            _superweaponLastActivationTime = Time.time;
            _superweaponActive = true;
        }

        public void AddEnergy(int energyAdded)
        {
            energy = Mathf.Min(energy + energyAdded, maxEnergy);
        }
    }
}