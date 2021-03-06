using Assets.Scripts.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Platform
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlatformCreator : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private PlatformItem itemPrefab;
        [SerializeField] private List<Area> areas;

        [Header("> Platform Options <")]
        [SerializeField] private Vector2Int platformSize;
        [SerializeField] private Vector3 itemScale = Vector3.one;

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
                x = itemScale.x - platformSize.x / 2f,
                z = itemScale.z - platformSize.y / 2f
            };

            var list = CreatePlatform(startPosition);
            ResetPlatformParam(list);
            areas.Clear();
        }

#if UNITY_EDITOR
        public void CreateArea()
        {
            return;
            var items = new List<PlatformItem>();
            var list = Selection.gameObjects.ToList();

            foreach (var selectedObject in list)
            {
                var platformItem = selectedObject.GetComponent<PlatformItem>();
                if (platformItem) items.Add(platformItem);
            }

            var area = new Area();
            area.Init(items);
            areas.Add(area);
        }
#endif

        public Area GetArea(Enums.AreaType type)
        {
            return areas.Find(a => a.Type == type);
        }

        private void ResetPlatformParam(List<PlatformItem> itemsList)
        {
            var offsetVector = (itemsList.First().Position + itemsList.Last().Position) / 2f;
            var yOffset = itemScale.y / 2f;
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

            boxCollider.size = new Vector3
            {
                x = platformSize.x * itemScale.x,
                y = itemScale.y,
                z = platformSize.y * itemScale.z
            };

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
                        x = x * itemScale.x,
                        z = z * itemScale.z
                    };

                    var item = Instantiate(itemPrefab, transform);
                    item.transform.position = startPosition + offsetVector;
                    item.transform.localScale = itemScale;
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