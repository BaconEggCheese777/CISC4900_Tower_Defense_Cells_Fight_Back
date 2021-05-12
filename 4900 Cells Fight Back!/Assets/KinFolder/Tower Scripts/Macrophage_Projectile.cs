using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophage_Projectile : MonoBehaviour
{
    public float speed = 5;
    private float size = 3f;
    public GameObject explosionCollision;
    public GameObject explosionClone;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        GrowAccelerate();
    }

    void GrowAccelerate()
    {
        size += 0.01f;
        speed += 0.01f;
        transform.localScale = new Vector2(size, size);
    }

    // Add collider method. If true, modify speed to 1

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyMoveLeft>(out EnemyMoveLeft enemy))
        {
            explosionClone = Instantiate(explosionCollision, collision.transform.position, transform.rotation);
            Destroy(explosionClone, 0.5f);
            enemy.damageEnemy(10);
            enemy.slow(.5f, 3f);    // 50% slow for 3 seconds
            speed = 1;
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 3f);
        }
    }
}
