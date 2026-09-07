using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenySystem : MonoBehaviour
{
    public GameObject UiMenupause;
    bool MenuPauseOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Avslutar");
    }

    // Update is called once per frame
    void Update()
    {
        InputSystem.actions.FindAction("PauseMeny").performed += TogglePauseMenu;
    }

    void TogglePauseMenu(InputAction.CallbackContext context)
    {
        MenuPauseOpen = !MenuPauseOpen;
        UiMenupause.SetActive(MenuPauseOpen);
        if(MenuPauseOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
