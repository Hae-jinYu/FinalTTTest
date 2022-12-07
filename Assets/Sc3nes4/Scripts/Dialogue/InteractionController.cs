using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    bool isContact = false;
    public static bool isInteract = false;

    DialogueManager theDM;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckObject();
        ClickLeftBtn();
    }

    void CheckObject()
    {
        Vector3 t_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if(Physics.Raycast(cam.ScreenPointToRay(t_MousePos), out hitInfo, 100))
        {
            Contact();
        }
        else
        {
            NotContact();
        }
    }

    void Contact()
    {
        if (hitInfo.transform.CompareTag("interaction"))
        {
            if (!isContact)
            {
                isContact = true;
            }
        }
        else
        {
            NotContact();
        }
    }

    void NotContact()
    {
        if (isContact)
        {
            isContact = false;
        }
    }

    void ClickLeftBtn()
    {
        if (!isInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isContact)
                {
                    Interact();
                }
            }
        }
    }

    void Interact()
    {
        isInteract = true;

        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
