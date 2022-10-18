using System;
using UnityEngine;

namespace Game
{
    public class ScorePowerUp : PowerUp
    {
        public int scoreAdded = 3;
        
        protected override void Upgrade(GameObject obj)
        {
            FindObjectOfType<ScoreUpdater>().AddScore(scoreAdded);
        }
    }
}
