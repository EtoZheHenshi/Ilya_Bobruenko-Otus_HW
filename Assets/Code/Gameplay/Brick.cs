using UnityEngine;

namespace Gameplay
{
    public sealed class Brick : MonoBehaviour
    {
        public void Die()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}