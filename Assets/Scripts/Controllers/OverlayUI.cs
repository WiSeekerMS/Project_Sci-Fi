using Assets.Scripts.BaseClasses;
using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class OverlayUI : UIController, IHealthBar, IBonusCounter, IEnemyCounter
    {
        [SerializeField] private TextMeshProUGUI hpCounterText;
        [SerializeField] private TextMeshProUGUI bonusCounterText;
        [SerializeField] private TextMeshProUGUI enemyCCounterText;
        
        public int CurrentHPCount { get; private set; }
        public int CurrentBonusCount { get; private set; }
        public int CurrentEnemyCount { get; private set; }


        public void SetHealt(int value)
        {
            CurrentHPCount = value;
            if (hpCounterText) 
                hpCounterText.text = value.ToString();
        }

        public void ChangeBonusCount(int value)
        {
            CurrentBonusCount = value;
            if (bonusCounterText)
                bonusCounterText.text = value.ToString();
        }

        public void ChangeEnemyCount(int value)
        {
            CurrentEnemyCount = value;
            if (enemyCCounterText)
                enemyCCounterText.text = value.ToString();
        }
    }
}
