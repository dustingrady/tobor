﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReverseHidden : MonoBehaviour {
	public Sprite replacementSprite;
	public GameObject room;
	public bool buttonPress = false;
	private bool fading = false;
	bool displayText = false;
	Material m;

	void Start()
	{
		m = room.GetComponent<TilemapRenderer> ().material;
	}

	void Update()
	{
		if (buttonPress) {
			if (Input.GetKeyDown (KeyCode.E)) {
				buttonPress = false;
			}
		} else {
			fadeTrigger ();
		}
	}

	void fadeTrigger()
	{
		if (fading) {
			if (m.color.a >= 0) {
				m.color = new Color (m.color.r, m.color.g, m.color.b, Mathf.Lerp (m.color.a, 0, Time.deltaTime * 4f));
			}
			if (m.color.a <= 0.01) {
				if (room.GetComponent<TilemapCollider2D> () != null) {
					room.GetComponent<TilemapCollider2D> ().enabled = false;
				}

				fading = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		float height = GetComponent<BoxCollider2D> ().size.y; 
		if (col.tag == "Player") {
			//Debug.Log ("wat");
			// replace sprite
			if (GetComponent<SpriteRenderer> () != null) {
				GetComponent<SpriteRenderer>().sprite = replacementSprite;
			}

			// show floating text
			if (!displayText) {
				FloatingTextController.CreateFloatingText ("Hidden Room Uncovered!", this.gameObject.transform, height, Color.blue, 20);
				displayText = true;
			}
			// enable fading
			fading = true;
		}

	}
}
