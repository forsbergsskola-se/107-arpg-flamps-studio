using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class EnemySound : MonoBehaviour
{
    public List<AudioClip> swingSounds;
    public List<AudioClip> alertSounds;
    public List<AudioClip> deathSounds;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    PlaySound(List<AudioClip> soundList)
    {
        _audioSource.
    }

}
