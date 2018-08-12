using System;
using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;

public class planetSpin : MonoBehaviour {
    Transform shipModel;
	private Quaternion _shipDefaultRotation;
	private float speedSpin = 0.7f;
	private int orbitX;
    private int orbitY;
	void Awake () {
		shipModel = GetComponent<Transform>();
		_shipDefaultRotation = shipModel.localRotation;
	}
	void Start () {
		System.Random rand = new System.Random();
		orbitX = rand.Next(-20,20);
		orbitY = rand.Next(-20,20);
		print(orbitX);
		print("/n");
		print(orbitY);
	}
	
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f, speedSpin);
		transform.Translate(new Vector3(0.03f * orbitX, 0.03f * orbitY, 0.0f));
	}
}
