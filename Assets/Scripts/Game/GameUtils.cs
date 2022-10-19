using UnityEngine;

namespace Game.Utils
{
    public static class GameUtils
    {
        public static bool InCameraBoundaries(Camera camera, Vector3 position)
        {
            return (Mathf.Abs(position.y) <= camera.orthographicSize &&
                    Mathf.Abs(position.x) <= camera.orthographicSize * camera.aspect);
        }

        public static GameObject ChooseRandomObject(GameObject[] gameObjects, float[] probabilities)
        {
            float randomValue = Random.value;

            GameObject result = null;
            
            for (int j = 0; j < probabilities.Length; ++j)
            {
                randomValue -= probabilities[j];
                    
                if (randomValue <= 0)
                {
                    result = gameObjects[j];
                    break;
                }
            }

            return result;
        }
    }
}