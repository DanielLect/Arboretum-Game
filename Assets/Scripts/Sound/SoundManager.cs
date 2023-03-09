using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject source;

    static SoundManager manager;

    public static SoundManager Get()
    {
        return manager;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    /*
    private void playSound(AudioClip clip)
    {
        playSound(clip, Player.GetTransform().position);
    }*/
    public void playSound(SoundProfile profile)
    {
        playSound(profile, Camera.main.transform.position);
    }
    public void playSound(SoundProfile profile, Vector3 location)
    {
        playSound(profile, location, 1);

    }
    public void playSound(SoundProfile profile, Vector3 location, float volume)
    {
        GameObject copy = GameObject.Instantiate(source, Camera.main.transform);
        copy.GetComponent<SoundPlayer>().playSound(profile, location, volume);

    }

    /*
    public void playSound(SoundProfile profile, Vector3 location, Character soundSource, float volume)
    {
        playSoundNoStealth(profile, location, volume);

        Faction faction = Faction.Player;
        if (soundSource != null)
        {
            faction = soundSource.faction;
        }
        if (faction == Faction.Civillian)
        {
            return;
        }

        foreach (Character character in CharacterManager.Get().characters)
        {
            if (faction != character.faction)
            {
                SenseHearing hearing = character.GetComponentInChildren<SenseHearing>();
                if (hearing != null)
                {
                    hearing.alert(location, profile, volume);
                }
            }
        }

    }
    public void playSound(SoundProfile profile, Vector3 location, Character character)
    {
        playSound(profile, location, character, 1);

    }

    public void playSound(SoundProfile profile, Vector3 location, float volume)
    {
        playSound(profile, location, null, volume);

    }
    public void playSound(SoundProfile profile, Vector3 location)
    {
        playSound(profile, location, 1);

    }
    /*
    private void playSound(AudioClip clip, Vector3 location)
    {
        GameObject copy = GameObject.Instantiate(source);
        copy.GetComponent<SoundPlayer>().playSound(clip, location);
        copy.transform.parent = Player.GetTransform();
    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
