using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    [SerializeField] private Cherry _cherryPrefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();

    private void Start()
    {
        foreach (Transform pointSpawn in _pointsSpawn)
        {
            Cherry cherry = Instantiate(_cherryPrefab, pointSpawn.position, Quaternion.identity);
            cherry.transform.SetParent(transform);
        }
    }
}
