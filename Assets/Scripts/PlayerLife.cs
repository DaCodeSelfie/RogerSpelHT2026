using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    static GameObject gameOverScreen;
    static AudioClip deathSoundStatic;
    static bool isDead;
    public AudioClip deathSound;

    static bool dying;
    float dyingTime = 0.75f;

    void Awake()
    {
        gameOverScreen = GameObject.FindWithTag("Death Screen");

        gameOverScreen.SetActive(false);

        deathSoundStatic = deathSound;
        isDead = false;
    }

    private void Update()
    {
        if (dying)
            dyingTime -= Time.deltaTime;

        if(dyingTime <= 0.0f)
            Time.timeScale = 0f;
    }

    public static void Die()
    {
        if (isDead) return;
        isDead = true;
        dying = true;

        Cursor.lockState = CursorLockMode.None;

        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<Animator>().Play("death_flash");

        if (deathSoundStatic != null)
            AudioSource.PlayClipAtPoint(deathSoundStatic, Camera.main.transform.position);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
