using UnityEngine;

namespace GameSubLogic
{
    public sealed class Decal : MonoBehaviour
    {
        public void DestroyDecal()
        {
            Destroy(gameObject);
        }
    }
}