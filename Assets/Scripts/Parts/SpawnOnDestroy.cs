using UnityEngine;

namespace Game
{
    public class SpawnOnDestroy : MonoBehaviour
    {
        public GameObject spawnedObject;

        public float probability = 1.0f;

        void OnDestroy()
        {
            if (Random.value <= probability)
            {
                var newObject = Instantiate(spawnedObject, transform.position, Quaternion.identity);
                newObject.transform.SetParent(null);
            }
        }
    }
}
