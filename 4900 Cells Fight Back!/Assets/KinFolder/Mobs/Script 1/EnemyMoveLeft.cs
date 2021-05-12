using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveLeft : MonoBehaviour
{
    public float basespeed = 1;
    private float speed;
    private float speedMod;
    private float slowCountdown = 0;
    public bool MoveLeft;
    public float startHealth = 100;
    private float health;
    public GameObject FloatingText;
    public GameObject deathEffect;
    public GameObject gameManager;
    public int mobCost = 100;
    PurchaseManager purchaseManager;

	[Header("Enemy Stuff")]
	public Image healthBar;

    public string mobType;

    // Start is called before the first frame update
    void Start()
    {
	health = startHealth;
	speed = basespeed;
    }

    // Update is called once per frame
    void Update()
    {   

	if (slowCountdown <= 0)     // no slows applied
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speedMod, 0, 0);
        }
        slowCountdown -= Time.deltaTime;

    }

    public void damageEnemy(float damage)
    {
	var go = Instantiate(FloatingText, transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;
        go.GetComponent<TextMesh>().text = damage.ToString();
        Destroy(go, 1f);
        health -= damage;
	healthBar.fillAmount = health/startHealth;
        if (health <= 0)
        {
	
	DeathEffect(deathEffect);
   	PurchaseManager.playerMoney += mobCost;
	Destroy(gameObject);
        }

    }
	private void DeathEffect(GameObject deathEffect)
{
	if (deathEffect != null)
	{
	GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
	WaveSpawn.EnemiesAlive--;
	Destroy(effect, 1f);
}
}
	
    public void slow(float slowAmount, float slowDuration)
    {
        speedMod = speed * slowAmount;
        slowCountdown = slowDuration;
    }
}