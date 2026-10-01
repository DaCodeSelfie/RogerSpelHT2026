using UnityEngine;
using UnityEngine.InputSystem;

public class BucketScript : MonoBehaviour
{
    public GameObject heldBucket;
    public Transform cam;
    public float range;
    bool isHolding = false;
    public LayerMask ignorePlayer;

    public GameObject cage;

    void Update()
    {
        heldBucket.SetActive(isHolding);

        InputSystem.actions.FindAction("Opendoor").performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Bucket interact");

        RaycastHit hit;
        if (!isHolding)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, range, ignorePlayer))
            {
                if (hit.transform.tag == "Bucket")
                {
                    isHolding = true;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            if(Physics.Raycast(cam.position, cam.forward, out hit, range, ignorePlayer))
            {
                if(hit.transform.tag == "Flower")
                {
                    isHolding = false;

                    cage.SetActive(false);
                }
            }
        }

    }
}
