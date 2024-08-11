using UnityEngine;

public static class GlobalAudioPlayer
{
    private static AudioSource _source;
    public static void SetSource(AudioSource source)
    {
        _source = source;
    }

    public static void PlaySound(AudioClip sound)
    {
        _source.PlayOneShot(sound);
    }
}