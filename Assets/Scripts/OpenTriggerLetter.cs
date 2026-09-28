using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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
        Cursor.lockState = CursorLockMode.None; // TÄSTAR ATT LÄGGA IN DEN HÄR RADEN AV KOD FÖR ATT SE OM DET FUNGERAER


        // Letteropentext.text.
    }

    public void ButtonCloseletter()
    {
        openletterUI.SetActive(false);
        Ishowering = false;
    }
}
