using UnityEngine;

public class StarUI : MonoBehaviour
{
    [SerializeField] private Animator startAnimator;
    [SerializeField] private GameObject activeStar;
    public void Show()
    {
        activeStar.SetActive(true);
        startAnimator.Play("StarShow");
    }

    public void Hide()
    {
        activeStar.SetActive(false);
    }
}