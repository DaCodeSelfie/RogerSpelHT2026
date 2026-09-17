using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenySystem : MonoBehaviour
{
    public GameObject UiMenupause;
    bool MenuPauseOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
    }

    public void CountineButton()
    {
        UiMenupause.SetActive(false);
        MenuPauseOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Avslutar");
    }

    // Update is called once per frame
    void Update()
    {
        InputSystem.actions.FindAction("Pause Menu").performed += TogglePauseMenu;
    }

    void TogglePauseMenu(InputAction.CallbackContext context)
    {
        MenuPauseOpen = !MenuPauseOpen;
        UiMenupause.SetActive(MenuPauseOpen);
        if(MenuPauseOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}
