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

    public bool cutscenePlaying;

    public InventoryLetter letterInventory;
    public InventoryKey keyInventory;
    [Header("Door System")]
    [SerializeField] private LayerMask Doormask;

    [Header("Sound")] // Simon som pillar
    public AudioClip KeyPickupSound;
    public AudioClip letterPickupSound;
    public AudioClip footstepSound;
    public AudioClip waterFootstepSound; 
    AudioSource audioSource;
    bool isInWater;
    

    // Letter bools
    public bool HasLetterOne = false;
    public bool HasLetterTwo = false;
    public bool HasLetterThree = false;
    public bool HasLetterFour = false;
    public bool HasLetterFive = false;
    public bool HasLetterSix = false;
    public bool HasLetterSeven = false;

    // Key Bools
    public bool HasKeyOne = false;
    public bool HasKeyTwo = false;
    public bool HasKeyThree = false;
    public bool HasKeyFour = false;
    public bool HasKeyFive = false;
    public bool HasKeySix = false;
    public bool HasKeySeven = false;
    public bool HasKeyEight = false;
    public bool HasKeyNine = false;

    void Start()
    {
        cutscenePlaying = false;
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>(); // Simon som pillar

        Cursor.lockState = CursorLockMode.Locked;

        standingHeight = currentHeight = controller.height;
        initialCameraPos = cam.transform.localPosition;
        initialLanternPos = lanternTransform.localPosition;
        initialBucketPos = bucketTransform.localPosition;
    }

    void Update()
    {
        if (cutscenePlaying)
            return;

        Look();
        Move();
        Gravity();
        Crouch();
        FootSteps();

        InputSystem.actions.FindAction("Opendoor").performed += OnOpen;
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
            if (Physics.Raycast(castOrigin, Vector3.up, out RaycastHit hit, 1f, groundMask))
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
        //lanternTransform.localPosition = initialLanternPos - halfHeightDifference;
        //bucketTransform.localPosition = initialBucketPos - halfHeightDifference;
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

    void FootSteps()
    {
        if (isMoving && isGrounded)
        {            
            if (!audioSource.isPlaying)
            {
                audioSource.clip = isInWater ? waterFootstepSound : footstepSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }

    void OnOpen(InputAction.CallbackContext context)
    {
        Debug.Log("test");
        if (Keyboard.current.eKey.wasPressedThisFrame)     // Keyboard.current.eKey.wasPressedThisFrame
        {
            bool inDoor = Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 3, Doormask);
            if (inDoor == true)
            {
                Debug.Log("Toggle Door For Key");
                DoorSystem door = hitInfo.transform.GetComponent<DoorSystem>();
                if (door != null)
                {
                    door.DoorCheck();
                }
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            UpdateFootstepClip();
            return;
        }
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
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeyThree":
                HasKeyThree = true;
                CollectedKeyThree();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeyFour":
                HasKeyFour = true;
                CollectedKeyFour();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeyFive":
                HasKeyFive = true;
                CollectedKeyFive();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeySix":
                HasKeyFive = true;
                CollectedKeySix();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeySeven":
                HasKeySeven = true;
                CollectedKeySeven();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeyEight":
                HasKeyEight = true;
                CollectedKeyEight();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "KeyNine":
                HasKeyNine = true;
                CollectedKeyNine();
                audioSource.PlayOneShot(KeyPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterOne":
                HasLetterOne = true;
                CollectedLetterOne();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterTwo":
                HasLetterTwo = true;
                CollectedLetterTwo();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterThree":
                HasLetterThree = true;
                CollectedLetterThree();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterFour":
                HasLetterFour = true;
                CollectedLetterFour();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterFive":
                HasLetterFive = true;
                CollectedLetterFive();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterSix":
                HasLetterSix = true;
                CollectedLetterSix();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            case "LetterSeven":
                HasLetterSeven = true;
                CollectedLetterSeven();
                audioSource.PlayOneShot(letterPickupSound);
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            UpdateFootstepClip();
        }
    }

    void UpdateFootstepClip()
    {
        AudioClip clipToPlay = isInWater ? waterFootstepSound : footstepSound;

        if (audioSource.clip != clipToPlay)
        {
            bool wasPlaying = audioSource.isPlaying;
            audioSource.clip = clipToPlay;
            audioSource.loop = true;

            if (wasPlaying)
                audioSource.Play();
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
