using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prefab;

        protected T GetNewInstance(Transform parent)
        {
            return Instantiate(prefab, parent);
        }
    }
}
