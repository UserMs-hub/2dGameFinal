using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    public Scanner scanner;
    public Hand[] hands;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);    
    }
    
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }


    void FixedUpdate()
    {

        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        // 위치 이동
        rb.MovePosition(rb.position + nextVec);


    }
    
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            sp.flipX = inputVec.x < 0;
        }
    }
}
