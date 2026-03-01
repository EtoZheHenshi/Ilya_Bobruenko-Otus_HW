using System;
using System.Collections;
using UnityEngine;

namespace AidKit
{
    public class AidKit : MonoBehaviour
    {
        private AidKitSpawner _spawner;

        private void Start()
        {
            _spawner = GetComponentInParent(typeof(AidKitSpawner)) as AidKitSpawner;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Логика отхила если бы был класс игрока
                Destroy();
            }
        }

        private void Destroy()
        {
            _spawner.StartTimerUntilCreateNewAidKid(3.0f);
            Destroy(gameObject);
        }
    }
}