
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class KeyBindManager : MonoBehaviour 
{
    private static readonly string DefaultKey = "DefaultKey";
    private int defaultKey;

    private static readonly string ButtonText = "ButtonText";
    private string buttonText;

    private readonly static string AttackKey = "AttackKey";
    public KeyCode attackKey;

    Button button;
    public Button buttonObject;

    private bool isClick = true;

    private void Awake()
    {
        button = GetComponent<Button>();
        defaultKey = PlayerPrefs.GetInt(DefaultKey);

        if (defaultKey == 0)
        {
            attackKey = KeyCode.Mouse0;
            buttonText = "LEFT MOUSE";

            PlayerPrefs.SetInt(AttackKey, (int)attackKey);
            PlayerPrefs.SetString(ButtonText,buttonText);

            PlayerPrefs.SetInt(DefaultKey, -1);
        }
        else
        {
            GetAttackKey();
            GetButtonText();
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
            buttonObject.transform.GetComponentInChildren<TMP_Text>().text = buttonText;

    }

    private void OnGUI()
    {

        if(button != null)
        {
            Event e = Event.current;


            if(e.isMouse || e.isKey )
            {
                if (e.isMouse)
                {
                    //string text = "";
                    if (Input.GetMouseButtonDown(0))
                    {
                        //text = "LEFT MOUSE";
                        attackKey = KeyCode.Mouse0;
                        isClick = false;
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        //text = "RIGHT MOUSE";
                        attackKey = KeyCode.Mouse1;
                    }

                    ///button.transform.GetComponentInChildren<TMP_Text>().text = text;
                }

                else if (e.isKey)
                {
                    attackKey = e.keyCode;
                    //button.transform.GetComponentInChildren<TMP_Text>().text = attackKey.ToString();
                }



                SaveKeyBind();
                SaveButtonText();

                button = null;
                buttonObject.transform.GetComponentInChildren<TMP_Text>().text = buttonText;
            }

        }

    }

    public void ChangeKey(Button btn)
    {
        button = btn;
        //if (isClick)
        //{
            button.transform.GetComponentInChildren<TMP_Text>().text = "";
        //}

    }

    public void GetAttackKey()
    {
        attackKey = (KeyCode)PlayerPrefs.GetInt(AttackKey);   
    }

    public void SaveKeyBind()
    {
        PlayerPrefs.SetInt(AttackKey, (int)attackKey);
        PlayerPrefs.Save();
    }

    void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveKeyBind();
            SaveButtonText();
    }

    public void SaveButtonText()
    {
        switch (attackKey)
        {
            case KeyCode.Mouse0:
                buttonText = "LEFT MOUSE";
                break;
            case KeyCode.Mouse1:
                buttonText = "RIGHT MOUSE";
                break;
            default:
                buttonText = attackKey.ToString().ToUpper();
                break;
        }

        PlayerPrefs.SetString(ButtonText, buttonText);
        PlayerPrefs.Save();
    }

    public void GetButtonText()
    {
        buttonText = PlayerPrefs.GetString(ButtonText);
    }
}
