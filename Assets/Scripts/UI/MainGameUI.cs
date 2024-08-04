using TMPro;
using UnityEngine;

public class MainGameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI bulletsAmount;

    public void SetBulletsAmount(int bullets)
    {
        bulletsAmount.text = bullets.ToString();
    }
}
