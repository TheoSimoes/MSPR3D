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
    public RectTransform transformContainer;

    // Start is called before the first frame update
    void Start()
    {
        transformTextName = GameObject.Find("textName").GetComponent<RectTransform>();
        transformInputName = GameObject.Find("inputName").GetComponent<RectTransform>();
        transformTextMail = GameObject.Find("textMail").GetComponent<RectTransform>();
        transformInputMail = GameObject.Find("inputMail").GetComponent<RectTransform>();
        transformBtnSend = GameObject.Find("btnSend").GetComponent<RectTransform>();
        transformTextTitle = GameObject.Find("textTitle").GetComponent<RectTransform>();
        transformContainer = GameObject.Find("Container").GetComponent<RectTransform>();
        ResizingContainer();
        ResizingFormulaire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResizingFormulaire()
    {
        ResizingBtnSend();
        ResizingInputMail();
        ResizingInputName();
        ResizingTextMail();
        ResizingTextName();
        ResizingTitle();
    }

    private void ResizingTitle()
    {
        transformTextTitle.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 70, (transformContainer.sizeDelta.y / 100) * 30);
        transformTextTitle.localPosition = new Vector2(0, transformContainer.sizeDelta.y / 2);
        Debug.Log(transformContainer.sizeDelta.y / 2);
    }

    private void ResizingTextName()
    {
        transformTextName.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 70, (transformContainer.sizeDelta.y / 100) * 10);
        transformTextName.localPosition = new Vector2(0,transformTextTitle.localPosition.y - transformTextTitle.sizeDelta.y);
    }

    private void ResizingInputName()
    {
        transformInputName.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 70, (transformContainer.sizeDelta.y / 100) * 20);
        transformInputName.localPosition = new Vector2(0, transformTextName.localPosition.y - transformTextName.sizeDelta.y);
    }

    private void ResizingTextMail()
    {
        transformTextMail.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 70, (transformContainer.sizeDelta.y / 100) * 10);
        transformTextMail.localPosition = new Vector2(0, transformInputName.localPosition.y - transformInputName.sizeDelta.y);
    }

    private void ResizingInputMail()
    {
        transformInputMail.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 70, (transformContainer.sizeDelta.y / 100) * 20);
        transformInputMail.localPosition = new Vector2(0, transformTextMail.localPosition.y - transformTextMail.sizeDelta.y);
    }

    private void ResizingBtnSend()
    {
        transformBtnSend.sizeDelta = new Vector2((transformContainer.sizeDelta.x / 100) * 20, (transformContainer.sizeDelta.x / 100) * 20);
        transformBtnSend.localPosition = new Vector2(0, transformInputMail.localPosition.y - transformInputMail.sizeDelta.y);
    }

    private void ResizingContainer()
    {
        transformContainer.sizeDelta = new Vector2((Screen.width * 80) /100, (Screen.height * 70) /100);
        transformContainer.localPosition = new Vector2(0, 0);
    }
}
