using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gif : MonoBehaviour
{

    public Sprite[] images;
    public int framesPerSecond;
    public Image thisImage; 
    
    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % images.Length;
        thisImage.sprite = images[index];
    }
}
