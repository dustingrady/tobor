﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Magnet : MonoBehaviour {
	float speed;
	public Vector3 direction;

	public void Initialize(Vector2 direction, float speed) {
		this.speed = speed;
		this.direction = direction.normalized;

		// Change the angle to match the direction.
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update() {
		transform.position += direction * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "Player" && col.gameObject.tag != "Metal" ) {
			DestroyObject (this.gameObject);
		} else if(col.gameObject.tag == "Metal") {
			Debug.Log ("Grapple to Target.");
		}
	}
}
