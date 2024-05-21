using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    [SerializeField] private Diamond _diamondPrefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
  
    private void Start()
    {
        foreach (Transform pointSpawn in _pointsSpawn)
        {
            Diamond diamond = Instantiate(_diamondPrefab, pointSpawn.position, Quaternion.identity);
            diamond.transform.SetParent(transform);
        }
    }
}
