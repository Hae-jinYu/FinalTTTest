using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoGameStart : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameStart");
    }
}
