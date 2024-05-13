using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PortraitCanvas;
    public GameObject StartCanvas;
    public GameObject ShopPopupCanvas;
    public GameObject LandscapeCanvas;
    public Sprite[] AccImages;
    public Sprite[] CatImages;
    public Sprite[] BoxImages;
    public Sprite[] MenuButton_Selected;
    public Sprite[] MenuButton_Deselected;

    public Texture2D basicCursor;
    public Texture2D clickedCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.SetCursor(basicCursor, new Vector2(basicCursor.width / 3, 0), CursorMode.Auto);

        StartCanvas.SetActive(true);
        ShopPopupCanvas.SetActive(false);

        float standartRatio = (float)1920/(float)1080;
        float screenRatio = (float)Screen.height / (float)Screen.width;

        if (screenRatio>standartRatio)
        {
            PortraitCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            StartCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            ShopPopupCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        }
        else
        {
            PortraitCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            StartCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            ShopPopupCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
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
        /* 마우스 커서 변경 코드 주석처리
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickedCursor, new Vector2(clickedCursor.width / 3, 0), CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(basicCursor, new Vector2(basicCursor.width / 3, 0), CursorMode.Auto);
        }
        */
    }

    void ChangeCanvasByDisplayAspect(bool isPortaitDisplay)
    {
        PortraitCanvas.SetActive(isPortaitDisplay);
        LandscapeCanvas.SetActive(!isPortaitDisplay);
    }


}
