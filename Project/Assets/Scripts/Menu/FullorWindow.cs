using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FullorWindow : MonoBehaviour
{
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;

        toggle.isOn = false;
    }

    public void ScreenMode()
    {
        Screen.fullScreen = !toggle.isOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
