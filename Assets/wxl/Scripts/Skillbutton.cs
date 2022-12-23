using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skillbutton : MonoBehaviour
{   public Button m_Button;
    [SerializeField] private bool isOpen;
    [SerializeField] public GameObject skill1;
    [SerializeField] public GameObject skill2;
    [SerializeField] public GameObject skill3;
    [SerializeField] public GameObject skill4;

    // Start is called before the first frame update
    void Start()
    {
         m_Button.onClick.AddListener(ShowSkills);
         skill1.SetActive(isOpen);
         skill2.SetActive(isOpen);
         skill3.SetActive(isOpen);
         skill4.SetActive(isOpen);
    }

    // Update is called once per frame
    void Update()
    {
    } 
    private void ShowSkills()
    {
        isOpen = !isOpen;
        skill1.SetActive(isOpen);
        skill2.SetActive(isOpen);
        skill3.SetActive(isOpen);
        skill4.SetActive(isOpen);
    }
}
