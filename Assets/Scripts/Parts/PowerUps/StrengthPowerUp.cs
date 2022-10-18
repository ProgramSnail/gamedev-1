using System;
using UnityEngine;

namespace Game
{
    public class StrengthPowerUp : PowerUp
    {
        public int strengthAdded = 30;
        
        protected override void Upgrade(GameObject obj)
        {
            var shipBody = obj.GetComponent<ShipBody>();
            if (shipBody != null)
            {
                shipBody.AddStrength(strengthAdded);
            }
        }
    }
}
