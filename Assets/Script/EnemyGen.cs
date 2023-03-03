using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    [SerializeField] float genTime = 0.8f;
    float time;
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if(time > genTime)
        {
            int a = (int)Random.Range(0, 3);
            int b = (int)Random.Range(0, 360);
            Vector3 c = new Vector3(Mathf.Sin(b), Mathf.Cos(b), 0) * 20 + new Vector3(GameManager.Instance.playermov.playerPos.x, GameManager.Instance.playermov.playerPos.y, 0);
            GameManager.Instance.pool.GetPool(a, c);
            time = 0;
        }
    }
}
