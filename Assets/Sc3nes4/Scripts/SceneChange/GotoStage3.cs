using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoStage3 : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameStart"); // 씬 이름 수정하기
    }
}
