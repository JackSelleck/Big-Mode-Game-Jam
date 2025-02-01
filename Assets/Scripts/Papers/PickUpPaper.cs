using UnityEngine;

public class PickUpPaper : MonoBehaviour
{
    public LimitPapersHeld LimitPapersHeld;
    public Transform player;
    private bool followPlayer;
    private SpriteRenderer spriteRenderer;
    private bool waitToStopBug;

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
        if (collision.CompareTag("Player") && LimitPapersHeld.papersHeld == 0)
        {
            followPlayer = true;
            LimitPapersHeld.papersHeld++;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Computer") && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Paper Destroyed");
            gameObject.SetActive(false);
        }
    }
}
