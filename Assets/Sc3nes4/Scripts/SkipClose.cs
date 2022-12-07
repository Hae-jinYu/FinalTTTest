using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipClose : MonoBehaviour
{
    public GameObject skip;
    public GameObject set;

    public void ClosePanel()
    {
        skip.SetActive(false);
    }

    public void talkdown()
    {
        skip.SetActive(false);
        set.SetActive(false);
    }
}
