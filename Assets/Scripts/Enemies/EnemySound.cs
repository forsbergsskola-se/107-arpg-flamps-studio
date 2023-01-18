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

        private float _nextAttackSoundTime;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        
        // returns audio play time
        private float PlaySoundRandom(List<AudioClip> soundList)
        {
            var audioClip = soundList[Random.Range(0, soundList.Count)];
            if (audioClip is null) return 0;

            _audioSource.PlayOneShot(audioClip);
            return audioClip.length;
        }

        public void PlayAudioAttack()
        {
            if (Time.time > _nextAttackSoundTime)
                _nextAttackSoundTime = Time.time + (PlaySoundRandom(attackSounds) * 2);
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