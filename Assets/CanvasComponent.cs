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

    //comb
    public Text CombCat;
    public Text CombBox;
    public Text CombAcc;
    
    string[] Cat_Names = {"하양이", "치즈태비", "고등어", "노랑얼룩", "젖소", "삼색이", "카오스", "턱시도", "까망이"};
    string[] Box_Names = {"종이상자", "귤상자", "생선상자", "라면상자", "바구니", "CAT상자"};
    string[] Acc_Names = {"없음", "리본", "실뭉치", "나뭇잎", "생선", "귤"};

    string[] CombText = {"하양이", "종이상자", "없음"};
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
        CombCat.text = Cat_Names[id]; //나중에 뺴야함

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
        CombBox.text = Box_Names[id]; //나중에 뺴야함
        
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
        CombAcc.text = Acc_Names[id]; //나중에 뺴야함

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
        CompField.text = CombText[0] + '/' + CombText[1] + '/' + CombText[2];
    }
    public void OpenLink(string url)
    {
        PlayBtnClickSound(RandomButtonClickSound);
        Application.OpenURL(url);
    }
    public void CopyComp()
    {
        GUIUtility.systemCopyBuffer = CompField.text;
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
