using Game.Utils;
using UnityEngine;

namespace Game
{
    public class SpawnOnDestroy : MonoBehaviour
    {
        public GameObject[] objectsToSpawn;

        public float generateAnyObjectProbability = 1.0f;
        
        public float[] probabilities;

        private void OnDestroy()
        {
            if (SpawnCondition() && Random.value < generateAnyObjectProbability)
            {
                FindObjectOfType<InstanceGenerator>().MakeInstance(
                    GameUtils.ChooseRandomObject(objectsToSpawn, probabilities), 
                    transform.position, 
                    Quaternion.identity);
            }
        }

        protected virtual bool SpawnCondition()
        {
            return true;
        }
    }
}
