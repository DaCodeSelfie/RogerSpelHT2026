using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleScript : MonoBehaviour
{
    public Transform cam;
    public LayerMask layer;

    void Update()
    {
        InputSystem.actions.FindAction("Interact").performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, 5.0f, layer))
        {
            hit.transform.GetComponent<SpinningWheel>().Spin();
        }
    }
}