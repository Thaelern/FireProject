using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene("Lasse_MainMenu", LoadSceneMode.Single);
    }

}
