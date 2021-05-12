using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Projectile : MonoBehaviour
{
    public float speed = 2000;
    public Animator anim;
    public GameObject pierceAnim;
    private GameObject pierceAnimClone;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyMoveLeft>(out EnemyMoveLeft enemy))
        {
            pierceAnimClone = Instantiate(pierceAnim, collision.transform.position, transform.rotation);
            Destroy(pierceAnimClone, 0.25f);
            if (enemy.gameObject.name == "Finish Infection(Clone)")
            {
                enemy.damageEnemy(500);
            }
            else
            {
                enemy.damageEnemy(50);
            }
            
            //speed = 0;
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
