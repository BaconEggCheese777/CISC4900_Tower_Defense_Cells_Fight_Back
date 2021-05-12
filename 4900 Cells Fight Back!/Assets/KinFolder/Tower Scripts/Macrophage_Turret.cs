using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophage_Turret : MonoBehaviour
{
    public GameObject macrophage_proj;
    private GameObject proj;
    public Transform shotspawn;
    private float cooldown = 10f;
    private float cooldownRemain;
    public Animator animator;
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTargetAndFire();
    }

    void Fire()
    { 

        if (cooldownRemain <= 0)
        {
            Audio.Play();
            animator.SetTrigger("Fire");
            proj = Instantiate(macrophage_proj, shotspawn.position, transform.rotation) as GameObject;
            cooldownRemain = cooldown;
        }
        else
        {
            cooldownRemain -= Time.deltaTime;
            animator.SetTrigger("Stop");
        }

    }

    void haltFire()
    {
        Audio.Stop();
    }

    void FindTargetAndFire()
    {
        if (gameObject.TryGetComponent<Target_Selector>(out Target_Selector targeter))
        {
            if (targeter.isFiring == true)
            {
                Fire();
            }
            else
            {
                haltFire();
            }
        }
    }
}
