using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    public void DisableObject() {
        gameObject.SetActive(false);
    }
}
