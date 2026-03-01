using System.Collections;
using UnityEngine;

namespace AidKit
{
    public class AidKitSpawner : MonoBehaviour
    {
        [SerializeField] private Vector2 spawnerSize;
        [SerializeField] private GameObject aidKitPrefab;

        void Start()
        {
            CreateAidKit();
        }

        public void StartTimerUntilCreateNewAidKid(float time)
        {
            StartCoroutine(Delay());

            IEnumerator Delay()
            {
                yield return new WaitForSeconds(time);
                CreateAidKit();
            }
        }

        private void CreateAidKit()
        {
            Instantiate(aidKitPrefab, 
                new Vector3(Random.Range(-(spawnerSize.x/2), spawnerSize.x + 1.0f), 
                    aidKitPrefab.transform.position.y, 
                    Random.Range(-(spawnerSize.y/2), spawnerSize.y + 1.0f)),
                Quaternion.identity, 
                transform);
        }
    }
}
