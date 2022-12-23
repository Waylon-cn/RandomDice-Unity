using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class Dramatext : MonoBehaviour
{
    public TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        string txt = File.ReadAllText(Application.streamingAssetsPath + "/drama.txt");

        t.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
