using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Vector3 mov_pos = Vector2.zero;
    public int dashToken = 3;
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
    public Vector2 MovPos()
    {
        mov_pos.x = Input.GetAxisRaw("Horizontal");
        mov_pos.y = Input.GetAxisRaw("Vertical");
        return mov_pos.normalized;
    }
    void Atk(GameObject obj)
    {
        switch (obj.name)
        {
            default:
                break;
        }
    }
    void Atked()
    {

    }
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
}
