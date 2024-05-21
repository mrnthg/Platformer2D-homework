using UnityEngine;

public class DiamondCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Diamond component))
        {
            Destroy(component.gameObject);
        }
    }
}
