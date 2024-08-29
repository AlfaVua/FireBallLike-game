using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPanelUI : MonoBehaviour
{
    [SerializeField] private List<StarUI> stars;
    [SerializeField] private float oneStarAnimationTime;

    public void ShowStars(int count)
    {
        stars.ForEach(star => star.Hide());
        if (count < 1) return;
        StartCoroutine(nameof(ShowStarsRoutine), count);
    }

    public IEnumerator ShowStarsRoutine(int count)
    {
        int currentStar = 0;
        while (currentStar != count)
        {
            stars[currentStar].Show();
            currentStar++;
            yield return new WaitForSeconds(oneStarAnimationTime);
        }
    }
}