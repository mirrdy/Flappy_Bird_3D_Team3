using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{
    public InputField inputfield;
    public Text inputName;
    [SerializeField] private Button Restart;

    public void SetInputName()
    {
        UIManager.instance.SetName(inputName.text);
        inputfield.gameObject.SetActive(false);
    }
}
