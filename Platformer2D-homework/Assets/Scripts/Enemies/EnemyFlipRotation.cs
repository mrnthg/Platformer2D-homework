using UnityEngine;

public class EnemyFlipRotation : MonoBehaviour
{
    [SerializeField] private SmoothBarHealthDisplay _healthDisplay;

    public void Flip(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _healthDisplay.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
            _healthDisplay.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
