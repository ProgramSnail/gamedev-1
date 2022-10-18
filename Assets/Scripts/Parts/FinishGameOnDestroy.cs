using System;
using UnityEngine;

namespace Game
{
    public class FinishGameOnDestroy : MonoBehaviour
    {
        public bool lose = true;
        
        private GameStateManager _gameStateManager;
        
        private void Start()
        {
            _gameStateManager = FindObjectOfType<GameStateManager>();
        }

        private void OnDestroy()
        {
            if (lose)
            {
                _gameStateManager.Lose();
            }
            else
            {
                _gameStateManager.Win();
            } 
        }
    }
}
