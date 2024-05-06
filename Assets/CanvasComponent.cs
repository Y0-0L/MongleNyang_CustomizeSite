using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComponent : MonoBehaviour
{
    public GameManager gameManager;

    public Image BoxImage;
    public  Image CatImage;
    public  Image AccImage;
    public GameObject[] ContentLayouts = new GameObject[3];
    public Image[] MenuButtons = new Image[3];
    public int[] SelectedContentId = {0,0,0};
    Color EnableColor = new Color(1,1,1,1);
    Color DisableColor = new Color(1,1,1,0);
    AudioSource audioSource;
    public AudioClip BasicButtonClickSound;
    public AudioClip RandomButtonClickSound;


    
    string[] Cat_Names = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
    string[] Box_Names = {"1", "2", "3", "4", "5", "6"};
    string[] Acc_Names = {"1", "2", "3", "4", "5", "6"};

    string[] CombText = {"1", "1", "1"};
    public Text CompField;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetCategory(0);
        SetContents_Cat(0);
        SetContents_Box(0);
        SetContents_Acc(0);
        
        /*
        for (int i = 0; i < ContentLayouts.Length; i++)
        {
            ContentLayouts[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = EnableColor;
        }
        */
    }
    public void SetCategory(int enablingCategoryId)
    {
        //PlayBtnClickSound(BasicButtonClickSound);

        //0: cat, 1: box, 2: acc
        for (int i = 0; i < ContentLayouts.Length; i++)
        {
            ContentLayouts[i].SetActive(i == enablingCategoryId);

            Sprite sprite;
            if (i == enablingCategoryId)
            {
                sprite = gameManager.MenuButton_Selected[i];
            }
            else
            {
                sprite = gameManager.MenuButton_Deselected[i];
            }
            MenuButtons[i].sprite = sprite;
        }
    }
    public void SetContents_Cat(int id)
    {
        //PlayBtnClickSound(BasicButtonClickSound);
        
        CombText[0] = Cat_Names[id];
        RefreshCombText();


        CatImage.sprite = gameManager.CatImages[id];
        
        int SelectedContentIndex = SelectedContentId[0];
        ContentLayouts[0].transform.GetChild(SelectedContentIndex).gameObject.GetComponent<Image>().color = DisableColor;

        ContentLayouts[0].transform.GetChild(id).gameObject.GetComponent<Image>().color = EnableColor;
        SelectedContentId[0] = id;
    }
    public void SetContents_Box(int id)
    {
        //PlayBtnClickSound(BasicButtonClickSound);
        CombText[1] = Box_Names[id];
        RefreshCombText();

        
        BoxImage.sprite = gameManager.BoxImages[id];

        int SelectedContentIndex = SelectedContentId[1];
        ContentLayouts[1].transform.GetChild(SelectedContentIndex).gameObject.GetComponent<Image>().color = DisableColor;

        ContentLayouts[1].transform.GetChild(id).gameObject.GetComponent<Image>().color = EnableColor;
        SelectedContentId[1] = id;
    }
    public void SetContents_Acc(int id)
    {
        //PlayBtnClickSound(BasicButtonClickSound);
        CombText[2] = Acc_Names[id];
        RefreshCombText();


        AccImage.sprite = gameManager.AccImages[id];

        int SelectedContentIndex = SelectedContentId[2];
        ContentLayouts[2].transform.GetChild(SelectedContentIndex).gameObject.GetComponent<Image>().color = DisableColor;

        ContentLayouts[2].transform.GetChild(id).gameObject.GetComponent<Image>().color = EnableColor;
        SelectedContentId[2] = id;
    }
    public void RandomBtnClick()
    {
        PlayBtnClickSound(RandomButtonClickSound);

        int catRandId = Random.Range(0, gameManager.CatImages.Length);
        int boxRandId = Random.Range(0, gameManager.BoxImages.Length);
        int accRandId = Random.Range(0, gameManager.AccImages.Length);

        SetContents_Cat(catRandId);
        SetContents_Box(boxRandId);
        SetContents_Acc(accRandId);
    }
    public void RefreshCombText()
    {
        CompField.text = CombText[0] + CombText[1] + CombText[2];
    }
    public void OpenLink(string url)
    {
        PlayBtnClickSound(RandomButtonClickSound);
        Application.OpenURL(url);
    }

    public void PlayBtnClickSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayBtnClickSound_Basic()
    {
        PlayBtnClickSound(BasicButtonClickSound);
    }
    public void PlayBtnClickSound_Random()
    {
        PlayBtnClickSound(RandomButtonClickSound);
    }
    public void PlayObjetsAnim(Animation animationComp)
    {
        animationComp.Play();
    }
}
