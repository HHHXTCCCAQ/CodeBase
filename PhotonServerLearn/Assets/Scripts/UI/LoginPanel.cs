using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
public class LoginPanel : MonoBehaviour
{
    public GameObject registerObj;
    private Button but_Login;
    private Button but_Register;
    private Text txt_Tip;
    private InputField usernameIF;
    private InputField passwordIF;
    private LoginRequest loginRequest;
    // Use this for initialization
    void Start()
    {
        loginRequest = GetComponent<LoginRequest>(); 
        but_Login = transform.Find("but_Login/").GetComponent<Button>();
        but_Register = transform.Find("but_Register/").GetComponent<Button>();
        txt_Tip = transform.Find("txt_Tip/").GetComponent<Text>();
        usernameIF= transform.Find("UsernameInputField/").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordInputField/").GetComponent<InputField>();


        txt_Tip.text = "";
        but_Login.onClick.AddListener(OnLoginButton);
        but_Register.onClick.AddListener(OnRegisterButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnLoginButton()
    {
        loginRequest.Username = usernameIF.text;
        loginRequest.Password = passwordIF.text;
        loginRequest.DefaultRequest();
    }
    void OnRegisterButton()
    {
        this.gameObject.SetActive(false);
        registerObj.SetActive(true);
    }

    public void OnLogainResponse(ReturnCode returnCode)
    {
        if (returnCode==ReturnCode.Success)
        {
            //txt_Tip.text = "";
            SceneManager.LoadScene(1);
        }
        else
        {
            txt_Tip.text = "用户名或密码错误";
        }
    }
}