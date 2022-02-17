using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizingFormulaire : MonoBehaviour
{
    int width = 1400;
    int height = 250;
    public RectTransform myFormulaire;
    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width - ((Screen.width * 20) /100);
        height = Screen.height - ((Screen.height * 35) / 100);
        myFormulaire.sizeDelta = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
