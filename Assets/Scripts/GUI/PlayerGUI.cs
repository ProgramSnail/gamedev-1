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

        
        private ShipBody _shipBody;
        private PlayerAbilities _playerAbilities;

        private Slider _healthBar;
        private Slider _energyBar;

        private void Start()
        {
            _shipBody = GetComponent<ShipBody>();
            _playerAbilities = GetComponent<PlayerAbilities>();
            
            _healthBar = GetComponentInChildren<HealthBarTag>().GetComponent<Slider>();
            _energyBar = GetComponentInChildren<EnergyBarTag>().GetComponent<Slider>();

            UpdateStrength();
            UpdateEnergy();
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
    }
}