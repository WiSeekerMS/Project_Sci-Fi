using UnityEngine;

namespace Assets.Scripts
{
    public class Bonus : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            print("OnTrigger!");
            Destroy(gameObject);
        }
    }
}
