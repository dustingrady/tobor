﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {

	// The item that the player collects when they touch the item
	public Item item; 

	// Destroy the object when a player collects the item
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

	// Set the correct sprite when level loads
	void Start() {
		GetComponent<SpriteRenderer> ().sprite = item.sprite;
	}

	/*
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}*/
}
