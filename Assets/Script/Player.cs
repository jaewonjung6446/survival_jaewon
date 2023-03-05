using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Vector3 mov_pos = Vector2.zero;
    public int dashToken = 3;
    public float playerHp = 100;
    public float fullPlayerHp = 100;
    public GameObject atk;
    GameObject target;
    float atkRange = 10;
    bool dashAble = true;
    float vel= 1;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public Vector2 playerPos;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Transform tr = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine("DashTk");
        StartCoroutine("DashAble");
    }
    void FixedUpdate()
    {
        playerPos = rigid.position;
        rigid.MovePosition(playerPos + MovPos() * Time.deltaTime * 5.0f * vel);
        if(MovPos().x > 0)
        {
            spriteRenderer.flipX = true;
        }
        if(MovPos().x < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetAxis("Jump") != 0)
        {
            if (dashToken > 0 && dashAble)
            {
                dashAble = false;
                dashToken -= 1;
                StartCoroutine("DashVel");
            }
        }
        animator.SetFloat("Run" , MovPos().magnitude);
    }
    #region Mov
    public Vector2 MovPos()
    {
        mov_pos.x = Input.GetAxisRaw("Horizontal");
        mov_pos.y = Input.GetAxisRaw("Vertical");
        return mov_pos.normalized;
    }
    #endregion Mov
    #region Interaction
    public void Atked(GameObject obj)
    {
        switch (obj.name)
        {
            case "Enemy1(Clone)":
                playerHp -= 5;
                break;
            case "Enemy2(Clone)":
                playerHp -= 8;
                break;
            case "Enemy3(Clone)":
                playerHp -= 12;
                break;
        }
        Debug.Log(playerHp);
    }
    #endregion Interaction
    #region Dash
    IEnumerator DashTk()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(5.0f);
            if (dashToken < 3)
            {
                dashToken += 1;
            }
        }
    }
    IEnumerator DashAble()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(3.0f);
            if (!dashAble)
            {
                dashAble = true;
                Debug.Log(dashAble);
            }
        }
    }
    IEnumerator DashVel(){
        vel = 5.0f;
        yield return new WaitForSecondsRealtime(0.2f);
        vel = 1.0f;
    }
    #endregion Dash
    #region Atk
    void Targeting()
    {
        GameObject[] A_enemy = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> L_enemy = new List<GameObject> ();
        float disLeast = 100;
        for (int i = 0; i < A_enemy.Length; i++)
        {
            float dis = (this.rigid.position - A_enemy[i].GetComponent<Rigidbody2D>().position).magnitude;
            if (dis < atkRange)
            {
                L_enemy.Add(A_enemy[i]);
            }
        }
        for (int i = 0; i < L_enemy.Count; i++)
        {
            float dis = (this.rigid.position - L_enemy[i].GetComponent<Rigidbody2D>().position).magnitude;
            if (dis < disLeast)
                target = L_enemy[i].gameObject;
        }
    }
    void GenAtk()
    {
        GameObject atkPrefab = GameObject.Instantiate(atk);
        atkPrefab.GetComponent<Rigidbody2D>().position = this.rigid.position;
    }
    #endregion Atk
}
