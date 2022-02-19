using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{

    GameObject textError;
    // Start is called before the first frame update
    void Start()
    {
        textError = GameObject.Find("textError");
        textError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToFormulaire()
    {
        SceneManager.LoadScene("SendToERPScene");
    }

    public void SwitchToMainApp()
    {
        SceneManager.LoadScene("formScene");
    }

    public async void SendInfosToERP()
    {
        string name = GameObject.Find("inputName").GetComponent<InputField>().text;
        string mail = GameObject.Find("inputMail").GetComponent<InputField>().text;

        if (VerifyMail(mail))
        {
            Api api = new Api();
            var opportunity = new Opportunity(name, mail);
            string token = await api.GetToken();
            string res = await api.InsertOpportunity(token, opportunity);
            this.SwitchToMainApp();
        }
        else
        {
            textError.SetActive(true);
        }
    }

    private bool VerifyMail(string mail)
    {
        Regex rx = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

        return rx.IsMatch(mail);
    }
}
