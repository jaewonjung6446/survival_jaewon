using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDir : MonoBehaviour
{
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.rect.anchoredPosition.y > -0.01)
        {
            return;
        }
        float a = Mathf.Lerp(this.rect.anchoredPosition.y, 0, 15*Time.unscaledDeltaTime);
        Debug.Log(a);
        rect.anchoredPosition = new Vector2(this.rect.anchoredPosition.x,a);
    }
}
