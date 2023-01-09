using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemySound : MonoBehaviour
    {
        public List<AudioClip> attackSounds;
        public List<AudioClip> alertSounds;
        public List<AudioClip> deathSounds;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void PlaySoundRandom(List<AudioClip> soundList)
        {
            var audioClip = soundList[Random.Range(0, soundList.Count)];
            if (audioClip is null) return;

            _audioSource.PlayOneShot(audioClip);
        }

        public void PlayAudioAttack()
        {
            PlaySoundRandom(attackSounds);
        }

        public void PlayAudioAlert()
        {
            PlaySoundRandom(alertSounds);
        }

        public void PlayAudioDeath()
        {
            PlaySoundRandom(deathSounds);
        }
    }
}