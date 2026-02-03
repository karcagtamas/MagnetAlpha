using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float minX = -3f;
    [SerializeField] private float maxX = 3f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    private float horizontalInput;

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
        var position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
}
