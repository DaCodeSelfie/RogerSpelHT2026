using UnityEngine;

public class SpinningPuzzle : MonoBehaviour
{
    public SpinningWheel spinningWheelOne;
    int digit1;
    public SpinningWheel spinningWheelTwo;
    int digit2;
    public SpinningWheel spinningWheelThree;
    int digit3;
    public SpinningWheel spinningWheelFour;
    int digit4;

    public int code;
    int currentCode;

    public bool isSolved;
    
    void Update()
    {
        digit1 = spinningWheelOne.displayedNumber;
        digit2 = spinningWheelTwo.displayedNumber;
        digit3 = spinningWheelThree.displayedNumber;
        digit4 = spinningWheelFour.displayedNumber;

        currentCode = (digit1 * 1000) + (digit2 * 100) + (digit3 * 10) + digit4;

        if (currentCode == code)
            isSolved = true;
        else
            isSolved = false;
    }
}
