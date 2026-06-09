using System.Collections;
using Code.GameLogic;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public sealed class LevelCountUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelCountText;
        [SerializeField] private float _activeTime;

        public IEnumerator ShowWnd(string text)
        {
            _levelCountText.text = text;
            gameObject.SetActive(true);
            
            yield return new WaitForSeconds(_activeTime);
            
            gameObject.SetActive(false);
        }
    }
}