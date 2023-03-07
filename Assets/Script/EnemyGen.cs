using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    [SerializeField] float genInterval = 1.5f;
    float time;
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if(time > genInterval)
        {
            int a = (int)Random.Range(0, 3);
            int b = (int)Random.Range(0, 360);
            Vector3 c = new Vector3(Mathf.Sin(b), Mathf.Cos(b), 0) * 20 + new Vector3(GameManager.Instance.player.playerPos.x, GameManager.Instance.player.playerPos.y, 0);
            GameManager.Instance.pool.GetPool(a, c);
            time = 0;
        }
    }
}
