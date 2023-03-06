using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Fillbar;
    [SerializeField] Text hpText;
    [SerializeField] Text dashText;
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
        HpText();
        DashText();
    }
    private void HpFill()
    {
        RectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,1800 *GameManager.Instance.player.playerHp / GameManager.Instance.player.fullPlayerHp);
        RectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 75);
    }
    private void HpText()
    {
        hpText.text = GameManager.Instance.player.playerHp.ToString() + "/" + GameManager.Instance.player.fullPlayerHp.ToString();
    }
    private void DashText()
    {
        dashText.text = "´ë½¬ È½¼ö : " + GameManager.Instance.player.dashToken.ToString();
    }
}
