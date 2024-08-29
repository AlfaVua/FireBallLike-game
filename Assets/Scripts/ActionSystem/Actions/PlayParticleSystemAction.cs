using System.Collections;
using UnityEngine;

public class PlayParticleSystemAction : ActionBase
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private float playAfter;
    public override void Execute()
    {
        StartCoroutine(nameof(PlayRoutine));
    }

    private IEnumerator PlayRoutine()
    {
        yield return new WaitForSeconds(playAfter);
        particleSystem.Play();
    }
}