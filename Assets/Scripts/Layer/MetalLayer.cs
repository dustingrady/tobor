﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MetalLayer : Layer {

	private const int maxHitPoints = 1;
	public int hitpoints = maxHitPoints;
	private GameObject meltedMetal;

	// Use this for initialization
	void Start(){
		tilemap = GetComponent<Tilemap>();
		meltedMetal = (GameObject)Resources.Load("Prefabs/Particles/MeltedMetal");	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Lava"){
			hitpoints--;

			if (hitpoints <= 0) {
				DestroyBlock(col, anim : meltedMetal);
			}
		}
	}


	// Keep old destroy for HP code
	/*
	void destroyBlock(Collision2D col){
		Debug.Log ("Metal layer collision" + " " + col.contacts.Length);
		Vector3 hitPosition = Vector3.zero;
		Vector3Int cellPos = tilemap.WorldToCell (col.transform.position);
		if (tilemap != null && col.gameObject.name != "Player"){
			foreach (ContactPoint2D hit in col.contacts){
				hitPosition.x = hit.point.x;
				hitPosition.y = hit.point.y;
				cellPos = tilemap.WorldToCell (hitPosition);
				//tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
				//Destroy (col.gameObject);
			}

			if (Vector3Int.FloorToInt (oldPos) != Vector3Int.FloorToInt (cellPos)) {
				oldPos = cellPos;
				hitpoints = maxHitPoints;
				hitpoints--;
			} else if(Vector3Int.FloorToInt (oldPos) == Vector3Int.FloorToInt (cellPos)){
				if (hitpoints > 0) {
					hitpoints--;
				}
			}
				

			if (tilemap.GetTile(cellPos) != null && hitpoints == 0){
				hitpoints = maxHitPoints;

				// Delete tile
				tilemap.SetTile(cellPos, null);
				GameObject melt = Instantiate (meltedMetal, tilemap.GetCellCenterWorld(tilemap.WorldToCell(hitPosition)), Quaternion.identity);	//Replace the tile
				Destroy(melt, 2);
			}
		}
	}
	*/
}

