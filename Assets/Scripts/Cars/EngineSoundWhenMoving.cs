using Model;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
            audioSource.PlayOneShot(movingSound);
        }

        public void StopMoving()
        {
            audioSource.PlayOneShot(defaultAudioClip);
        }
    }
}