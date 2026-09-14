using TMPro;
using UnityEngine;

public class OpenTriggerLetter : MonoBehaviour
{
    public TextMeshProUGUI Letteropentext;
    public GameObject openletterUI;
    public bool Ishowering = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openletterUI.SetActive(false);
    }

    public void ButtonOpenletter()
    {
        Ishowering = true;
        openletterUI.SetActive(true);


        // Letteropentext.text.
    }

    public void ButtonCloseletter()
    {
        openletterUI.SetActive(false);
        Ishowering = false;
    }
}
