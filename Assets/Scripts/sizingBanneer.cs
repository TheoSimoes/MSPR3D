using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizingBanneer : MonoBehaviour
{
    int width = 1080;
    int height = 300;
    public RectTransform myBanneer;
    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        myBanneer.sizeDelta = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
