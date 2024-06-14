using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private PlayerBattler _playerBattler;

    private void Awake()
    {
        _playerBattler = GetComponent<PlayerBattler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Diamond diamondComponent))
        {
            Destroy(diamondComponent.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Cherry cherryComponent))
        {
            _playerBattler.TakeHealthy(cherryComponent.HealthRrestore);
            Destroy(cherryComponent.gameObject);
        }
    }
}
