using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turret_Preview : MonoBehaviour
{    
    // To be attached to the turret preview prefabs

    public Rigidbody2D rigid;
    private Vector3 mouseXY;
    private Vector2 direction;
    private Vector2 movement;
    private GameObject turretSpot;
    private bool mouseOverTurretSpot = false;
    private float speed = 50f;
    private Turret_Spot targetTS;

    private int turret1price = 500;
    private int turret2price = 500;
    private int turret3price = 500;
    private int turret4price = 500;
    private int turret5price = 500;

    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;
    public GameObject turret5;

    public GameObject insufficientFundsText;

    private void Awake()
    {
        insufficientFundsText = GameObject.Find("NoMoneyText");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followMouse();
        checkMouseClick();
    }

    // Create a method that spawns a turret on click based on this preview's name. Fetch the name
    //       with gameObject.name


    void followMouse()
    {
        mouseXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseXY - transform.position);
        movement = new Vector2(direction.x * speed, direction.y * speed);
        rigid.velocity = movement;
    }
    private void OnTriggerStay2D(Collider2D collision) // called nonstop until another collider exits this one
    {
        if (collision.TryGetComponent<Turret_Spot>(out Turret_Spot ts))
        {
            turretSpot = ts.gameObject;
            targetTS = ts;
            mouseOverTurretSpot = true;
        }
    }

    private void OnTriggerExit2D()
    {
        mouseOverTurretSpot = false;
    }

    void checkMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseOverTurretSpot == true)    // If mouse is hovering over a turret
            {   
                if (targetTS.mounted == false)
                {
                    Debug.Log("Found Free Turret Spot!");
                    spawnTurret(gameObject.name);

                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;

                    Destroy(gameObject, 3); // Delays destruction to finish running co-routine
                }

            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void spawnTurret(string name)
    {
        switch(name)
        {
            case "Tower_Preview1(Clone)":
                Debug.Log("Turret 1");
                if (PurchaseManager.tryBuy(turret1price))
                {
                    Instantiate(turret1, turretSpot.transform.position, transform.rotation);
                    turretSpot.GetComponent<Turret_Spot>().mounted = true;
                }
                else
                { 
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case "Tower_Preview2(Clone)":
                Debug.Log("Turret 2");
                if (PurchaseManager.tryBuy(turret2price))
                {
                    Instantiate(turret2, turretSpot.transform.position, transform.rotation);
                    turretSpot.GetComponent<Turret_Spot>().mounted = true;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case "Tower_Preview3(Clone)":
                Debug.Log("Turret 3");
                if (PurchaseManager.tryBuy(turret3price))
                {
                    Instantiate(turret3, turretSpot.transform.position, transform.rotation);
                    turretSpot.GetComponent<Turret_Spot>().mounted = true;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case "Tower_Preview4(Clone)":
                Debug.Log("Turret 4");
                if (PurchaseManager.tryBuy(turret4price))
                {
                    Instantiate(turret4, turretSpot.transform.position, transform.rotation);
                    turretSpot.GetComponent<Turret_Spot>().mounted = true;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case "Tower_Preview5(Clone)":
                Debug.Log("Turret 5");
                if (PurchaseManager.tryBuy(turret5price))
                {
                    Instantiate(turret5, turretSpot.transform.position, transform.rotation);
                    turretSpot.GetComponent<Turret_Spot>().mounted = true;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
        }
        
    }

    IEnumerator flashInsufficientFundsText()
    {
        Debug.Log("Trying");
        insufficientFundsText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2);
        insufficientFundsText.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
        // I chose this method of displaying the text because non-instanced prefabs cannot 
        // reference any instanced GameObjects. Otherwise, I would've used gameObject.setActive()
    }
}
