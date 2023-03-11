using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGen : MonoBehaviour { 
    [SerializeField] GameObject[] ButtonPrefabs;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject backGround;
    [SerializeField] float buttonGenInterval = 5;
    List<GameObject> buttonList = new List<GameObject>();
    Vector3[] GenPos = { new Vector3(-250, -500, 0), new Vector3(0, -500, 0), new Vector3(250, -500, 0) };
    float time = 0;
    void Start ()
    {
        backGround.SetActive(false);
    }
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > buttonGenInterval)
        {
            GenButton();
            time = 0;
        }
    }
    void GenButton()
    {
        backGround.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            GameObject buttonGen = GameObject.Instantiate(ButtonPrefabs[Random.Range(0, ButtonPrefabs.Length)], canvas.transform);
            buttonGen.SetActive(true);
            buttonList.Add(buttonGen);
            buttonGen.GetComponent<RectTransform>().anchoredPosition = GenPos[i];
        }
        Time.timeScale = 0;
    }
    public void DesButton()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            GameObject des = buttonList[i];
            Destroy(des);
        }
        backGround.SetActive(false);
        Time.timeScale = 1;
    }
}
