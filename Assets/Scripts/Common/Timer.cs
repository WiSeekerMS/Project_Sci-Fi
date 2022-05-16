using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class Timer : MonoBehaviour
    {
        public void StartTimer(Vector2 timeValues, Action action)
        {
            var time = UnityEngine.Random.Range(timeValues.x, timeValues.y);
            StopAllCoroutines();
            StartCoroutine(TimerCor(time, action));
        }

        public IEnumerator TimerCor(float time, Action action)
        {
            yield return new WaitForSecondsRealtime(time);
            action?.Invoke();
        }
    }
}
