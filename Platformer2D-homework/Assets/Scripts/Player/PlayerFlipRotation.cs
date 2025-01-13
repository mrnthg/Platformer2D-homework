using UnityEngine;

public class PlayerFlipRotation : MonoBehaviour
{
    [SerializeField] private SmoothBarHealthDisplay _healthDisplay;

    private float _rotationY;

    public void Flip(float value)
    {
        _rotationY = value > 0 ? 0 : 180;

        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
        _healthDisplay.transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
