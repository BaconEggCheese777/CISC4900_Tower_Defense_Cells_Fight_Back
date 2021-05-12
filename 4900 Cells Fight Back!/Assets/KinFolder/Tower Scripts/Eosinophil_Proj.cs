using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eosinophil_Proj : MonoBehaviour
{
    public float speed = 2;
    public Animator anim;

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
            enemy.damageEnemy(10); // Damage defined here
            speed = 0;
            anim.SetTrigger("madeContact");
            //GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
