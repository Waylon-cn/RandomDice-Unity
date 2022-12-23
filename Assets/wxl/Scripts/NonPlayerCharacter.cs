using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    // 添加对话框显示时长
    public float displayTime = 4.0f;
    //获取对话框
    public GameObject dialogBox;
    //创建一个游戏对象，来获取TMP控件
    public GameObject dlgTxtProGameObject;
    
    //创建游戏组件类对象
    private TextMeshProUGUI _tmTxBox;
    //设置变量存储当前页数
    private int _currentPage = 1;
    //声明变量，用来存储总页数
    private int _totalPages;
    
    //获取按F对话的对话框
    public GameObject dialogBoxF;
    // Start is called before the first frame update
    void Start()
    {
        //游戏一开始，不显示对话框
        dialogBox.SetActive(false);
        //也不显示按F对话的对话框
        dialogBoxF.SetActive(false);

        //获取对话框TMP组件
        _tmTxBox = dlgTxtProGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取对话框组件中，对话文字的总页数（start中获取不到)
        _totalPages = _tmTxBox.textInfo.pageCount;
        //如果对话框在显示，则可以按空格翻页
        if (dialogBox.activeSelf)
        {
            //翻页功能写入倒计时逻辑中
            //监测用户输入，每次space键弹起激活
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //如果没到最后一页，向后翻页
                if (_currentPage < _totalPages)
                {
                    _currentPage++;
                }
                //否则回到第一页
                else
                {
                    _currentPage = 1;
                }

                _tmTxBox.pageToDisplay = _currentPage;
            }
        }
    }
    
    // npc说话方法
    public void DisplayDialog()
    {
        //显示对话框
        dialogBox.SetActive(true);
    }
    // npc说话隐藏
    public void ClosePlayDialog()
    {
        _currentPage = 1;
        dialogBox.SetActive(false);
    }
    //显示F对话框
    public void ShowFPress()
    {
        dialogBoxF.SetActive(true);
    }
    //关闭F对话框
    public void CloseFPress()
    {
        dialogBoxF.SetActive(false);
    }
}