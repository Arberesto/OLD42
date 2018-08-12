using System;
using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;

public class planetController : MonoBehaviour {
	bool isShipLanded = false;
	public SpriteRenderer shipModel;
	public Sprite newSprite;
	public Sprite shipSprite;
	public Sprite PlanetSprite;
	bool isAvailableForLanding = true;
	int wasLanding = 0;
	SpriteRenderer planetSprite;
	float BanCharge = 0f;
	float MaxBanCharge = 8f;
	float ChargePerSecond = 1f;
	int MaxNumOfLanding = 4;
	int CurrentNumOfLanding = 0;
	void Awake(){
		planetSprite = GetComponent<SpriteRenderer> ();
	}
	void FixedUpdate () {
		if (isShipLanded) {
			BanCharge += ChargePerSecond;
			if (BanCharge >= MaxBanCharge) {
				BanHammer ();
			}
		} else {
			BanCharge -= ChargePerSecond * 0.05f;
		}
		planetSprite.sprite = shipSprite;
	}

	void Update() {
		if (wasLanding > 0) {
			wasLanding -= 1;
			CurrentNumOfLanding += 1;
			if (CurrentNumOfLanding >= MaxNumOfLanding) {
				BanHammer();
			}
		}
	}

	void Landing () {
		wasLanding += 1;
		planetSprite.sprite = shipSprite;
		shipModel.enabled = false;
	}

	void ReleaseShip () {
		planetSprite.sprite = PlanetSprite;
		shipModel.enabled = true;
	}
		
	void BanHammer(){
		planetSprite.sprite = newSprite;

	}
}