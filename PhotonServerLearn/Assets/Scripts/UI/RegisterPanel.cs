using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
public class RegisterPanel : MonoBehaviour
{
    public GameObject loginObj;
    private Button but_Register;
    private Button but_Back;
    private Text txt_Tip;
    private InputField usernameIF;
    private InputField passwordIF;

    private RegisterRequest registerRequest;
    // Use this for initialization
    void Start()
    {
        but_Register = transform.Find("but_Register/").GetComponent<Button>();
        but_Back = transform.Find("but_Back/").GetComponent<Button>();
        txt_Tip = transform.Find("txt_Tip/").GetComponent<Text>();
        usernameIF = transform.Find("UsernameInputField/").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordInputField/").GetComponent<InputField>();
        registerRequest = GetComponent<RegisterRequest>();
        but_Back.onClick.AddListener(OnBackButton);
        but_Register.onClick.AddListener(OnRegisterButton);
    }

    void OnBackButton()
    {
        this.gameObject.SetActive(false);
        loginObj.SetActive(true);
    }
    void OnRegisterButton()
    {
        txt_Tip.text = "";
        registerRequest.username = usernameIF.text;
        registerRequest.password = passwordIF.text;
        registerRequest.DefaultRequest();
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if (returnCode==ReturnCode.Success)
        {
            txt_Tip.text = "注册成功，请返回登录";
        }
        else
        {
            txt_Tip.text = "用户名重复";
        }
    }
}