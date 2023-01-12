using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public Image skill;

    public void Cooldown(float timeAttack, float timeBetweenAttack)
    {
        skill.fillAmount = timeAttack / timeBetweenAttack;
    }
}
