using UnityEngine;

public class AUdio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip backgroundMusic;
    private void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        audioSource.loop = true;
    }
}
