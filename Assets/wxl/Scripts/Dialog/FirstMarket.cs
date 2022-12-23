using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMarket : MonoBehaviour
{
    [SerializeField] private bool hasName;

    [TextArea(1, 3)] public string[] lines;

    private Collision2D _other;

    private bool IsFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsFirst)
            other.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(lines, hasName);
        IsFirst = false;
    }
}
