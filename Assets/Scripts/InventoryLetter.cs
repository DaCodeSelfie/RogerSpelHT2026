using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryLetter : MonoBehaviour
{
    [Header("Letter Slotts")]

    [Header("Letter SlottOne")]
    public GameObject LetterSlottOne;
    public Image LetterImageOne;
    public TextMeshProUGUI LetterNameTextOne;
    public GameObject Button1;

    [Header("Letter SlottTwo")]
    public GameObject LetterSlottTwo;
    public Image LetterImageTwo;
    public TextMeshProUGUI LetterNameTextTwo;
    public GameObject Button2;

    [Header("Letter SlottThree")]
    public GameObject LetterSlottThree;
    public Image LetterImageThree;
    public TextMeshProUGUI LetterNameTextThree;
    public GameObject Button3;

    [Header("Letter SlottFour")]
    public GameObject LetterSlottFour;
    public Image LetterImageFour;
    public TextMeshProUGUI LetterNameTextFour;
    public GameObject Button4;

    [Header("Letter SlottFive")]
    public GameObject LetterSlottFive;
    public Image LetterImageFive;
    public TextMeshProUGUI LetterNameTextFive;
    public GameObject Button5;

    [Header("Letter SlottSix")]
    public GameObject LetterSlottSix;
    public Image LetterImageSix;
    public TextMeshProUGUI LetterNameTextSix;
    public GameObject Button6;

    [Header("Letter SlottSeven")]
    public GameObject LetterSlottSeven;
    public Image LetterImageSeven;
    public TextMeshProUGUI LetterNameTextSeven;
    public GameObject Button7;

    [Header("Letter SlottEight")]
    public GameObject LetterSlottEight;
    public Image LetterImageEight;
    public TextMeshProUGUI LetterNameTextEight;
    //public GameObject Button8;

    [Header("Letter SlottNine")]
    public GameObject LetterSlottNine;
    public Image LetterImageNine;
    public TextMeshProUGUI LetterNameTextNine;
   // public GameObject Button9;

    [Header("Letter SlottTen")]
    public GameObject LetterSlottTen;
    public Image LetterImageTen;
    public TextMeshProUGUI LetterNameTextTen;
   // public GameObject Button10;

    
    void Start()
    {

    }

    public void AddLetterOne(GameObject letter)
    {
        LetterSlottOne.gameObject.SetActive(true);
        LetterImageOne.gameObject.SetActive(true);
        LetterNameTextOne.gameObject.SetActive(true);
        Button1.gameObject.SetActive(true);
    }

    public void AddLetterTwo(GameObject letter)
    {
        LetterSlottTwo.gameObject.SetActive(true);
        LetterImageTwo.gameObject.SetActive(true);
        LetterNameTextTwo.gameObject.SetActive(true);
        Button2.gameObject.SetActive(true);
    }

    public void AddLetterThree(GameObject letter)
    {
        LetterSlottThree.gameObject.SetActive(true);
        LetterImageThree.gameObject.SetActive(true);
        LetterNameTextThree.gameObject.SetActive(true);
        Button3.gameObject.SetActive(true);
    }

    public void AddLetterFour(GameObject letter)
    {
        LetterSlottFour.gameObject.SetActive(true);
        LetterImageFour.gameObject.SetActive(true);
        LetterNameTextFour.gameObject.SetActive(true);
        Button4.gameObject.SetActive(true);
    }
    public void AddLetterFive(GameObject letter)
    {
        LetterSlottFive.gameObject.SetActive(true);
        LetterImageFive.gameObject.SetActive(true);
        LetterNameTextFive.gameObject.SetActive(true);
        Button5.gameObject.SetActive(true);
    }

    public void AddLetterSix(GameObject letter)
    {
        LetterSlottSix.gameObject.SetActive(true);
        LetterImageSix.gameObject.SetActive(true);
        LetterNameTextSix.gameObject.SetActive(true);
        Button6.gameObject.SetActive(true);
    }

    public void AddLetterSeven(GameObject letter)
    {
        LetterSlottSeven.gameObject.SetActive(true);
        LetterImageSeven.gameObject.SetActive(true);
        LetterNameTextSeven.gameObject.SetActive(true);
        Button7.gameObject.SetActive(true);
    }

    public void AddLetterEight(GameObject letter)
    {
        LetterSlottEight.gameObject.SetActive(true);
        LetterImageEight.gameObject.SetActive(true);
        LetterNameTextEight.gameObject.SetActive(true);
        //Button8.gameObject.SetActive(true);
    }

    public void AddLetterNine(GameObject letter)
    {
        LetterSlottNine.gameObject.SetActive(true);
        LetterImageNine.gameObject.SetActive(true);
        LetterNameTextNine.gameObject.SetActive(true);
       // Button9.gameObject.SetActive(true);
    }

    public void AddLetterTen(GameObject letter)
    {
        LetterSlottTen.gameObject.SetActive(true);
        LetterImageTen.gameObject.SetActive(true);
        LetterNameTextTen.gameObject.SetActive(true);
       // Button10.gameObject.SetActive(true);
    }

}
