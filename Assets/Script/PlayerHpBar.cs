using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] GameObject Fillbar;
    RectTransform RectBar;
    private void Awake()
    {
        RectBar = Fillbar.GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        if (RectBar != null)
        {
            HpFill();
        }
    }
    private void HpFill()
    {
        RectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,1800 *GameManager.Instance.player.playerHp / GameManager.Instance.player.fullPlayerHp);
        RectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 75);
    }
}
