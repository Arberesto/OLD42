using System;
using UnityEngine;

public class playerController : MonoBehaviour {
    Animator animator;
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
        animator = GetComponent<Animator>();
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
        
        //if (Input.GetAxis("Vertical") != 0)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("condition", 2);
        } 
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetInteger("condition", 1);
        }
    }
}
