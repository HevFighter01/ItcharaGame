using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    [SerializeField] private float movingSpeed = 5f;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        //inputVector = inputVector.normalized;                             // �������� �� ����� ��� ��� � ��� � ��� (0,71; 0,71)
        rb.MovePosition(rb.position + inputVector * (Time.fixedDeltaTime * movingSpeed));
        //Debug.Log(inputVector);
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed) // ��� �� ���
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
            
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
