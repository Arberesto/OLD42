using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class planetSpin : MonoBehaviour {
	public Transform shipModel;
	private Quaternion _shipDefaultRotation;
	private float speedSpin = 0.7f;
	void Start () {
		_shipDefaultRotation = shipModel.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f, speedSpin);
		transform.Translate(new Vector3(0.3f, 0.3f, 0.0f));
	}
}
