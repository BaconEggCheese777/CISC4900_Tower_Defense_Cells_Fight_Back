using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingBack : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
