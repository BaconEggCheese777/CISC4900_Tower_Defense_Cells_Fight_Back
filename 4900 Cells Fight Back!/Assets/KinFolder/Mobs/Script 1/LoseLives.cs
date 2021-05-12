using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLives : MonoBehaviour
{
 void OnTriggerEnter2D (Collider2D col)
{
	if (col.TryGetComponent<EnemyMoveLeft>(out EnemyMoveLeft enemy))
{
	GameControlScript.lives -= 1;
	WaveSpawn.EnemiesAlive--;
	Destroy(enemy.gameObject);
}
}

}
