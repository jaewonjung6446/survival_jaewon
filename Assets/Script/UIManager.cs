using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Fillbar;
    [SerializeField] GameObject Menu;
    [SerializeField] Text hpText;
    [SerializeField] Text dashText;
    [SerializeField] Text scoreText;
    float time;

    RectTransform RectBar;
    private void Awake()
    {
        RectBar = Fillbar.GetComponent<RectTransform>();
        Menu.SetActive(false);
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }
    private void LateUpdate()
    {
        if (RectBar != null)
        {
            HpFill();
        }
        HpText();
        DashText();
        ScoreText();
    }
    private void HpFill()
    {
        RectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,1650 *GameManager.Instance.player.playerHp / GameManager.Instance.player.fullPlayerHp);
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
    private void ScoreText()
    {
        scoreText.text = "Score = " + (GameManager.Instance.player.I_score+Mathf.Round(time));
    }
    public void MenuButton()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
}
