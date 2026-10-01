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
        Quaternion targetRotation = Quaternion.Euler(-90, targetAngle, 0);

        StartCoroutine(AnimateSlerp(targetRotation));
    }

    IEnumerator AnimateSlerp(Quaternion targetRotation)
    {
        while(Quaternion.Angle(transform.localRotation, targetRotation) > 0.1f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, spinSpeed * Time.deltaTime);
            isSpinning = true;
            yield return null;
        }
        isSpinning = false;
        transform.localRotation = targetRotation;
    }

    public void Spin()
    {
        if (isSpinning) return;

        displayedNumber++;
        if (displayedNumber > 9)
            displayedNumber = 0;
    }
}
