using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {

	public GameObject Hero;
	public GameObject enemyPrefab;

	public Text infoText;

	private float enemySpawnDistance = 15f;
	private float enemyTimer = 0;
	private float enemySpawnInterval = 1f;

	private int score = 0;

	void Start () {
		
		
	}
	

	void Update () {
		if (Input.GetKeyDown("r")){
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		enemyTimer -= Time.deltaTime;
		if (enemyTimer<=0 && Hero !=null){
			enemyTimer = enemySpawnInterval;

		float spawnAngle = Random.Range(0,360);

		// to create the enemy
        GameObject enemyObject = GameObject.Instantiate<GameObject>(enemyPrefab);
        
		// to spawn the enemy at a certain distance around the player
		enemyObject.transform.position = new Vector3(
			Hero.transform.position.x +Mathf.Cos(spawnAngle)*enemySpawnDistance,
			Hero.transform.position.y,
			Hero.transform.position.z + Mathf.Sin(spawnAngle) * enemySpawnDistance

		);
		//to chase the player
		EnemyController enemy = enemyObject.transform.GetComponent<EnemyController>();
		enemy.chaseDirection = ( Hero.transform.position-enemy.transform.position).normalized;

		enemy.onDestroyed = ()=>{
			score += 100;

			infoText.text = "Score: " + score.ToString();
		};
		enemy.onHitPlayer = ()=>{
			infoText.text = "Game Over! Press R to restart";

			Time.timeScale = .5f;
		};
        }
	}
}
