using System;
using UnityEngine;

namespace Game
{
    public class EnergyPowerUp : PowerUp
    {
        public int energyAdded = 50;
        
        protected override void Upgrade(GameObject obj)
        {
            var playerAbilities = obj.GetComponent<PlayerAbilities>();
            if (playerAbilities != null)
            {
                playerAbilities.AddEnergy(energyAdded);
            }
        }
    }
}