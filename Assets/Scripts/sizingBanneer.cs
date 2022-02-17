using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizing : MonoBehaviour
{
    int width = 1400;
    int height = 250;
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
