using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textObject1;
    public GameObject textObject2;

    public GameObject upgradeTextObject1;
    public GameObject upgradeTextObject2;
    public GameObject upgradeTextObject3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
        switch (gameObject.name)
        {
            case "Buy Turrets Button":
                textObject1.SetActive(true);
                break;
            case "Sell Turrets Button":
                textObject2.SetActive(true);
                break;
            case "Add Turret Spots Button":
                if (gameObject.GetComponent<BuySell_Button>().turretSpotCount == 1)
                {
                    upgradeTextObject1.SetActive(true);
                }
                if (gameObject.GetComponent<BuySell_Button>().turretSpotCount == 2)
                {
                    upgradeTextObject2.SetActive(true);
                }
                if (gameObject.GetComponent<BuySell_Button>().turretSpotCount == 3)
                {
                    upgradeTextObject3.SetActive(true);
                }
                break;
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        textObject1.SetActive(false);
        textObject2.SetActive(false);
        upgradeTextObject1.SetActive(false);
        upgradeTextObject2.SetActive(false);
        upgradeTextObject3.SetActive(false);

    }
}
