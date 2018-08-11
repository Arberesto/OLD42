//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed = 20f;
    private Rigidbody2D rb;
    private bool faceRight = true;
    Animator animator;

	void Start () {
        rb = GetComponent<Rigidbody2D>(); // получаем экземпляр Rigitbody2D
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        float moveX = Input.GetAxis("Horizontal"); // присваеваем от 1 до -1
        rb.MovePosition (position: rb.position + Vector2.right * moveX * speed * Time.deltaTime);  // двигаем таил
        if (Input.GetAxis("Horizontal") == 0)
        {
            flip();
            animator.SetInteger("stayt", 1);
        } else
        {
            flip();
            animator.SetInteger("stayt", 2);
        }
        if (Input.GetKeyDown(KeyCode.Space)) // проверка на пробел
        {
            animator.SetInteger("stayt", 3);
            rb.AddForce(Vector2.up * 8000);
        }
	}

    void flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        //        faceRight = !faceRight;
        //        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
