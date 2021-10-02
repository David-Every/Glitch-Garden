using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start (){
		animator = GameObject.FindObjectOfType<Animator>();
		
		projectileParent = GameObject.Find("Projectiles");
		
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
	}	
	
	//look through all spawners and set myLaneSpawner if found
	void setMyLaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<spawner>();
		foreach (Spawner spawner in spawnerArray){
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " cant find spawner in lane");
	}
	
	void Update () {
		if (isAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		}else{
			animator.SetBool ("isAttacking", false);
		}
	}
	
	bool isAttackerAheadInLane() {
		return false;
	}
	
	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject ;
		newProjectile.transform.parent =  projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
