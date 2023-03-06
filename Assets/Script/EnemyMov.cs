using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    [SerializeField] float enemySpeed = 3.5f;
    float enemyHp = 100;
    float fullEnemyHp;
    // Start is called before the first frame update
    private void OnEnable()
    {
        switch (this.gameObject.name)
        {
            case "Enemy1":
                this.enemyHp = 100;
                break;
            case "Enemy2":
                this.enemyHp = 150;
                break;
            case "Enemy3":
                this.enemyHp = 200;
                break;
        }
        this.fullEnemyHp = enemyHp;
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        this.rigid.velocity = MovVec() * enemySpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.gameObject.layer.Equals(6))
            return;
        if (collision.gameObject.layer.Equals(3))
        {
            GameManager.Instance.pool.DesPool(this.gameObject);
            GameManager.Instance.player.Atked(this.gameObject);
        }
        if (collision.gameObject.layer.Equals(9))
        {
            Atked();
        }
    }
    #region interaction
    void Atked()
    {
        this.enemyHp -= GameManager.Instance.player.F_atk;
        if (enemyHp <= 0)
        {
            GameManager.Instance.pool.DesPool(this.gameObject);
            GameManager.Instance.player.targetSearch = true;
            GameManager.Instance.player.target = null;
        }
    }
    #endregion interaction
    #region mov
    Vector2 MovVec()
    {
        Vector2 playerPos = GameManager.Instance.player.GetComponent<Rigidbody2D>().position;
        Vector2 thisPos = this.rigid.position;
        Vector2 interVec = (playerPos - thisPos).normalized;

        return interVec;
    }
    #endregion mov
}