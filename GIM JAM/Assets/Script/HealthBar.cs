using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient colorUI;
    public Image healthFill;

    public void UpdateHealth(int curHp, int baseHp)
    {
        healthFill.fillAmount = (float)curHp / (float)baseHp;
        healthFill.color = colorUI.Evaluate(healthFill.fillAmount);
    }
}
