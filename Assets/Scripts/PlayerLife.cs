using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    static GameObject gameOverScreen;

    void Awake()
    {
        gameOverScreen = GameObject.FindWithTag("Death Screen");

        gameOverScreen.SetActive(false);
    }

    public static void PlayerDie()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
