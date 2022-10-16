using UnityEngine;

namespace Game
{
    public class PlayerDefeated : MonoBehaviour
    {
        private void OnDestroy()
        {
            print("You lose(");
            Application.Quit();
        }
    }
}
