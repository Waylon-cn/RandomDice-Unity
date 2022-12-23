using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketGentleman : MonoBehaviour
{
        
    [SerializeField] private bool hasName;

    [TextArea(1, 3)] public string[] lines;
    [TextArea(1, 3)] public string[] linesInspiration;

    [SerializeField] private bool CommunicateOrInter;

    private Collision2D _other;
    public bool isEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_other != null && _other.gameObject.GetComponent<PlayerController>() == GameEventSystem.instance.Adviser)
        {
            if (_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered &&
                !_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().DialogUI
                    .activeInHierarchy && _other.gameObject.GetComponent<PlayerController>()._uiGo
                    .GetComponent<DialogSystem>().isConversation && isEntered)
            {
                if (_other.gameObject.GetComponent<PlayerController>().intelligence +
                    _other.gameObject.GetComponent<PlayerController>().PhysicalStrength > 175)
                    _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                        .ShowDialogue(linesInspiration, hasName);
                else
                {
                    _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                        .ShowDialogue(lines, hasName);
                }
            }
            else if (_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered &&
                     !_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                         .isConversation && !_other.gameObject.GetComponent<PlayerController>()._uiGo
                         .GetComponent<DialogSystem>().ConversationUI
                         .activeInHierarchy && isEntered)
            {
                _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowToConversation(CommunicateOrInter);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameEventSystem.instance.Pastor = true;
        _other = other;
        isEntered = true;
        if (other.gameObject.CompareTag("Player"))
        {
            _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _other = other;
        isEntered = false;
        if (other.gameObject.CompareTag("Player"))
        {
            _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered = false;
        }
        other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().CloseToConversation();
    }
}
