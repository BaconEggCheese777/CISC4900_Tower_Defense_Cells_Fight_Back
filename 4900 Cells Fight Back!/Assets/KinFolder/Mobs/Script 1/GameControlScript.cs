using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
	public GameObject hearts;
	public GameObject hearts1;
	public GameObject hearts2;
	public GameObject hearts3;
	public GameObject hearts4;
	public static int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (true);
	hearts2.gameObject.SetActive (true);
	hearts3.gameObject.SetActive (true);
	hearts4.gameObject.SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
	//Debug.Log(lives);
        if (lives > 5)
	lives = 5;

	switch (lives) {

	case 5:
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (true);
	hearts2.gameObject.SetActive (true);
	hearts3.gameObject.SetActive (true);
	hearts4.gameObject.SetActive (true);
	break;

	case 4:
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (true);
	hearts2.gameObject.SetActive (true);
	hearts3.gameObject.SetActive (true);
	hearts4.gameObject.SetActive (false);
	break;


	case 3:
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (true);
	hearts2.gameObject.SetActive (true);
	hearts3.gameObject.SetActive (false);
	hearts4.gameObject.SetActive (false);
	break;

	case 2:
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (true);
	hearts2.gameObject.SetActive (false);
	hearts4.gameObject.SetActive (false);
	hearts3.gameObject.SetActive (false);
	break;
	
	case 1:
	hearts.gameObject.SetActive (true);
	hearts1.gameObject.SetActive (false);
	hearts2.gameObject.SetActive (false);
	hearts3.gameObject.SetActive (false);
	hearts4.gameObject.SetActive (false);
	break;

	case 0:
	hearts.gameObject.SetActive (false);
	hearts1.gameObject.SetActive (false);
	hearts2.gameObject.SetActive (false);
	hearts3.gameObject.SetActive (false);
	hearts4.gameObject.SetActive (false);
        SceneManager.LoadScene("GameOver");
	break;
}
}
}