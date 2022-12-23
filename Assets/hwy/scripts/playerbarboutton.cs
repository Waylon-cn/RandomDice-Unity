using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerbarboutton : MonoBehaviour
{
    public Button playbar;
    [SerializeField] private bool isOpen;
    public GameObject playattribute;
    // Start is called before the first frame update
    void Start()
    {
        playbar.onClick.AddListener(ShowSkills);
        playattribute.SetActive(isOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowSkills()
    {
        isOpen = !isOpen;
        playattribute.SetActive(isOpen);
    }
}
