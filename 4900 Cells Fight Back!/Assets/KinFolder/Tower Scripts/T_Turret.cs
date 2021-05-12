using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Turret : MonoBehaviour
{
    public GameObject T_proj;
    private GameObject proj;
    public Transform shotspawn;
    private float cooldown = 4f;
    private float cooldownRemain;
    public Animator animator;
    public AudioSource Audio;
    //private bool animPlayed = false;

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
            proj = Instantiate(T_proj, shotspawn.position, transform.rotation) as GameObject;
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
        //Audio.Stop();
    }

    void FindTargetAndFire()
    {
        if (gameObject.TryGetComponent<T_Target_Selector>(out T_Target_Selector targeter))
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
