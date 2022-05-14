using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class Timer : MonoBehaviour
    {
        private float time;

        public void Init(float time)
        {
            this.time = time;
        }

        public void StartTimer(Action action)
        {
            StopAllCoroutines();
            StartCoroutine(TimerCor(action));
        }

        private IEnumerator TimerCor(Action action)
        {
            yield return new WaitForSecondsRealtime(time);
            action?.Invoke();
        }
    }
}
