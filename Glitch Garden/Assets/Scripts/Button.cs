using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private Button[] buttonArray;
	
	void Start () { 
		//this finds evertthing that has the "Button" script 
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	void OnMouseDown () {
		//sets all unclicked buttons to Black
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		//sets the clicked button to white meaning the button is its default colour
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		//print (selectedDefender);
		// moved ^ to Attacker script
	
	}
}