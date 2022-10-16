using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GUI
{
    public class PlayerGUI : MonoBehaviour
    {
        private int _cachedStrength;
        private int _cachedMaxStrength;
        
        private int _cachedEnergy;
        private int _cachedMaxEnergy;

        private int _cachedScore;
        
        private ShipBody _shipBody;
        private PlayerAbilities _playerAbilities;
        private PlayerScore _playerScore;

        private Slider _healthBar;
        private Slider _energyBar;
        private TextMeshProUGUI _scoreText;

        private void Start()
        {
            _shipBody = GetComponent<ShipBody>();
            _playerAbilities = GetComponent<PlayerAbilities>();
            _playerScore = GetComponentInChildren<PlayerScore>();
            
            _healthBar = GetComponentInChildren<HealthBar>().GetComponent<Slider>();
            _energyBar = GetComponentInChildren<EnergyBar>().GetComponent<Slider>();
            _scoreText = _playerScore.GetComponent<TextMeshProUGUI>();

            UpdateStrength();
            UpdateEnergy();
            UpdatePlayerScore();
        }

        private void Update()
        {
            if (_shipBody.strength != _cachedStrength || _shipBody.maxStrength != _cachedMaxStrength)
            {   
                UpdateStrength();
            }
            
            if (_playerAbilities.energy != _cachedEnergy || _playerAbilities.maxEnergy != _cachedMaxEnergy)
            {
                UpdateEnergy();
            }

            if (_playerScore.score != _cachedScore)
            {
                UpdatePlayerScore();
            }
        }
        
        private void UpdateStrength()
        {
            _healthBar.maxValue = _cachedMaxStrength = _shipBody.maxStrength;
            _healthBar.value = _cachedStrength = _shipBody.strength;
        }

        private void UpdateEnergy()
        {
            _energyBar.maxValue = _cachedMaxEnergy = _playerAbilities.maxEnergy;
            _energyBar.value = _cachedEnergy = _playerAbilities.energy; 
        }

        private void UpdatePlayerScore()
        { 
            _scoreText.text = (_cachedScore = _playerScore.score).ToString();
        }
    }
}