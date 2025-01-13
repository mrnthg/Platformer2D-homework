using UnityEngine;

public class PlayerFlipRotation : MonoBehaviour
{
    [SerializeField] private SmoothBarHealthDisplay _healthDisplay;

    public void FlipPlayerRotation(float value)
    {
        if (value > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            _healthDisplay.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (value < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            _healthDisplay.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
