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

    [Header("Letter SlottTwo")]
    public GameObject LetterSlottTwo;
    public Image LetterImageTwo;
    public TextMeshProUGUI LetterNameTextTwo;

    [Header("Letter SlottThree")]
    public GameObject LetterSlottThree;
    public Image LetterImageThree;
    public TextMeshProUGUI LetterNameTextThree;

    [Header("Letter SlottFour")]
    public GameObject LetterSlottFour;
    public Image LetterImageFour;
    public TextMeshProUGUI LetterNameTextFour;

    [Header("Letter SlottFive")]
    public GameObject LetterSlottFive;
    public Image LetterImageFive;
    public TextMeshProUGUI LetterNameTextFive;

    [Header("Letter SlottSix")]
    public GameObject LetterSlottSix;
    public Image LetterImageSix;
    public TextMeshProUGUI LetterNameTextSix;

    [Header("Letter SlottSeven")]
    public GameObject LetterSlottSeven;
    public Image LetterImageSeven;
    public TextMeshProUGUI LetterNameTextSeven;

    [Header("Letter SlottEight")]
    public GameObject LetterSlottEight;
    public Image LetterImageEight;
    public TextMeshProUGUI LetterNameTextEight;

    [Header("Letter SlottNine")]
    public GameObject LetterSlottNine;
    public Image LetterImageNine;
    public TextMeshProUGUI LetterNameTextNine;

    [Header("Letter SlottTen")]
    public GameObject LetterSlottTen;
    public Image LetterImageTen;
    public TextMeshProUGUI LetterNameTextTen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddLetterOne(GameObject letter)
    {
        LetterSlottOne.gameObject.SetActive(true);
        LetterImageOne.gameObject.SetActive(true);
        LetterNameTextOne.gameObject.SetActive(true);
    }

    public void AddLetterTwo(GameObject letter)
    {
        LetterSlottTwo.gameObject.SetActive(true);
        LetterImageTwo.gameObject.SetActive(true);
        LetterNameTextTwo.gameObject.SetActive(true);
    }

    public void AddLetterThree(GameObject letter)
    {
        LetterSlottThree.gameObject.SetActive(true);
        LetterImageThree.gameObject.SetActive(true);
        LetterNameTextThree.gameObject.SetActive(true);
    }

    public void AddLetterFour(GameObject letter)
    {
        LetterSlottFour.gameObject.SetActive(true);
        LetterImageFour.gameObject.SetActive(true);
        LetterNameTextFour.gameObject.SetActive(true);
    }
    public void AddLetterFive(GameObject letter)
    {
        LetterSlottFive.gameObject.SetActive(true);
        LetterImageFive.gameObject.SetActive(true);
        LetterNameTextFive.gameObject.SetActive(true);
    }

    public void AddLetterSix(GameObject letter)
    {
        LetterSlottSix.gameObject.SetActive(true);
        LetterImageSix.gameObject.SetActive(true);
        LetterNameTextSix.gameObject.SetActive(true);
    }

    public void AddLetterSeven(GameObject letter)
    {
        LetterSlottSeven.gameObject.SetActive(true);
        LetterImageSeven.gameObject.SetActive(true);
        LetterNameTextSeven.gameObject.SetActive(true);
    }

    public void AddLetterEight(GameObject letter)
    {
        LetterSlottEight.gameObject.SetActive(true);
        LetterImageEight.gameObject.SetActive(true);
        LetterNameTextEight.gameObject.SetActive(true);
    }

    public void AddLetterNine(GameObject letter)
    {
        LetterSlottNine.gameObject.SetActive(true);
        LetterImageNine.gameObject.SetActive(true);
        LetterNameTextNine.gameObject.SetActive(true);
    }

    public void AddLetterTen(GameObject letter)
    {
        LetterSlottTen.gameObject.SetActive(true);
        LetterImageTen.gameObject.SetActive(true);
        LetterNameTextTen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
