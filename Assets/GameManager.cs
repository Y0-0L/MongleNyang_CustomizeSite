using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PortraitCanvas;
    public GameObject LandscapeCanvas;
    public Sprite[] AccImages;
    public Sprite[] CatImages;
    public Sprite[] BoxImages;
    public Sprite[] MenuButton_Selected;
    public Sprite[] MenuButton_Deselected;
    
    // Start is called before the first frame update
    void Start()
    {
        float standartRatio = (float)1920/(float)1080;
        float screenRatio = (float)Screen.height / (float)Screen.width;
        Debug.Log(standartRatio);
        Debug.Log(screenRatio);
        if (screenRatio>standartRatio)
        {
            PortraitCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        }
        else
        {
            PortraitCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        }
        PortraitCanvas.SetActive(true);

        /*
        float ratio = (float)Screen.height / (float)Screen.width;
        Debug.Log(ratio);
        bool isPortaitDisplay = (ratio > 1.65);
        Debug.Log(isPortaitDisplay);
        ChangeCanvasByDisplayAspect(isPortaitDisplay);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCanvasByDisplayAspect(bool isPortaitDisplay)
    {
        PortraitCanvas.SetActive(isPortaitDisplay);
        LandscapeCanvas.SetActive(!isPortaitDisplay);
    }


}
