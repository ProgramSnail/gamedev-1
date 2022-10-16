using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

namespace Game
{
    public class ScoreUpdater : MonoBehaviour
    {
        private PlayerScore _playerScore;
        
        private void Start()
        {
            _playerScore = FindObjectOfType<PlayerScore>();
        }

        public void AddScore(int score)
        {
            _playerScore.score += score;
        }
    }
}
