using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell_Preview: MonoBehaviour
{
    private int sellPrice1 = 250;
    private int sellPrice2 = 250;
    private int sellPrice3 = 250;
    private int sellPrice4 = 250;
    private int sellPrice5 = 250;

    // To be attached to the sell sprite prefab
    public Rigidbody2D rigid;
    private Vector3 mouseXY;
    private Vector2 direction;
    private Vector2 movement;
    private GameObject turret;
    private bool mouseOverTurret = false;
    private float speed = 50f;  // setting speed too high causes the sprite to glitch
    private Turret_Spot targetTS;
    private string turretName;

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

    void followMouse()
    {
        mouseXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseXY - transform.position);
        movement = new Vector2(direction.x * speed, direction.y * speed);
        rigid.velocity = movement;
    }

    private void OnTriggerStay2D(Collider2D collision) // called nonstop until another collider exits this one
    {
        if (collision.TryGetComponent<Turret_Collider>(out Turret_Collider tc))
        {
            turret = tc.gameObject.transform.parent.gameObject;
            mouseOverTurret = true;
            turretName = turret.name;
        }
        if (collision.TryGetComponent<Turret_Spot>(out Turret_Spot ts))
        {
            targetTS = ts;
        }
    }

    private void OnTriggerExit2D()
    {
        mouseOverTurret = false;
    }

    void checkMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseOverTurret == true)    // If mouse is hovering over a turret
            {
                targetTS.mounted = false;
                PurchaseManager.playerMoney += sellPrice();
                Destroy(turret);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    int sellPrice()
    {
        switch(turretName)
        {
            case "Tower 1_0(Clone)":
                Debug.Log("Tower1 has been sold!");
                return sellPrice1;
            case "Tower 2_0(Clone)":
                Debug.Log("Tower2 has been sold!");
                return sellPrice2;
            case "Tower 3_0(Clone)":
                Debug.Log("Tower3 has been sold!");
                return sellPrice3;
            case "Tower 4_0(Clone)":
                Debug.Log("Tower4 has been sold!");
                return sellPrice4;
            case "Tower 5_0(Clone)":
                Debug.Log("Tower5 has been sold!");
                return sellPrice5;
        }

        return 0;
    }

}
