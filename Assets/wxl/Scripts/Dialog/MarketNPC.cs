using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketNPC : MonoBehaviour
{
    [SerializeField] private bool hasName;

    [TextArea(1, 3)] public string[] lines;

    [SerializeField] private bool CommunicateOrInter;
    //����1
    public string Question1;
    //����2
    public string Question2;
    //�����������Ļش�1
    [TextArea(1,3)] public string[] Rely1;
    //�����������Ļش�2
    [TextArea(1,3)] public string[] Rely2;

    private Collision2D _other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_other !=null && _other.gameObject.GetComponent<PlayerController>() == GameEventSystem.instance.Adviser)
        {
            if (_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEnterConversation &&
                !_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().DialogUI
                    .activeInHierarchy && _other.gameObject.GetComponent<PlayerController>()._uiGo
                    .GetComponent<DialogSystem>().isConversation)
            {
                
                
                _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .RelyQuestion(hasName);
            }
            else if (_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEnterConversation &&
                     !_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                         .isConversation && !_other.gameObject.GetComponent<PlayerController>()._uiGo
                         .GetComponent<DialogSystem>().Question1
                         .activeInHierarchy)
            {
                _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowToAsk();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //����Ѿ��Ի���
        GameEventSystem.instance.Pedestrian = true;
        _other = other;
        _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().QuestionText1.text = Question1;
        _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().QuestionText2.text = Question2;
        _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().Rely1 = Rely1;
        _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().Rely2 = Rely2;
        if (other.gameObject.CompareTag("Player"))
        {
            _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEnterConversation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _other = other;
        if (other.gameObject.CompareTag("Player"))
        {
            _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEnterConversation = false;
        }
        other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().CloseAsk();
    }
}
