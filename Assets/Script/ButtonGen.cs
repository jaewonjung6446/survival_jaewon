using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGen : MonoBehaviour { 
    [SerializeField] GameObject[] ButtonPrefabs;
    [SerializeField] GameObject canvas;
    List<GameObject> buttonList = new List<GameObject>();
    Vector3[] GenPos = { new Vector3(-220, 0, 0), new Vector3(0, 0, 0), new Vector3(220, 0, 0) };
    float time = 0;
    [SerializeField] float buttonGenTime = 5;
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > buttonGenTime)
        {
            Debug.Log("»ý¼º");
            StartCoroutine("GenButton");
            time = 0;
        }
    }
    IEnumerator GenButton()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject buttonGen = GameObject.Instantiate(ButtonPrefabs[Random.Range(0, ButtonPrefabs.Length)], canvas.transform);
            buttonGen.SetActive(true);
            buttonList.Add(buttonGen);
            buttonGen.GetComponent<RectTransform>().anchoredPosition = GenPos[i];
        }
        yield return new WaitForSecondsRealtime(3.0f);
        DesButton();
    }
    public void DesButton()
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            GameObject des = buttonList[i];
            Destroy(des);
        }
    }
}
