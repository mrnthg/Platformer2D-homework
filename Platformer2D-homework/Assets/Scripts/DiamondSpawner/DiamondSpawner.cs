using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : Spawner
{
    [SerializeField] private Diamond _diamondPrefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
  
    private void Start()
    {
        SpawnObject(_diamondPrefab.gameObject, _pointsSpawn);
    }
}
