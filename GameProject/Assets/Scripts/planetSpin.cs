using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class planetSpin : MonoBehaviour {
	public Transform shipModel;
	private Quaternion _shipDefaultRotation;
	private float speedSpin = 0.7f;
	// Use this for initialization
	void Start () {
		_shipDefaultRotation = shipModel.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += 20;
		transform.rotation *= Quaternion.Euler(0f, 0f, speedSpin);
	}
}
