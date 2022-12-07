using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue[] dialogues;

    bool isDialogue = false; // 대화중일 경우 true
    bool isNext = false; // 특정 키 입력 대기

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int lineCount = 0; // 대화 카운트
    int contextCount = 0; // 대사 카운트 
    
    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    if(++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;
                        if(++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

   public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());

    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUI(false);
    }
    
    IEnumerator TypeWriter()
    {
        SettingUI(true);

        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        t_ReplaceText = t_ReplaceText.Replace("\\n", "\n");

        txt_Name.text = dialogues[lineCount].name;

        bool t_white = false, t_blue = false;
        bool t_ignore = false;

        for(int i = 0; i < t_ReplaceText.Length; i++)
        {
            switch (t_ReplaceText[i])
            {
                case 'ⓦ': t_white = true; t_blue = false; t_ignore = true; break;
                case 'ⓑ': t_white = false; t_blue = true; t_ignore = true; break;
            }

            string t_letter = t_ReplaceText[i].ToString();

            if (!t_ignore)
            {
                if (t_white)
                {
                    t_letter = "<color=#000000>" + t_letter + "</color>";
                }
                else if(t_blue)
                {
                    t_letter = "<color=#417CDB>" + t_letter + "</color>";
                }
                txt_Dialogue.text += t_letter;
            }
            t_ignore = false;

            yield return new WaitForSeconds(textDelay);
        }

        isNext = true;
        yield return null;
    }

    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
