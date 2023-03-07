using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkMov : MonoBehaviour
{
    Rigidbody2D rigid;
    float time;
    float speed = 10;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.position = GameManager.Instance.player.GetComponent<Rigidbody2D>().position;
        rigid.velocity = (GameManager.Instance.player.atkDir - GameManager.Instance.player.GetComponent<Rigidbody2D>().position).normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
