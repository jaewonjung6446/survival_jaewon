using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuSceneUI : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
