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

    public InventoryLetter letterInventory;
    public InventoryKey keyInventory;
    // Letter bools
    private bool HasLetterOne = false;
    private bool HasLetterTwo = false;
    private bool HasLetterThree = false;
    private bool HasLetterFour = false;
    private bool HasLetterFive = false;
    private bool HasLetterSix = false;
    private bool HasLetterSeven = false;

    // Key Bools
    private bool HasKeyOne = false;
    private bool HasKeyTwo = false;
    private bool HasKeyThree = false;
    private bool HasKeyFour = false;
    private bool HasKeyFive = false;
    private bool HasKeySix = false;
    private bool HasKeySeven = false;
    private bool HasKeyEight = false;
    private bool HasKeyNine = false;

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

        if (isCrouching && !isTryingToCrouch)
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

        if (isGrounded && velocity.y < 0)
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

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "KeyOne":
                HasKeyOne = true;
                CollectedKeyOne();
                Destroy(other.gameObject);
                break;
            case "KeyTwo":
                HasKeyTwo = true;
                CollectedKeyTwo();
                Destroy(other.gameObject);
                break;
            case "KeyThree":
                HasKeyThree = true;
                CollectedKeyThree();
                Destroy(other.gameObject);
                break;
            case "KeyFour":
                HasKeyFour = true;
                CollectedKeyFour();
                Destroy(other.gameObject);
                break;
            case "KeyFive":
                HasKeyFive = true;
                CollectedKeyFive();
                Destroy(other.gameObject);
                break;
            case "KeySix":
                HasKeyFive = true;
                CollectedKeySix();
                Destroy(other.gameObject);
                break;
            case "KeySeven":
                HasKeySeven = true;
                CollectedKeySeven();
                Destroy(other.gameObject);
                break;
            case "KeyEight":
                HasKeyEight = true;
                CollectedKeyEight();
                Destroy(other.gameObject);
                break;
            case "KeyNine":
                HasKeyNine = true;
                CollectedKeyNine();
                Destroy(other.gameObject);
                break;
            case "LetterOne":
                HasLetterOne = true;
                CollectedLetterOne();
                Destroy(other.gameObject);
                break;
            case "LetterTwo":
                HasLetterTwo = true;
                CollectedLetterTwo();
                Destroy(other.gameObject);
                break;
            case "LetterThree":
                HasLetterThree = true;
                CollectedLetterThree();
                Destroy(other.gameObject);
                break;
            case "LetterFour":
                HasLetterFour = true;
                CollectedLetterFour();
                Destroy(other.gameObject);
                break;
            case "LetterFive":
                HasLetterFive = true;
                CollectedLetterFive();
                Destroy(other.gameObject);
                break;
            case "LetterSix":
                HasLetterSix = true;
                CollectedLetterSix();
                Destroy(other.gameObject);
                break;
            case "LetterSeven":
                HasLetterSeven = true;
                CollectedLetterSeven();
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

    public void CollectedKeyOne()
    {
        InventoryKey Key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyOne(gameObject);
    }

    public void CollectedKeyTwo()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyTwo(gameObject);
    }

    public void CollectedKeyThree()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyThree(gameObject);
    }

    public void CollectedKeyFour()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyFour(gameObject);
    }

    public void CollectedKeyFive()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyFive(gameObject);
    }

    public void CollectedKeySix()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeySix(gameObject);
    }

    public void CollectedKeySeven()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeySeven(gameObject);
    }

    public void CollectedKeyEight()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyEight(gameObject);
    }

    public void CollectedKeyNine()
    {
        InventoryKey key = keyInventory.GetComponent<InventoryKey>();
        keyInventory.AddKeyNine(gameObject);
    }
    // Det var alla 9 Keys

    public void CollectedLetterOne()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterOne(gameObject);
    }

    public void CollectedLetterTwo()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterTwo(gameObject);
    }
    public void CollectedLetterThree()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterThree(gameObject);
    }

    public void CollectedLetterFour()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterFour(gameObject);
    }

    public void CollectedLetterFive()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterFive(gameObject);
    }

    public void CollectedLetterSix()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterSix(gameObject);
    }

    public void CollectedLetterSeven()
    {
        InventoryLetter Letter = letterInventory.GetComponent<InventoryLetter>();
        letterInventory.AddLetterSeven(gameObject); // Det var alla 7 Letters
    }
}
