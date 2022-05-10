using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Platform
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlatformCreator : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private PlatformItem itemPrefab;
        [SerializeField] private Vector2Int platformSize;
        [SerializeField, Range(0f, 1f)] private float itemSize = 1f;

        public void Create()
        {
            if (Application.isPlaying)
            {
                return;
            }

            if (platformSize.x <= 0
                || platformSize.y <= 0)
            {
                Debug.Log("The size of the platform horizontally or vertically " +
                          "must not be less than or equal to zero!");
                return;
            }

            RemovePlatform();
            var startPosition = new Vector3
            {
                x = itemSize - platformSize.x / 2f,
                z = itemSize - platformSize.y / 2f
            };

            var list = CreatePlatform(startPosition);
            ResetPlatformParam(list);
        }

        private void ResetPlatformParam(List<PlatformItem> itemsList)
        {
            var offsetVector = (itemsList.First().Position + itemsList.Last().Position) / 2f;
            var yOffset = itemSize / 2f;
            var position = transform.position;

            transform.position = new Vector3
            {
                x = position.x - offsetVector.x,
                y = -yOffset,
                z = position.z - offsetVector.z
            };

            if (boxCollider == null)
            {
                boxCollider = GetComponent<BoxCollider>();
            }

            boxCollider.size = new Vector3(platformSize.x * itemSize, itemSize, platformSize.y * itemSize);
            boxCollider.center = new Vector3
            {
                x = offsetVector.x,
                z = offsetVector.z
            };
        }

        private List<PlatformItem> CreatePlatform(Vector3 startPosition)
        {
            transform.position = Vector3.zero;
            var itemsList = new List<PlatformItem>();

            for (int z = 0; z < platformSize.y; z++)
            {
                for (int x = 0; x < platformSize.x; x++)
                {
                    var offsetVector = new Vector3
                    {
                        x = x * itemSize,
                        z = z * itemSize
                    };

                    var item = Instantiate(itemPrefab, transform);
                    item.transform.position = startPosition + offsetVector;
                    item.transform.localScale = Vector3.one * itemSize;
                    itemsList.Add(item);
                }
            }

            return itemsList;
        }

        private void RemovePlatform()
        {
            var childCount = transform.childCount;
            if(childCount == 0) return;
            
            var childeList = new List<GameObject>();
            for (int i = 0; i < childCount; i++)
            {
                childeList.Add(transform.GetChild(i).gameObject);
            }

            childeList.ForEach(DestroyImmediate);
        }
    }
}