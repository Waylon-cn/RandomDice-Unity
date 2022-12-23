using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    //门的控制器
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // animator.SetBool("IsOpen", IsOpen);
        // IsOpen = !IsOpen;
        SceneManager.LoadScene(3);
    }
}
