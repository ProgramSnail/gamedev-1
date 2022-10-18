using Game;
using UnityEngine;

namespace Game
{
    public class GiveScoreOnDestroy : MonoBehaviour
    {
        public int score = 1;

        private void OnDestroy()
        {
            var body = GetComponent<ShipBody>();
            if (body != null && body.strength <= 0)
            {
                FindObjectOfType<ScoreUpdater>().AddScore(score);
            }
        }
    }
}
