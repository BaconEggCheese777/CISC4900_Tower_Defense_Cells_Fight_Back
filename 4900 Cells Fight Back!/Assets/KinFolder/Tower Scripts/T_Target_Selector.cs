using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Target_Selector : MonoBehaviour
{
    public Transform shotspawn;
    public Transform target;
    public GameObject currentEnemy;
    public bool isFiring = false;
    private Queue<GameObject> enemyList = new Queue<GameObject>();
    private Queue<GameObject> enemyListInfected = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        shotspawn = transform.GetChild(0).transform;    // There's only 1 child object for all turrets
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyListInfected.Count != 0)   // Prioritizes queue with Infected mobs
        {
            if (enemyListInfected.Peek() != null)
            {
                target = enemyListInfected.Peek().transform;
                transform.right = target.position - shotspawn.position;
                isFiring = true;
                Debug.Log("First one");
            }
            else
            {
                enemyListInfected.Dequeue();
            }
        }
        else   // No more mobs in the first queue, check second
        {
            if (enemyList.Count != 0)
            {
                if (enemyList.Peek() != null)
                {
                    target = enemyList.Peek().transform;
                    transform.right = target.position - shotspawn.position;
                    isFiring = true;
                    Debug.Log("Second one");
                }
                else
                {
                    enemyList.Dequeue();
                }
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
            if (enemy.gameObject.name == "Infection(Clone)")    // Second queue
            {
                enemyListInfected.Enqueue(enemy.gameObject);
            }
            newTarget(enemy.gameObject);
        }
    }

    public void newTarget(GameObject go)
    {
        enemyList.Enqueue(go);      // Add the monster's gameobject to the queue
    }
}
