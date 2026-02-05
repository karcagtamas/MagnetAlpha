using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed = 6f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
        moveAction.action.performed += OnMove;        
        moveAction.action.canceled += OnMove;        
    }

    void OnDisable()
    {
        moveAction.action.performed -= OnMove;
        moveAction.action.canceled -= OnMove;
        moveAction.action.Disable();
    }

    void Update()
    {
        var moveDirection = new Vector2(input.x * speed, input.y * speed);
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
}
