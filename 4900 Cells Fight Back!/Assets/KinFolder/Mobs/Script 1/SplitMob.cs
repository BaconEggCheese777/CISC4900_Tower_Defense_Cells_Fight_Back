using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMob : MonoBehaviour
{
    public GameObject smallSplitter; 
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
timer += Time.deltaTime;
if (timer > 8f)
{ 
        int x = Random.Range(3, 5);
	for (int i = 0; i < x; i++)
{
	Instantiate(smallSplitter, transform.position + new Vector3(i * 3, 0, 0) , transform.rotation);
     Destroy(gameObject);
	}
    }
}
}
