using UnityEngine;

namespace Game
{
    public class ObjectPointGenerator : ObjectGenerator
    {
        private SpawnPoint[] _spawnPoints;
        
        protected override void Start()
        {
            base.Start();
            
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
            batchMinSize = Mathf.Min(batchMinSize, _spawnPoints.Length);
            batchMaxSize = Mathf.Min(batchMaxSize, _spawnPoints.Length + 1);
        }

        protected override void GenerateBatch()
        {
            int batchSize = Random.Range(batchMinSize, batchMaxSize);

            bool[] chosenPoints = choosePoints(batchSize);

            GameObject[] chosenObjects = chooseObjects(batchSize);

            for (int i = 0, k = 0; i < chosenPoints.Length && k < batchSize; ++i)
            {
                if (chosenPoints[i])
                {
                    var newObject = Instantiate(chosenObjects[k], _spawnPoints[i].transform);
                    newObject.transform.SetParent(null);
                    ++k;
                }
            }
        }

        private bool[] choosePoints(int batchSize)
        {
            bool[] usedPoints = new bool[_spawnPoints.Length];
            for (int i = 0; i < batchSize; ++i)
            {
                int pos = Random.Range(0, _spawnPoints.Length - i);
                for (int j = 0; j < usedPoints.Length; ++j)
                {
                    if (usedPoints[j])
                    {
                        continue;
                    }
                    
                    if (pos == 0)
                    {
                        usedPoints[j] = true;
                    }
                    --pos;
                }
            }

            return usedPoints;
        }
    }
}
