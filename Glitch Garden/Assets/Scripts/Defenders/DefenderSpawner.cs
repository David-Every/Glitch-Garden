using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	public Camera myCamera;
	
		private GameObject parent;

	void Start() {
		parent = GameObject.Find ("Defenders");
		
		if (!parent) {
			parent = new GameObject ("Defenders");
		}
	}

	
	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;
		
		newDef.transform.parent = parent.transform;
		
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick (){
		float mouseX = Input.mousePosition.x;
		float mousey = Input.mousePosition.y;
		float distanceFromCamara = 10f;
		
		Vector3 weirdTriplet = new Vector3 (mouseX, mousey, distanceFromCamara); 
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		
		return worldPos;
	
	}
}
