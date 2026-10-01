using UnityEngine;

public class SpinningPuzzle : MonoBehaviour
{
    public SpinningWheel spinningWheelOne;
    int digit1;
    public SpinningWheel spinningWheelTwo;
    int digit2;
    public SpinningWheel spinningWheelThree;
    int digit3;

    public bool isCage;
    public Animator targetDoor;
    public GameObject cage;

    public int code;
    int currentCode;

    public bool isSolved;
    
    void Update()
    {
        digit1 = spinningWheelOne.displayedNumber;
        digit2 = spinningWheelTwo.displayedNumber;
        digit3 = spinningWheelThree.displayedNumber;

        currentCode = (digit1 * 100) + (digit2 * 10) + digit3;

        if (currentCode == code)
            isSolved = true;
        else
            isSolved = false;

        if (!isCage)
            targetDoor.SetBool("solved", isSolved);
        else if(isSolved)
            cage.SetActive(false);
    }
}
