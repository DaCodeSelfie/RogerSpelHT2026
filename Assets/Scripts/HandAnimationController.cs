using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    public PlayerController player;

    public Animator lanternHand;
    public Animator bucketHand;

    void Update()
    {
        lanternHand.SetBool("isMoving", player.isMoving);
        bucketHand.SetBool("isMoving", player.isMoving);
    }
}
