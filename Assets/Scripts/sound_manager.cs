using UnityEngine;

public class sound_manager : MonoBehaviour
{
    public static sound_manager Instance;

    // reference to sound library (sound_library.cs)
    [SerializeField]
    private sound_library sfxLibrary;
    
    [SerializeField]
    private AudioSource sfx2DSource;

    // only allows one instance of sound_manager
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // used for sounds in-game, spawns audio source at specific position
    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos);
        }
    }

    public void PlaySound3D(string soundName, Vector3 pos)
    {
        PlaySound3D(sfxLibrary.GetClipFromName(soundName), pos);
    }

    // used for sounds found in the UI (ex. title screen)
    public void PlaySound2D(string soundName)
    {
        sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }
}