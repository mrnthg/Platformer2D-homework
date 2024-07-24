using UnityEngine;

public class FlipObjectRotation : MonoBehaviour
{
    public void Flip(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
