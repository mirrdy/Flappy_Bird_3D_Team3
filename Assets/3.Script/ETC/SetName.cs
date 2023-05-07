using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{
    public InputField inputName;
    public Button inputbutton;

    public void SetInputName()
    {
        UIManager.instance.SetName(inputName.text);
        inputName.gameObject.SetActive(false);
    }
}
