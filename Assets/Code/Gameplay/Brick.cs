using Audio;
using UnityEngine;

namespace Gameplay
{
    public sealed class Brick : MonoBehaviour
    {
        [SerializeField] private SoundData brickDestroySound;
        
        public void Die()
        {
            AudioManager.Instance.PlaySound(brickDestroySound);
            Destroy(gameObject);
        }
    }
}