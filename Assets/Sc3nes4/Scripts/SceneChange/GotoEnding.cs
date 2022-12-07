using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoEnding : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Ending");
    }
}
