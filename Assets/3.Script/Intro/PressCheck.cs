using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressCheck : MonoBehaviour
{
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();


    }
    private void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.tapCount >= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
