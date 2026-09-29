using UnityEngine;
using UnityEngine.InputSystem;

public class DoorSystem : MonoBehaviour
{
    public bool isOpen = false;
    public PlayerController player;
    public AudioClip opendoorSound;

    Animator animator;
    AudioSource audioSource;


    /* public void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             Debug.Log("SKA TA OCH KÖRA EN DÖRRCHECK");
             DoorCheck();
             Debug.Log("dÖRRCHECK KÖRS");
         }
     }*/
    /* public void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Debug.Log("SKA TA OCH KÖRA EN DÖRRCHECK");
             DoorCheck();
             Debug.Log("dÖRRCHECK KÖRS");
         }
     }*/

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Simon som pillar
    }

    public void DoorCheck()
    {
        if (player.HasKeyOne == true && gameObject.CompareTag("DoorOne"))
        {
            isOpen = true;
            OpenDoorOne();
            audioSource.PlayOneShot(opendoorSound);
        }
        if (player.HasKeyTwo == true && gameObject.CompareTag("DoorTwo"))
        {
            isOpen = true;
            OpenDoorTwo();
            audioSource.PlayOneShot(opendoorSound);
        }
        if (player.HasKeyThree == true && gameObject.CompareTag("DoorThree"))
        {
            isOpen = true;
            OpenDoorThree();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeyFour == true && gameObject.CompareTag("DoorFour"))
        {
            isOpen = true;
            OpenDoorFour();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeyFive == true && gameObject.CompareTag("DoorFive"))
        {
            isOpen = true; 
            OpenDoorFive();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeySix == true && gameObject.CompareTag("DoorSix"))
        {
            isOpen = true; 
            OpenDoorSix();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeySeven == true && gameObject.CompareTag("DoorSeven"))
        {
            isOpen = true; 
            OpenDoorSeven();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeyEight == true && gameObject.CompareTag("DoorEight"))
        {
            isOpen = true; 
            OpenDoorEight();
            audioSource.PlayOneShot(opendoorSound);
        }
        if(player.HasKeyNine == true && gameObject.CompareTag("DoorNine"))
        {
            isOpen = true;
            OpenDoorNine();
            audioSource.PlayOneShot(opendoorSound);
        }
        else if (player.HasKeyOne == false)
        {
            isOpen = false;
            //Debug.Log("BEHÖVER HA KEYONE FÖR ATT ÖPPNA");
        }
        else if (player.HasKeyTwo == false)
        {
            isOpen = false;
            // Debug.Log("BEHÖVER HA KEYTWO FÖR ATT ÖPPNA");
        }
        else if (player.HasKeyThree == false)
        {
            isOpen = false;
        }
        else if(player.HasKeyFour == false)
        {
            isOpen = false;
        }
        else if(player.HasKeyFive == false)
        {
            isOpen = false;
        }
        else if( player.HasKeySix == false)
        {
            isOpen = false;
        }
        else if(player.HasKeySeven == false)
        {
            isOpen = false;
        }
        else if(player.HasKeyEight == false)
        {
            isOpen = false;
        }
        else if(player.HasKeyNine == false)
        {
            isOpen = false;
        }
    }

    public void ToggleState()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isOpen == true)
        {
            Debug.Log("ÖPPNAR DÖRREN");
            //Destroy(gameObject);
            animator.SetBool("open", isOpen);
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && isOpen == false)
        {
            Debug.Log("Stänger dörren");
        }
    }

    public void OpenDoorOne()
    {
        //Doorone.localPosition = DoorStart + new Vector3(0, 90, 0);
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorTwo()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorThree()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorFour()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorFive()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorSix()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorSeven()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorEight()
    {
        isOpen = true;
        ToggleState();
    }

    public void OpenDoorNine()
    {
        isOpen = true;
        ToggleState();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
