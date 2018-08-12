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
		//Random rand = new Random();
		//orbitX = rand.Next(0,10);
		//orbitY = rand.Next(0,10);
	}
	
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f, speedSpin);
		transform.Translate(new Vector3(0.1f * orbitX, 0.1f * orbitY, 0.0f));
	}
}
