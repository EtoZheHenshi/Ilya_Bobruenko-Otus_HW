using UnityEngine;

namespace GameSubLogic
{
    public class Decal : MonoBehaviour
    {
        public void DestroyDecal()
        {
            Destroy(gameObject);
        }
    }
}