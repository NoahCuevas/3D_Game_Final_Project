using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}

public class sound_library : MonoBehaviour
{
    // array of sound effect groups
    public SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        // iterate through sound effect groups
        foreach (var soundEffect in soundEffects)
        {
            // group IDs are "Bomb", "Coin", "Jump", etc. (view them all in audio_manager object)
            if (soundEffect.groupID == name)
            {
                // choose random sound clip from group
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }
        return null;
    }
}