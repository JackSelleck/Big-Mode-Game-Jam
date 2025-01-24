using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    /// <summary>
    /// This is where player inputs are initialised and made ready to be used by other scripts
    /// It is a static script and does not destroy on load, causing max to not destroy on load too since its attached
    /// </summary>
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset PlayerControls;

    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string Move = "Move";
    [SerializeField] private string Look = "Look";
    [SerializeField] private string Attack = "Attack";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction attackAction;

    public static Vector2 MoveInput { get; set; }
    public static Vector2 LookInput { get; set; }
    public static bool AttackInput { get; set; }

    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = PlayerControls.FindActionMap(actionMapName).FindAction(Move);
        lookAction = PlayerControls.FindActionMap(actionMapName).FindAction(Look);
        attackAction = PlayerControls.FindActionMap(actionMapName).FindAction(Attack);

        RegisterInputActions();
    }

    public void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        attackAction.performed += context => AttackInput = true;
        attackAction.canceled += context => AttackInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        attackAction.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) { moveAction.Disable(); }
        if (lookAction != null) { lookAction.Disable(); }
        if (attackAction != null) { attackAction.Disable(); }
    }

}