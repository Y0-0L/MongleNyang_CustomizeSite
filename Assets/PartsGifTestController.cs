using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsGifTestController : MonoBehaviour
{
    public CanvasComponent canvasComponent;
    public Animator animator;
    public void RandomizeAndSetTrigger()
    {
        canvasComponent.RandomBtnClick();
        animator.SetTrigger("Jump");
    }
}
