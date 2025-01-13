using UnityEngine;

public class EnemyFlipRotation : MonoBehaviour
{
    [SerializeField] private SmoothBarHealthDisplay _healthDisplay;

    private float _rotationY;

    public void Flip(Transform target)
    {
        _rotationY = target.position.x < transform.position.x ? 0 : 180;

        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
        _healthDisplay.transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
