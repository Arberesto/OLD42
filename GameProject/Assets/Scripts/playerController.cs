using System;
using UnityEngine;

public class playerController : MonoBehaviour {
    Animator animator;
    public AudioSource soundStep;
    public AudioSource soundCrash;
    public AudioSource soundShip;
    public float speed = 5; // максимальная скорость корабля в секунду 
    public float speedDamping = 0.1f; // дампинг скорости 

    public float rotationSpeed = 90; // максимальный поворот в секунду 
    public float rotationDamping = 0.1f; // дампинг вращения корпуса 
    public float maxRotationAngle = 360f; // максимальный укол крена корпуса 

    public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом) 
	SpriteRenderer shipRender;
	bool isLanded;
	bool canMove = true;
	bool canLand = false;
    // значение вращения корпуса по умолчанию 
    private Quaternion _shipDefaultRotation;

    // текущий поворот корпуса 
    private float _shipRotation;
    // текущая скорость 
    private float _shipSpeed;

    public void Staps()
    {
        soundStep.Play();
    }


    void Start () {
        animator = GetComponent<Animator>();
		shipRender = GetComponent<SpriteRenderer> ();
        _shipDefaultRotation = shipModel.localRotation;
    }

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Planet") {
			canLand = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag == "Planet") {
			canLand = false;
		}
	}

	
	void Update () {
		if ((canLand)&&(Input.GetKeyDown(Key.Space))) {
			canMove = false;
			isLanded = true;
			shipRender.enabled = false;
		}
		if ((isLanded)&&(Input.GetKeyDown(Key.Space))) {
			canMove = true;
			isLanded = false;
			shipRender.enabled = true;
		}

		if (canMove) {
			// скорость корабля с дампингом 
			_shipSpeed = Mathf.Lerp (_shipSpeed, Mathf.Max (Input.GetAxis ("Vertical"), 0), speedDamping);
			// смещаем корабль в перед на нужную величину 
			transform.position += transform.right * _shipSpeed * speed * Time.deltaTime;

			float rot = Input.GetAxis ("Horizontal");
			// вращаем корабль по оси Z 
			transform.rotation *= Quaternion.AngleAxis (-rot * rotationSpeed * Time.deltaTime, new Vector3 (0, 0, 1));

			// рассчитываем поврот корпуса корабля с дампингом 
			_shipRotation = Mathf.Lerp (_shipRotation, rot * maxRotationAngle, rotationDamping);
        
			//if (Input.GetAxis("Vertical") != 0)
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				soundShip.Play ();
				animator.SetInteger ("condition", 2);
			} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				soundShip.Stop ();
				animator.SetInteger ("condition", 1);
			}
		}
    }
}
