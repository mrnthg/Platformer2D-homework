using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    [SerializeField] private PlayerMover _palyer;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            _palyer.StartJump();
        }       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            _palyer.StopJump();
        }            
    }
}

