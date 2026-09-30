using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    static GameObject gameOverScreen;
    static AudioClip deathSoundStatic;
    static bool isDead;
    public AudioClip deathSound;

    void Awake()
    {
        gameOverScreen = GameObject.FindWithTag("Death Screen");

        gameOverScreen.SetActive(false);

        deathSoundStatic = deathSound;
        isDead = false;
    }

    public static void Die()
    {
        if (isDead) return;
        isDead = true; 

        gameOverScreen.SetActive(true);

        if (deathSoundStatic != null)
            AudioSource.PlayClipAtPoint(deathSoundStatic, Camera.main.transform.position);

        Time.timeScale = 0f;
    }
}
