using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected HealthSystem _healthSystem;

    public abstract HealthSystem HealthSystem { get; }

    protected abstract void SetHealth();
}
