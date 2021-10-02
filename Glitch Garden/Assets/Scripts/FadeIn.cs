using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;
	
	void Start() {
		fadePanel = GetComponent<Image>();
	}
	
	void Update() {
		if (Time.timeSinceLevelLoad < fadeInTime) {
		//fade in
		float alphaChange = Time.deltaTime / fadeInTime; // the proportion of the change per frame
		currentColor.a -= alphaChange;
		fadePanel.color = currentColor;
		
		} else {
			gameObject.SetActive (false);
		}	
  	}
}