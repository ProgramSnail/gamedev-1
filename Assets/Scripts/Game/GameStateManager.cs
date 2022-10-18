using UnityEngine;

namespace Game
{
    public class GameStateManager : MonoBehaviour
    {
        private PlayerTag _player;
        private WinGameTag _winGame;
        private LoseGameTag _loseGame;

        private bool _isPlayerWon;
        private bool _isPlayerLose;
        
        private void Start()
        {
            _player = FindObjectOfType<PlayerTag>();
            
            _winGame = GetComponentInChildren<WinGameTag>();
            _loseGame = GetComponentInChildren<LoseGameTag>();
        }

        private void Update()
        {
            if (_isPlayerWon || _isPlayerLose && Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }

        public void Win()
        {
            if (_isPlayerLose)
            {
                return;
            }
            
            _isPlayerWon = true;

            if (_winGame != null)
            {
                _winGame.GetComponent<Canvas>().enabled = true;
            }

            if (_player != null)
            {
                _player.gameObject.SetActive(false);
            }
        }

        public void Lose()
        {
            if (_isPlayerWon)
            {
                return;
            }
            
            _isPlayerLose = true;

            if (_loseGame != null)
            {
                _loseGame.GetComponent<Canvas>().enabled = true;
            }

            if (_player != null)
            {
                _player.gameObject.SetActive(false);
            }
        }
    }
}