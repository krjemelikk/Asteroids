using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image _current;

    public void SetValue(float maxHp, float currentHp)
    {
        _current.fillAmount = currentHp / maxHp;
    }
}
