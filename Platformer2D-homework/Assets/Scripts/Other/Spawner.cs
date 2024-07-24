using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected void SpawnObject(GameObject gameObject, List<Transform> pointsSpawn)
    {
        foreach (Transform pointSpawn in pointsSpawn)
        {
            GameObject newObject = Instantiate(gameObject, pointSpawn.position, Quaternion.identity);
            newObject.transform.SetParent(transform);
        }
    }
}
