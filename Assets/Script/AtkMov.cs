using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkMov : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject target;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.position = GameManager.Instance.player.GetComponent<Rigidbody2D>().position;
        target = GameManager.Instance.player.target.gameObject;
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        if (target != null)
        {
            rigid.position += Time.deltaTime * (target.GetComponent<Rigidbody2D>().position - this.rigid.position).normalized * GameManager.Instance.player.F_atkSpeed;
        } 
    }
    private void LateUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
