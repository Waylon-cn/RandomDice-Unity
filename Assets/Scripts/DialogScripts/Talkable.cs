using UnityEngine;

public class Talkable : MonoBehaviour
{
    
    [SerializeField] private bool hasName;

    [TextArea(1, 3)] public string[] lines;

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
        if (_other != null)
        {
            if (_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered &&
                !_other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().DialogUI
                    .activeInHierarchy && _other.gameObject.GetComponent<PlayerController>()._uiGo
                    .GetComponent<DialogSystem>().isConversation && isEntered)
            {
                if (GameEventSystem.instance.DiscussionRoomToMap == 2)
                    GameEventSystem.instance.LionHunter.SetActive(false);
                _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(lines, hasName);
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
        if (other.gameObject.CompareTag("Player"))
        {
            _other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().isEntered = false;
        }
        isEntered = false;
        other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().CloseToConversation();
    }
}
