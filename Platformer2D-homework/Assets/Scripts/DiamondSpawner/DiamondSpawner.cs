using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    [SerializeField] private Diamond _diamondPrefabs;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
  
    void Start()
    {
        foreach (Transform pointSpawn in _pointsSpawn)
        {
            Diamond diamond = Instantiate(_diamondPrefabs, pointSpawn.position, Quaternion.identity);
            diamond.transform.SetParent(transform);
        }
    }
}
