using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.Manager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        [SerializeField] private AudioSource _audioSource;
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(_audioSource);
        }
        public void PlayAudio(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
        public void MuteSound()
        {
            AudioListener.pause = true;
        }
        public void UnMuteSound()
        {
            AudioListener.pause = false;
        }
    }
}