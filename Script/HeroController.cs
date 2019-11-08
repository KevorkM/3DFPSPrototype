using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

public GameObject bulletPrefab;


	void Start () {
		
	}
	


	void Update () {

		//to shoot
		if (Input.GetMouseButtonDown(0)){
			GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);


			BulletController bullet = bulletObject.GetComponent<BulletController>();

			bullet.Angle= this.transform.localEulerAngles.y;
            bulletObject.transform.position = new Vector3(
				this.transform.position.x + Mathf.Cos(-(bullet.Angle - 90) * Mathf.Deg2Rad) * 3,
				this.transform.position.y,
				this.transform.position.z+Mathf.Sin(-(bullet.Angle - 90) * Mathf.Deg2Rad) * 3

			);

        }
	}
}
