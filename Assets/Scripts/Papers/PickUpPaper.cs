using UnityEngine;

public class PickUpPaper : MonoBehaviour
{
    public Transform player;
    private bool followPlayer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (followPlayer == true)
        {
            transform.position = player.position;
            //spriteRenderer.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followPlayer = true;
        }
    }
}
