using UnityEngine;

public class PlaySoundAction : ActionBase
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip targetSound;
    [SerializeField] private bool isGlobal;
    public override void Execute()
    {
        if (isGlobal) GlobalAudioPlayer.PlaySound(targetSound);
        else source.PlayOneShot(targetSound);
    }
}