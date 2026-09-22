using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float triggerRange = 1.5f;
    public float killRange = 0.8f;

    public LayerMask playerMask;
    public Animator spikeAnimator;

    bool isTriggered;

    public float idleTime = 3.0f;
    float idleTimer;

    void Update()
    {
        if (isTriggered)
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0.0f)
            {
                isTriggered = false;
                spikeAnimator.Play("spike_moving_down");
            }           
        }
        else if (Physics.CheckSphere(transform.position, triggerRange, playerMask) && !isTriggered)
        {
            isTriggered = true;

            spikeAnimator.Play("spike_moving_up");
    
            idleTimer = idleTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, killRange);
    }
}
