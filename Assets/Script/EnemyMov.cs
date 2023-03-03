using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float enemySpeed = 3.5f;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.gameObject.layer.Equals(6))
            return;
        if (collision.gameObject.layer.Equals(3))
        {
            GameManager.Instance.pool.DesPool(this.gameObject);
        }
    }

}