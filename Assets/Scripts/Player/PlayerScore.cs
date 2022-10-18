using TMPro;
using UnityEngine;

namespace Game
{
    public class PlayerScore : MonoBehaviour
    {
        public int score;

        private int _cachedScore;
        
        private TextMeshProUGUI _text;
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();

            UpdateText();
        }
        
        private void Update()
        {
            if (score != _cachedScore)
            {
                UpdateText();
            }
        }
        
        private void UpdateText()
        { 
            _text.text = (_cachedScore = score).ToString();
        }
    }
}