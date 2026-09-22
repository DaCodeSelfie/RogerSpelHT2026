using UnityEngine;
using UnityEngine.InputSystem;

public class LanternScript : MonoBehaviour
{

    public bool isOn = true;
    public Material currentMaterial;
    public Texture onTexture;
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
            currentMaterial.SetTexture("_BaseMap", onTexture);
        else
            currentMaterial.SetTexture("_BaseMap", null);
    }
}
