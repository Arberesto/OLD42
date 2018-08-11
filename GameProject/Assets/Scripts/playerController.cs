//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour {
    /*public float speed = 20f;
    public float rotationSpeed = 90f;
    public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом) 
   // private Rigidbody2D rb;
    private Quaternion quaternion; // значение вращения корпуса по умолчанию 
    private float shipRotation = 0;     // текущий поворот корпуса 
    private float shipSpeed = 0;
   // Animator animator;*/
    public float speed = 5; // максимальная скорость корабля в секунду 
    public float speedDamping = 0.1f; // дампинг скорости 

    public float rotationSpeed = 90; // максимальный поворот в секунду 
    public float rotationDamping = 0.1f; // дампинг вращения корпуса 
    public float maxRotationAngle = 360f; // максимальный укол крена корпуса 

    public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом) 


    // значение вращения корпуса по умолчанию 
    private Quaternion _shipDefaultRotation;

    // текущий поворот корпуса 
    private float _shipRotation;
    // текущая скорость 
    private float _shipSpeed;


    void Start () {
        // rb = GetComponent<Rigidbody2D>(); // получаем экземпляр Rigitbody2D
        //quaternion = shipModel.localRotation; // сохраняем значение вращения корпуса по умолчанию 
        //animator = GetComponent<Animator>();
        _shipDefaultRotation = shipModel.localRotation;
    }
	
	void Update () {
        // скорость корабля с дампингом 
        _shipSpeed = Mathf.Lerp(_shipSpeed, Mathf.Max(Input.GetAxis("Vertical"), 0), speedDamping);
        // смещаем корабль в перед на нужную величину 
        transform.position += transform.right * _shipSpeed * speed * Time.deltaTime;

        float rot = Input.GetAxis("Horizontal");
        // вращаем корабль по оси Z 
        transform.rotation *= Quaternion.AngleAxis(-rot * rotationSpeed * Time.deltaTime, new Vector3(0,0,1));

        // рассчитываем поврот корпуса корабля с дампингом 
        _shipRotation = Mathf.Lerp(_shipRotation, rot * maxRotationAngle, rotationDamping);
        // рассчитываем значение поворота корпуса 
        // shipModel.localRotation = _shipDefaultRotation * Quaternion.AngleAxis(_shipRotation, new Vector3(0,0,1));
        /*// скорость корабля с дампингом 
        shipSpeed = Mathf.Lerp(shipSpeed, Mathf.Max(Input.GetAxis("Vertical"), 0), 0.1f);
        // смещаем корабль в перед на нужную величину 
        transform.position += transform.position * shipSpeed * Time.deltaTime;

        float rot = Input.GetAxis("Horizontal");
        // вращаем корабль по оси Z 
        transform.rotation *= Quaternion.AngleAxis(rot * rotationSpeed * Time.deltaTime, transform.up);

        // рассчитываем поврот корпуса корабля с дампингом 
        shipRotation = Mathf.Lerp(shipRotation, rot * 30, 0.1f);
        // рассчитываем значение поворота корпуса 
        shipModel.localRotation = quaternion * Quaternion.AngleAxis(shipRotation, Vector3.back);*/
    }
}
