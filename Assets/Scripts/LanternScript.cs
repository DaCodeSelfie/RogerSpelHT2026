using UnityEngine;
using UnityEngine.InputSystem;

public class LanternScript : MonoBehaviour
{

    public bool isOn = true;
    public Material onMaterial;
    public Material offMaterial;
    public Transform lantern;

    Light lanternLight;

    void Start()
    {
        lanternLight = lantern.GetComponent<Light>();   
    }

    
    void Update()
    {
        InputSystem.actions.FindAction("Toggle Lantern").performed += ToggleLantern;  
    }

    void ToggleLantern(InputAction.CallbackContext context)
    {
        isOn = !isOn;

        lanternLight.enabled = isOn;

        if (isOn)
            lantern.GetComponent<Renderer>().material = onMaterial;
        else
            lantern.GetComponent<Renderer>().material = offMaterial;
    }
}
