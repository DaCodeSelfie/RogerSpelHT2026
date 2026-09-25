using UnityEngine;
using UnityEngine.InputSystem;

public class GeneratorScript : MonoBehaviour
{
    public MonsterMovement affectedMonster;
    public Light light;
    public float duration = 20.0f;
    public float interactionRange = 0.5f;
    public LayerMask generatorMask;

    float timer;
    bool isActive;
    Transform cam;

    private void Awake()
    {
        isActive = false;
        cam = Camera.main.transform;
    }

    void Update()
    {
        Debug.Log(isActive);

        if (isActive)
            timer -= Time.deltaTime;

        if (timer <= 0.0f)
            isActive = false;

        light.enabled = isActive;

        if(!isActive)
            InputSystem.actions.FindAction("Opendoor").performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactionRange, generatorMask))
        {
            Debug.Log("Interacted");

            affectedMonster.Distracted(duration, light.transform);
            timer = duration;
            isActive = true;
        }
    }
}
