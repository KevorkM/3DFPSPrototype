using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour {

public Vector3 chaseDirection;

public float speed = 3f;

public Action onDestroyed;
public Action onHitPlayer;

	void Start () {
		
	}
	
	void Update () {
		this.transform.position = new Vector3(
            this.transform.position.x + (chaseDirection.x*speed),
            this.transform.position.y,
            this.transform.position.z+(chaseDirection.z * speed)

		);
	}

	public void OnTriggerEnter(Collider col) {
		if (col.gameObject.GetComponent<BulletController>()!=null){
			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(col.gameObject);
		
			onDestroyed();
		}
		if (col.gameObject.GetComponent<HeroController>()!=null){
			GameObject.Destroy(col.gameObject);
			onHitPlayer();
		}
	}
}
