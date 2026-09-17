using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float triggerRange = 1.5f;
    public float killRange = 0.8f;

    public LayerMask playerMask;

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, killRange);
    }
}
