using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInMaze : MonoBehaviour
{
    // New Input System
    public InputSystem_Actions playerControls;
    private InputAction Move;
    public Transform spawnPos;

    // Normal movement code stuff
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool ConstantMovement = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        Move = playerControls.Player.Move;
        Move.Enable();
        transform.position = spawnPos.position;
    }
    private void OnDisable()
    {
        Move.Disable();
    }

    private void Update()
    {
        PlayerInputHandler.MoveInput = Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (PlayerInputHandler.MoveInput != Vector2.zero)
        {
            rb.linearVelocity = PlayerInputHandler.MoveInput + new Vector2(PlayerInputHandler.MoveInput.x, PlayerInputHandler.MoveInput.y) * moveSpeed;
        }
    }
}
