using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundPlayer : MonoBehaviour
{
    public SoundProfile ambientSound;
    public float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    AudioSource source;
    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            playSound(ambientSound);
        }
        source.volume = ambientSound.volume * volume;

    }
    public void playSound(SoundProfile profile)
    {

        source.pitch = profile.pitch + (-profile.pitchVariance / 2.0f + (Random.value * profile.pitchVariance));

        source.PlayOneShot(profile.GetRandomClip());

    }
}
