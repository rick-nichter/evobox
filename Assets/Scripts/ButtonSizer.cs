using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSizer : MonoBehaviour
{
    public void onHover()
    {
        transform.localScale = new  Vector3(1.2f, 1.2f, 1.2f);
    }

    public void onHoverExit()
    {
        transform.localScale = new Vector3(1,1,1);
    }
}
