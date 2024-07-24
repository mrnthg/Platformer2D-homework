using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{   
    public Transform Detection()
    {
        Transform _playerPosition = null;

        if (_playerPosition == null)
        {
            _playerPosition = FindObjectOfType<PlayerMover>().GetComponent<Transform>();
        }

        return _playerPosition;
    }
}
