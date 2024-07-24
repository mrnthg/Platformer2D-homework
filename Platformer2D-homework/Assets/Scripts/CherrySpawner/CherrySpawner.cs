using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : Spawner
{
    [SerializeField] private Cherry _cherryPrefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();

    private void Start()
    {
        SpawnObject(_cherryPrefab.gameObject, _pointsSpawn); 
    }
}
