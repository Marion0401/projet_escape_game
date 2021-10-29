using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button_coffre_fort : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canvas;
    public GameObject boncode;
    public GameObject mauvaiscode;
    public TextMeshProUGUI Code;
    private string code;
    void Start()
    {
        canvas.SetActive(false);
        boncode.SetActive(false);
        mauvaiscode.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (code.Length == 4 && code != "1233" && code != "nice")
        {
            Debug.Log("Mauvais code");
            code = "";
            StartCoroutine(MauvaisCodeEntrer());
        }

        if (code=="1233")
        {
            Debug.Log("bon code");
            code="nice";
            StartCoroutine(BonCodeEntrer());
        }

        Code.text = code;
    }

    IEnumerator BonCodeEntrer()
    {
        boncode.SetActive(true);
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }

    IEnumerator MauvaisCodeEntrer()
    {
        mauvaiscode.SetActive(true);
        yield return new WaitForSeconds(2);
        mauvaiscode.SetActive(false);
    }

    public void OnClickButton1()
    {
        if (code != "nice")
        {
            code = code + '1';
            Debug.Log(code);
        }
    }

    public void OnClickButton2()
    {
        if (code != "nice")
        {
            code = code + '2';
            Debug.Log(code);
        }
    }

    public void OnClickButton3()
    {
        if (code != "nice")
        {
            code = code + '3';
            Debug.Log(code);
        }
    }

    public void OnClikButtonClose()
    {
        canvas.SetActive(false);
    }
}
