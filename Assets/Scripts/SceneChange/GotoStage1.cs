using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage1 : MonoBehaviour
{
    /*
    void Start()
    {
        Invoke("sceneChange", 2);
    }
    */
    public void SceneChange()
    {
        SceneManager.LoadScene("GameStart"); // 씬 이름 수정하기
    }
}
