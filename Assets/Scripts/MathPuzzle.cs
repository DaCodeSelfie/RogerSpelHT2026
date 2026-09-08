using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MathPuzzle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText1;
    [SerializeField] private TextMeshProUGUI numberText2;
    [SerializeField] private TextMeshProUGUI TextFeedback;
    [SerializeField] private TMP_InputField FildAnswer;

    public UnityEvent AnswerIsRight;

    public int number1;
    public int number2;
   
    private int _answer;
    private int UserAnswer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EquationGenerate();
    }

    private void EquationGenerate()
    {
        _answer = number1 + number2;
        numberText1.text = number1.ToString();
        numberText2.text = number2.ToString();
    }

    public void CheckAnswer()
    {
        UserAnswer = int.Parse(FildAnswer.text);

        if (UserAnswer == _answer)
        {
            TextFeedback.text = "CORRECT";  // Det är rätt svar
        }
        else
        {
            TextFeedback.text = "InCorrect"; // Det är fel svar
        }
    }

    public void EndButton()
    {
        AnswerIsRight.Invoke();
    }


}
