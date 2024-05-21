using UnityEngine;

public class DiamondController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMover component))
        {
            Destroy(gameObject);
        }
    }
}
