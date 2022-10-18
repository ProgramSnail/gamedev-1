using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SpawnOnEnemyDestroyed : SpawnOnDestroy
    {
        protected override bool SpawnCondition()
        {
            return GetComponent<ShipBody>().strength <= 0;
        }
    }
}
