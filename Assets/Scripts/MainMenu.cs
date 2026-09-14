using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void OnButtonStart()
    {
        SceneManager.LoadScene("MainMap");
        //Debug.Log("SPELET KÖRS");
    }

    public void OnButtonQuit()
    {
        Application.Quit();
       // Debug.Log("DET STÄNGS AV");
    }
}
