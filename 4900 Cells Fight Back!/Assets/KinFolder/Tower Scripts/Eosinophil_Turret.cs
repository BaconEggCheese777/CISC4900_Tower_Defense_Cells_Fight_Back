using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eosinophil_Turret : MonoBehaviour
{
    public GameObject eosin_proj;
    private GameObject proj;
    public Transform shotspawn;
    private float cooldownAutomatic = 0.08f; // time between rounds for Automatic mode
    private float cooldownBurst = 0.12f; // time between rounds for Burst mode
    private float timeBetweenBurst = 1f; // time between bursts
    private int burstSize = 3;
    private float cooldownRemain;
    private bool isFiring = false;
    public Animator animator;
    public AudioSource burstAudio;
    public AudioSource autoAudio;
    bool audioPlaying = false;
    bool fastFireMode = false;  // default is false if no parasites are present

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        FindTargetAndFire();
    }

    void FireAuto()
    {                       // Define max spread here
        float spread = Random.Range(-10, 10);
        Quaternion spreadRotation = Quaternion.Euler(new Vector3(0, 0, transform.localEulerAngles.z + spread));

        if (audioPlaying == false)
        {
            autoAudio.Play();
            audioPlaying = true;
        }

        animator.SetBool("isFiring", true);

        if (cooldownRemain <= 0)
        {
            proj = Instantiate(eosin_proj, shotspawn.position, spreadRotation) as GameObject;
            cooldownRemain = cooldownAutomatic;
        }
        else
        {
            cooldownRemain -= Time.deltaTime;
        }

    }

    public IEnumerator FireBurstFunc()
    {
        isFiring = true;    // This needs to be added so Update() waits before calling this function again
        float spread = Random.Range(-1, 1);
        Quaternion spreadRotation = Quaternion.Euler(new Vector3(0, 0, transform.localEulerAngles.z + spread));

        burstAudio.Play();
        animator.SetTrigger("Fire");
        for (int i = 0; i < burstSize; i++)
        {
            proj = Instantiate(eosin_proj, shotspawn.position, spreadRotation) as GameObject;
            yield return new WaitForSeconds(cooldownBurst); // wait for next round
        }
        animator.SetTrigger("Stop");
        yield return new WaitForSeconds(timeBetweenBurst); // wait for next burst
        isFiring = false;
    }

    void FireBurst()
    {
        if (isFiring == false)
        {
            StartCoroutine(FireBurstFunc());
        }
    }

    void haltFire()
    {
        burstAudio.Stop();
        autoAudio.Stop();
        audioPlaying = false;
        animator.SetBool("isFiring", false);
    }

    void FindTargetAndFire()
    {
        if (gameObject.TryGetComponent<Target_Selector>(out Target_Selector targeter))
        {
            if (targeter.isFiring == true)
            {

                Fire();    // This will need to be changed later. Needs to swap fire modes based on enemy type
            }
            else
            {
                haltFire();
            }
        }
    }

    void Fire()
    {
        if (fastFireMode)
        {
            FireAuto();
        }
        else
        {
            FireBurst();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)  // set fire mode based on the presence of parasites
    {
        if (collision.TryGetComponent<EnemyMoveLeft>(out EnemyMoveLeft enemyScript))
        {
            if (enemyScript.mobType == "parasite")
            {
                fastFireMode = true;
            }
            else
            {
                fastFireMode = false;
            }
        }

            
    }
}
