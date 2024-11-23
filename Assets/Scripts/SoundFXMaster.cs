using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundFXMaster : MonoBehaviour
{
   public static SoundFXMaster instance;
   [SerializeField] private AudioSource soundFXObject;

   private void Awake()
   {
    if (instance == null)
    {
        instance = this;
    }

   }

   public bool PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
   {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
        return true;
   }

}
