using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_coffre_fort : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canvas;
    private string code;
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (code.Length == 4 && code != "1233" && code != "nice")
        {
            Debug.Log("Mauvais code");
            code = "";   
        }

        if (code=="1233")
        {
            Debug.Log("bon code");
            code="nice";
        }   
    }


    public void OnClickButton1()
    {
        code = code + '1';
        Debug.Log(code);
    }

    public void OnClickButton2()
    {
        code = code + '2';
        Debug.Log(code);
    }

    public void OnClickButton3()
    {
        code = code + '3';
        Debug.Log(code);
    }

    public void OnClikButtonClose()
    {
        canvas.SetActive(false);
    }
}
