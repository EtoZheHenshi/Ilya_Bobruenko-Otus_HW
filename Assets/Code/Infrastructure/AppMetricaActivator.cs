using System.Collections.Generic;
using Code.PlayerLogic;
using Io.AppMetrica;
using UnityEngine;

namespace Code.Infrastructure
{
    public static class AppMetricaActivator {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Activate() {
            AppMetrica.Activate(new AppMetricaConfig("fe8407fc-c076-413b-86a4-f8a4e2ab994d") {
                FirstActivationAsUpdate = !IsFirstLaunch(),
            });
        }

        private static bool IsFirstLaunch() {
            // Implement logic to detect whether the app is opening for the first time.
            // For example, you can check for files (settings, databases, and so on),
            // which the app creates on its first launch.
            return true;
        }

        public static void SendLevelResult()
        {
            LevelResultData levelResultData = new LevelResultData(Player.Instance.CurrentLvl, Player.Instance.KilledEnemies);
            string json = JsonUtility.ToJson(levelResultData);

            AppMetrica.ReportEvent("LevelResult", json);
            AppMetrica.SendEventsBuffer();
            Debug.Log(json);
        }

        private class LevelResultData
        {
            public int PlayerLvl;
            public int KilledEnemies;

            public LevelResultData(int playerLvl, int killedEnemies)
            {
                PlayerLvl = playerLvl;
                KilledEnemies = killedEnemies;
            }
        }
    }
}