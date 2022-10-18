using UnityEngine;

namespace Game
{
    public abstract class ObjectGenerator : MonoBehaviour
    {
        public GameObject[] instantiatedObjects;
        public float[] instantiatedObjectsProbabilities;
        
        public float batchTimeout = 4.0f;
        public int batchMinSize = 2;
        public int batchMaxSize = 6;

        private float _lastBatchTime;

        protected virtual void Start()
        {
            _lastBatchTime = Time.time;
        }

        protected void Update()
        {
            if (Time.time - _lastBatchTime < batchTimeout)
            {
                return;
            }

            GenerateBatch();
            _lastBatchTime = Time.time;
        }

        protected abstract void GenerateBatch();

        protected GameObject[] chooseObjects(int batchSize)
        {
            var result = new GameObject[batchSize];
            
            for (int i = 0; i < batchSize; ++i)
            {
                float randomValue = Random.value;
                
                for (int j = 0; j < instantiatedObjectsProbabilities.Length; ++j)
                {
                    randomValue -= instantiatedObjectsProbabilities[j];
                    
                    if (randomValue <= 0)
                    {
                        result[i] = instantiatedObjects[j];
                        break;
                    }
                }
            }

            return result;
        }
    }
}