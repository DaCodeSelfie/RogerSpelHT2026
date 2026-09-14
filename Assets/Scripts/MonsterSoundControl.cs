using UnityEngine;
using UnityEngine.AI;

public class MonsterSoundControl : MonoBehaviour
{
    AudioSource audio;
    NavMeshAgent agent;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(agent.velocity.sqrMagnitude > 0.05f && !agent.isStopped)
        {
            if (!audio.isPlaying)
            {
                audio.loop = true;
                audio.Play();
            }                
        }
        else
        {
            if (audio.isPlaying)
                audio.loop = false;
        }
    }
}
