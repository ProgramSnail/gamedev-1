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
    }
}