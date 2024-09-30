using System;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private Transform[] itemSpawnPoints;

        [SerializeField] private GameObject powerUpItemFactory;
        [SerializeField] private GameObject speedUpItemFactory;
        [SerializeField] private GameObject ultimateItemFactory;

        private List<Timer> _itemTimers;

        private void Start()
        {
            _itemTimers = new()
            {
                new Timer(3, 15, () => CreateItem(powerUpItemFactory)),
                new Timer(5, 24, () => CreateItem(speedUpItemFactory)),
                new Timer(36, 36, () => CreateItem(ultimateItemFactory))
            };
        }

        private void Update()
        {
            _itemTimers.ForEach(timer => timer.Update());
        }

        private void CreateItem(GameObject item)
        {
            var createdItem = Instantiate(item);
            createdItem.transform.position = itemSpawnPoints.Choice().position;
        }
    }
}