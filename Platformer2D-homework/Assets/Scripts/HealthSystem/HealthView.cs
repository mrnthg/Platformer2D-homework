using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected HealthInstaller _healthSystem;

    public abstract HealthInstaller HealthSystem { get; }

    protected abstract void SetHealth();
}
