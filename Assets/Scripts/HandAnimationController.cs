using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    public PlayerController player;

    public Animator lanternHand;
    public Animator bucketHand;

    void Update()
    {
        if (player.isMoving == true)
        {
            bucketHand.speed = 1.0f;
            lanternHand.speed = 1.0f;
        }
        else
        {
            bucketHand.speed = 0.0f;
            lanternHand.speed = 0.0f;
        }
    }
}
