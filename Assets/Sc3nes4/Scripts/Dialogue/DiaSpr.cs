using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DiaSprr
{
    [TextArea]
    public string dialogue;
    public string name;
    public Sprite cg;
}

public class DiaSpr : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private SpriteRenderer sprite_NameBox;
    [SerializeField] private Text txt_Name;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Title;

    [SerializeField] private SpriteRenderer sprite_BackImage;

    [SerializeField] private Button button_Skip;
    [SerializeField] private Button button_SceneChange;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private DiaSprr[] dialogue;

    public void ShowDialogue()
    {
        ONOFF(true);
        count = 0;
        NextDialogue();
    }

    private void ONOFF(bool _flag)
    {
        sprite_StandingCG.gameObject.SetActive(_flag);
        sprite_BackImage.gameObject.SetActive(!_flag);
        button_Skip.gameObject.SetActive(_flag);
        button_SceneChange.gameObject.SetActive(!_flag);
        txt_Title.gameObject.SetActive(!_flag);

        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //txt_Name.text = dialogue[count].name;
        //txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count++;
    }

    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (count < dialogue.Length) NextDialogue();
                else ONOFF(false);
            }
        }
    }
}
