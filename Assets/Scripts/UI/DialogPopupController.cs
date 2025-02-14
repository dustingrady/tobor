﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopupController : MonoBehaviour {

	private static GameObject dialogPopup;
	private static GameObject canvas;

	public static void Initialize(){
		canvas = GameObject.Find("UI");
		if (!dialogPopup) {
			dialogPopup = Resources.Load<GameObject> ("Prefabs/UI/DialogueDisplay");
		}
	}

	public static void CreateDialogPopup(string msg, float duration){
		GameObject instance = Instantiate (dialogPopup);
		instance.gameObject.GetComponentInChildren<Text> ().text = msg;
		instance.transform.SetParent (canvas.transform, false);
		Destroy (instance, duration);
	}

	public static void CreateDialogPopupLocation(string msg, float duration, Vector3 position){
		GameObject instance = Instantiate (dialogPopup);
		instance.gameObject.GetComponentInChildren<Text> ().text = msg;
		instance.transform.SetParent (canvas.transform, false);
		instance.transform.position = new Vector3(400f, 75f, 0f);
		Destroy (instance, duration);
	}
}
