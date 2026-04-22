using Audio;
using UnityEngine;

namespace Gameplay
{
    public sealed class Brick : MonoBehaviour
    {
        [SerializeField] private SoundData brickDestroySound;
        [SerializeField] private Renderer rend;
        
        public Color Color { set => rend.material.color = value; }

        public void Die()
        {
            AudioManager.Instance.PlaySound(brickDestroySound);
            RewardData.AddCoin();
            if (transform.parent.childCount <= 1)
            {
                LevelData.Win();
            }
            Destroy(gameObject);
        }
    }
}