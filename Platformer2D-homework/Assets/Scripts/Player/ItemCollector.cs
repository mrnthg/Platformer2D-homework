using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Diamond diamondComponent))
        {
            Destroy(diamondComponent.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Cherry cherryComponent))
        {
            _healthSystem.AddHealthPoint(cherryComponent.HealthRrestore);
            Destroy(cherryComponent.gameObject);
        }
    }
}
