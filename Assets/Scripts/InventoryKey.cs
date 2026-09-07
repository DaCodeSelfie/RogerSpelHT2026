using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryKey : MonoBehaviour
{
    [Header("Key Slotts")]

    [Header("Key SlottOne")]
    public GameObject KeySlottOne;
    public Image KeyImageOne;
    public TextMeshProUGUI KeyNameTextOne;

    [Header("Key SlottTwo")]
    public GameObject KeySlottTwo;
    public Image KeyImageTwo;
    public TextMeshProUGUI KeyNameTextTwo;

    [Header("Key SlottThree")]
    public GameObject KeySlottThree;
    public Image KeyImageThree;
    public TextMeshProUGUI KeyNameTextThree;

    [Header("Key SlottFour")]
    public GameObject KeySlottFour;
    public Image KeyImageFour;
    public TextMeshProUGUI KeyNameTextFour;

    [Header("Key SlottFive")]
    public GameObject KeySlottFive;
    public Image KeyImageFive;
    public TextMeshProUGUI KeyNameTextFive;

    [Header("Key SlottSix")]
    public GameObject KeySlottSix;
    public Image KeyImageSix;
    public TextMeshProUGUI KeyNameTextSix;

    [Header("Key SlottSeven")]
    public GameObject KeySlottSeven;
    public Image KeyImageSeven;
    public TextMeshProUGUI KeyNameTextSeven;

    [Header("Key SlottEight")]
    public GameObject KeySlottEight;
    public Image KeyImageEight;
    public TextMeshProUGUI KeyNameTextEight;

    [Header("Key SlottNine")]
    public GameObject KeySlottNine;
    public Image KeyImageNine;
    public TextMeshProUGUI KeyNameTextNine;

    [Header("Key SlottTen")]
    public GameObject KeySlottTen;
    public Image KeyImageTen;
    public TextMeshProUGUI KeyNameTextTen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddKeyOne(GameObject Key)
    {
        KeySlottOne.gameObject.SetActive(true);
        KeyImageOne.gameObject.SetActive(true);
        KeyNameTextOne.gameObject.SetActive(true);
    }

    public void AddKeyTwo(GameObject Key)
    {
        KeySlottTwo.gameObject.SetActive(true);
        KeyImageTwo.gameObject.SetActive(true);
        KeyNameTextTwo.gameObject.SetActive(true);
    }

    public void AddKeyThree(GameObject Key)
    {
        KeySlottThree.gameObject.SetActive(true);
        KeyImageThree.gameObject.SetActive(true);
        KeyNameTextThree.gameObject.SetActive(true);
    }

    public void AddKeyFour(GameObject key)
    {
        KeySlottFour.gameObject.SetActive(true);
        KeyImageFour.gameObject.SetActive(true);
        KeyNameTextFour.gameObject.SetActive(true);
    }

    public void AddKeyFive(GameObject key)
    {
        KeySlottFive.gameObject.SetActive(true);
        KeyImageFive.gameObject.SetActive(true);
        KeyNameTextFive.gameObject.SetActive(true);
    }

    public void AddKeySix(GameObject key)
    {
        KeySlottSix.gameObject.SetActive(true);
        KeyImageSix.gameObject.SetActive(true);
        KeyNameTextSix.gameObject.SetActive(true);
    }

    public void AddKeySeven(GameObject key)
    {
        KeySlottSeven.gameObject.SetActive(true);
        KeyImageSeven.gameObject.SetActive(true);
        KeyNameTextSeven.gameObject.SetActive(true);
    }

    public void AddKeyEight(GameObject key)
    {
        KeySlottEight.gameObject.SetActive(true);
        KeyImageEight.gameObject.SetActive(true);
        KeyNameTextEight.gameObject.SetActive(true);
    }

    public void AddKeyNine(GameObject key)
    {
        KeySlottNine.gameObject.SetActive(true);
        KeyImageNine.gameObject.SetActive(true);
        KeyNameTextNine.gameObject.SetActive(true);
    }

    public void AddKeyTen(GameObject key)
    {
        KeySlottTen.gameObject.SetActive(true);
        KeyImageTen.gameObject.SetActive(true);
        KeyNameTextTen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
