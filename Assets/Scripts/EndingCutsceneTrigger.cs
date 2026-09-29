using UnityEngine;

public class EndingCutsceneTrigger : MonoBehaviour
{
    public PlayerController player;
    public Camera cutsceneCamera;

    [Header("Fade In & Out")]
    public Animator fade;
    bool fadingIn;
    public float fadeTimer;
    float fadingTimer;

    void Awake()
    {
        cutsceneCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (fadingIn)
            fadingTimer -= Time.deltaTime;

        if(fadingTimer <= 0.0f && fadingIn)
        {
            fadingIn = false;
            cutsceneCamera.gameObject.SetActive(true);
            Camera.main.gameObject.SetActive(false);
            player.cutscenePlaying = true;

            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach (var monster in monsters)
                monster.SetActive(false);

            if (player.HasLetterOne && player.HasLetterTwo && player.HasLetterThree && player.HasLetterFour && player.HasLetterFive && player.HasLetterSix && player.HasKeySeven)
            {
                PlayGoodEnding();
            }
            else
            {
                PlayBadEnding();
            }
        }
    }

    void PlayGoodEnding()
    {
        Debug.Log("Good Ending");
    }

    void PlayBadEnding()
    {
        Debug.Log("Bad Ending");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fade.SetBool("Start Fading", true);
            fadingIn = true;
            fadingTimer = fadeTimer;
        }
    }
}
