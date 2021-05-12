using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
    [SerializeField] GameObject instructionsMenu;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}

        if (menuButtonController.index == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            //SceneManager.LoadScene("Game");
            instructionsMenu.SetActive(true);
        }
        if (menuButtonController.index == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Settings");
        }
        if (menuButtonController.index == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
