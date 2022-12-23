using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkablePresidentAdventurer : MonoBehaviour
{
    [SerializeField] private bool isEntered;
    [SerializeField] private bool hasName;

    [TextArea(1, 3)] public string[] lines;

    [SerializeField] private bool CommunicateOrInter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isEntered && !DialogSystem.instance.DialogUI.activeInHierarchy && DialogSystem.instance.isConversation)
        // {
        //     DialogSystem.instance.ShowDialogue(lines, hasName);
        // }
        // else if(isEntered && !DialogSystem.instance.isConversation)
        // {
        //     //DialogSystem.instance.ShowDialogue(lines, hasName);
        //     DialogSystem.instance.ShowToConversation(CommunicateOrInter);
        // }
        // else
        // {
        //     DialogSystem.instance.CloseToConversation();    
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = true;
        }

        if (isEntered &&
            !other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab.GetComponent<DialogSystem>().DialogUI
                .activeInHierarchy && other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab
                .GetComponent<DialogSystem>().isConversation)
        {
            other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab.GetComponent<DialogSystem>().ShowDialogue(lines, hasName);
        }
        else if(isEntered && !other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab.GetComponent<DialogSystem>().isConversation)
        {
            //DialogSystem.instance.ShowDialogue(lines, hasName);
            other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab.GetComponent<DialogSystem>().ShowToConversation(CommunicateOrInter);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
        }
        other.gameObject.GetComponent<PlayerController>().PlayerUiPrefab.GetComponent<DialogSystem>().CloseToConversation();    
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isEntered = true;
    //     }
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isEntered = false;
    //         DialogSystem.instance.CloseToConversation();   
    //     }
    // }
}