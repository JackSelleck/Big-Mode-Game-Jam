using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public Transform RespawnPosition;
    public Transform Ball;
    private void OnEnable()
    {
        Ball.position = RespawnPosition.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball.position = RespawnPosition.position;
        }
    }
}
