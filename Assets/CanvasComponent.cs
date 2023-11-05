using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;

//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComponent : MonoBehaviour
{
    public GameManager gameManager;

    public Image BoxImage;
    public  Image CatImage;
    public  Image AccImage;
    public GameObject[] ContentLayouts = new GameObject[3];
    public int[] SelectedContentId = {0,0,0};

    // Start is called before the first frame update
    void Start()
    {
       SetCategory(0);
        for (int i = 0; i < ContentLayouts.Length; i++)
        {
            ContentLayouts[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void SetCategory(int id)
    {
        //0: cat, 1: box, 2: acc
        for (int i = 0; i < ContentLayouts.Length; i++)
        {
            ContentLayouts[i].SetActive(i == id);
        }
    }
    public void SetContents_Cat(int id)
    {
        CatImage.sprite = gameManager.CatImages[id];
        
        int SelectedContentIndex = SelectedContentId[0];
        ContentLayouts[0].transform.GetChild(SelectedContentIndex).gameObject.SetActive(true);

        ContentLayouts[0].transform.GetChild(id).gameObject.SetActive(false);
        SelectedContentId[0] = id;
    }
    public void SetContents_Box(int id)
    {
        BoxImage.sprite = gameManager.BoxImages[id];

        int SelectedContentIndex = SelectedContentId[1];
        ContentLayouts[1].transform.GetChild(SelectedContentIndex).gameObject.SetActive(true);

        ContentLayouts[1].transform.GetChild(id).gameObject.SetActive(false);
        SelectedContentId[1] = id;
    }
    public void SetContents_Acc(int id)
    {
        AccImage.sprite = gameManager.AccImages[id];

        int SelectedContentIndex = SelectedContentId[2];
        ContentLayouts[2].transform.GetChild(SelectedContentIndex).gameObject.SetActive(true);

        ContentLayouts[2].transform.GetChild(id).gameObject.SetActive(false);
        SelectedContentId[2] = id;
    }
}
