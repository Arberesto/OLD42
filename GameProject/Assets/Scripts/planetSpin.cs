using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class planetSpin : MonoBehaviour {
    public float orbitX = 1;
    public float orbitY = 1;
    public Transform shipModel;
	private Quaternion _shipDefaultRotation;
	private float speedSpin = 0.7f;
	void Start () {
		_shipDefaultRotation = shipModel.localRotation;
	}
	
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f, speedSpin);
		transform.Translate(new Vector3(0.1f * orbitX, 0.1f * orbitY, 0.0f));
	}
}
