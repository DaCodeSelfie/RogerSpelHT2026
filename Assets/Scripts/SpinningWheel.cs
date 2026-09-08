using System.Collections;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    public int displayedNumber = 0;
    public float spinSpeed = 3.0f;

    bool isSpinning;

    void Start()
    {
        
    }

    void Update()
    {
        int targetAngle = 36 * displayedNumber;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        StartCoroutine(AnimateSlerp(targetRotation));
    }

    IEnumerator AnimateSlerp(Quaternion targetRotation)
    {
        while(Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, spinSpeed * Time.deltaTime);
            isSpinning = true;
            yield return null;
        }
        isSpinning = false;
        transform.rotation = targetRotation;
    }

    public void Spin()
    {
        if (isSpinning) return;

        displayedNumber++;
        if (displayedNumber > 9)
            displayedNumber = 0;
    }
}
