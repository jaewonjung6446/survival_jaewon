using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float enemySpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = enemySpeed * (GameManager.Instance.playermov.GetComponent<Rigidbody2D>().position - this.rigid.position).normalized;
    }
}
