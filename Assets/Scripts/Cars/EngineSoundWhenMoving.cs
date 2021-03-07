using Model;
using UnityEngine;

namespace Cars
{
    public class EngineSoundWhenMoving : MonoBehaviour, IMovementListener
    {
        public AudioClip movingSound;

        private AudioSource audioSource;
        private AudioClip defaultAudioClip;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            defaultAudioClip = audioSource.clip;
        }

        public void StartMoving()
        {
            audioSource.clip = movingSound;
            audioSource.Play();
        }

        public void StopMoving()
        {
            audioSource.clip = defaultAudioClip;
            audioSource.Play();
        }
    }
}