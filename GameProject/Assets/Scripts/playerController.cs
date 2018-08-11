//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed = 20f;
    public float rotation = 90f;
    public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом) 
    private Rigidbody2D rb;
    private Quaternion quaternion; // значение вращения корпуса по умолчанию 
    private float shipRotation = 0;     // текущий поворот корпуса 
    private bool faceRight = true;
    Animator animator;

	void Start () {
        rb = GetComponent<Rigidbody2D>(); // получаем экземпляр Rigitbody2D
        quaternion = shipModel.localRotation; // сохраняем значение вращения корпуса по умолчанию 
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        float moveX = Input.GetAxis("Horizontal"); // присваеваем от 1 до -1
        float moveY = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime);
        rb.MovePosition (position: rb.position + direction);  // двигаем таил
        shipRotation = Mathf.Lerp(shipRotation, -moveX * 360, 0.1f);
        shipModel.localRotation = quaternion * Quaternion.AngleAxis(shipRotation, new Vector3(0,0,1));
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetInteger("stayt", 1);
        } else
        {
            animator.SetInteger("stayt", 2);
        }
        if (Input.GetKeyDown(KeyCode.Space)) // проверка на пробел
        {
            animator.SetInteger("stayt", 3);
            //rb.AddForce(Vector2.up * 8000);
        }
	}
}
