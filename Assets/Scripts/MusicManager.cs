using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] tracks;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SwitchTrack(0);
    }

    public void SwitchTrack(int index)
    {
        if (index < 0 || index >= tracks.Length) return;
        audioSource.clip = tracks[index];
        audioSource.Play();
    } 
}
