using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float speed = 12.0f;
    public bool isMoving;
    CharacterController controller;

    [Header("Gravity")]
    public float groundDistance = 0.2f;
    public Transform groundCheck;
    public float gravity = -9.81f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;

    [Header("Crouch")]
    public float crouchHeight = 0.5f;
    public float crouchTransitionSpeed = 10f;
    public Transform lanternTransform;
    public Transform bucketTransform;
    public bool isCrouching => standingHeight - currentHeight > 0.1f;
    float standingHeight;
    float currentHeight;
    Vector3 initialCameraPos;
    Vector3 initialLanternPos;
    Vector3 initialBucketPos;

    [Header("Look")]
    public float mouseSensitivity = 100.0f;
    public Camera cam;
    float xRotation = 0.0f;

    PuzzleScript puzzleScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        standingHeight = currentHeight = controller.height;
        initialCameraPos = cam.transform.localPosition;
        initialLanternPos = lanternTransform.localPosition;
        initialBucketPos = bucketTransform.localPosition;

        puzzleScript = GetComponent<PuzzleScript>();
    }

    void Update()
    {
        Look();
        Move();
        Gravity();
        Crouch();
    }

    void Move()
    {
        Vector2 movementAxis = InputSystem.actions["Move"].ReadValue<Vector2>();

        if (movementAxis == Vector2.zero)
            isMoving = false;
        else
            isMoving = true;

        float x = movementAxis.x;
        float y = movementAxis.y;

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);
    }

    void Crouch()
    {
        bool isTryingToCrouch = InputSystem.actions.FindAction("Crouch").IsPressed();

        float heightTarget = isTryingToCrouch ? crouchHeight : standingHeight;

        if(isCrouching && !isTryingToCrouch)
        {
            Vector3 castOrigin = transform.position;
            if (Physics.Raycast(castOrigin, Vector3.up, out RaycastHit hit, 3f, groundMask))
            {
                float distanceToCeiling = hit.point.y - castOrigin.y;
                if (distanceToCeiling > standingHeight)
                    heightTarget = crouchHeight;
            }
        }

        float crouchDelta = Time.deltaTime * crouchTransitionSpeed;
        currentHeight = Mathf.Lerp(currentHeight, heightTarget, crouchDelta);

        Vector3 halfHeightDifference = new Vector3(0.0f, (standingHeight - currentHeight) / 2, 0.0f);

        cam.transform.localPosition = initialCameraPos - halfHeightDifference;
        lanternTransform.localPosition = initialLanternPos - halfHeightDifference;
        bucketTransform.localPosition = initialBucketPos - halfHeightDifference;
        controller.height = currentHeight;
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
    }

    void Look()
    {
        Vector2 mouseAxis = InputSystem.actions["Look"].ReadValue<Vector2>();
        float mouseX = mouseAxis.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseAxis.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
