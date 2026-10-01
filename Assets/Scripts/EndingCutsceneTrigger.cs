using UnityEngine;
using UnityEngine.UI;

public class EndingCutsceneTrigger : MonoBehaviour
{
    public PlayerController player;
    public Camera cutsceneCamera;

    Animator selfAnimator;

    [Header("Fade In & Out")]
    public Animator fade;
    bool fadingIn;
    public float fadeTimer;
    float fadingTimer;
    bool goodEnding;
    public RawImage endingCanvas;
    public Texture goodEndingImage;
    public Texture badEndingImage;

    void Awake()
    {
        endingCanvas.gameObject.SetActive(false);
        selfAnimator = GetComponent<Animator>();
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
            player.gameObject.SetActive(false);

            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach (var monster in monsters)
                monster.SetActive(false);

            if (player.HasLetterOne && player.HasLetterTwo && player.HasLetterThree && player.HasLetterFour && player.HasLetterFive && player.HasLetterSix && player.HasLetterSeven)
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
        selfAnimator.SetInteger("ending", 1);
        goodEnding = true;
    }

    void PlayBadEnding()
    {
        Debug.Log("Bad Ending");
        selfAnimator.SetInteger("ending", 2);
        goodEnding = false;
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

    public void EndingAnimationFinished()
    {
        if (goodEnding)
            endingCanvas.texture = goodEndingImage;
        else
            endingCanvas.texture = badEndingImage;

        endingCanvas.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
