using UnityEngine;

namespace Game
{
    public class PrefabPowerUp : PowerUp
    {
        public GameObject prefabAdded;
        
        protected override void Upgrade(GameObject obj)
        {
            var newInstance = Instantiate(prefabAdded, obj.transform);
            newInstance.transform.SetParent(obj.transform);
        }
    }
}
