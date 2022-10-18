using UnityEngine;

namespace Game
{
    public class SpawnOnDestroy : MonoBehaviour
    {
        public GameObject objectToSpawn;

        public float probability = 1.0f;

        private void OnDestroy()
        {
            if (SpawnCondition() && Random.value <= probability)
            {
                FindObjectOfType<InstanceGenerator>().MakeInstance(objectToSpawn, transform.position, Quaternion.identity);
            }
        }

        protected virtual bool SpawnCondition()
        {
            return true;
        }
    }
}
