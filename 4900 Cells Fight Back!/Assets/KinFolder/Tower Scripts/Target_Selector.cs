using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Selector : MonoBehaviour
{
    public Transform shotspawn;
    public Transform target;
    public GameObject currentEnemy;
    public bool isFiring = false;
    private Queue<GameObject> enemyList = new Queue<GameObject>();
    /*  
       We need a queue so the turrets target not only the first enemy that triggers the collider,
       but also targets the closest enemy to the player's spawn. Without a queue, the turrets will
       swap targets every time the collider is triggered regardless of whether the previous enemy
       was destroyed. 
    */

    // Start is called before the first frame update
    void Start()
    {
        shotspawn = transform.GetChild(0).transform;    // There's only 1 child object for all turrets
    }

    // Update is called once per frame
    void Update()
    {   
        if (target != null)
        {
            transform.right = target.position - shotspawn.position;     // Rotate towards target
            isFiring = true;
        }
        else
        {   
            if (enemyList.Count != 0)
            {
                target = enemyList.Dequeue().transform;
            }
            else
            {
                isFiring = false;
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)     // if enemy collides with turret's circle collider
    {
        if (other.TryGetComponent<EnemyMoveLeft>(out EnemyMoveLeft enemy))
        {
            newTarget(enemy.gameObject);    
        }
    }

    public void newTarget(GameObject go)
    {
        enemyList.Enqueue(go);      // Add the monster's gameobject to the queue
    }
}
