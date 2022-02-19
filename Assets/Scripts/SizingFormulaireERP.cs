using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizingFormulaireERP : MonoBehaviour
{
    public RectTransform transformTextName;
    public RectTransform transformInputName;
    public RectTransform transformTextMail;
    public RectTransform transformInputMail;
    public RectTransform transformBtnSend;
    public RectTransform transformTextTitle;

    // Start is called before the first frame update
    void Start()
    {
        transformTextName = GameObject.Find("textName").GetComponent<RectTransform>();
        transformInputName = GameObject.Find("inputName").GetComponent<RectTransform>();
        transformTextMail = GameObject.Find("textMail").GetComponent<RectTransform>();
        transformInputMail = GameObject.Find("inputMail").GetComponent<RectTransform>();
        transformBtnSend = GameObject.Find("btnSend").GetComponent<RectTransform>();
        transformTextTitle = GameObject.Find("textTitle").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResizingTextName()
    {

    }

    public void ResizingInputName()
    {

    }

    public void ResizingTextMail()
    {

    }

    public void ResizingInputMail()
    {

    }

    public void ResizingBtnSend()
    {

    }
}
