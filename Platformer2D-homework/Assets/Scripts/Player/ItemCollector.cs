using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Diamond diamondComponent))
        {
            Destroy(diamondComponent.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Cherry cherryComponent))
        {
            GetComponent<PlayerBattler>().TakeHealthy(cherryComponent.HealthRrestore);
            Destroy(cherryComponent.gameObject);
        }
    }
}
