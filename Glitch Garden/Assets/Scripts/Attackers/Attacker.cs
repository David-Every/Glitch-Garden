using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("This defines the Rarity of the Attacker Spawning")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// This makes the Attackers move left but when there is currentTarget the movement stops and the Attacker starts attacking the Defender 
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
		
	}
	
	void OnTriggerEnter2D (){
	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	// Called From Animator at time of actual Attack
	 public void StrikeCurrentTarget (float damage){
	 	if (currentTarget) {
	 		// this gets the specific Defenders Heath
			Health health = currentTarget.GetComponent<Health>();
			//if the Health script is found on the defender
			if (health) {
			// deals the defender damage
				health.DealDamage (damage);
			}
		}
	}
	// this sets the Current target to "obj" so Current target can be called by using "obj"
	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}
