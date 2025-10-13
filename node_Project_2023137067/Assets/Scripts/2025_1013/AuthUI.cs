using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public class AuthUI : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;

    public Button registerButton;
    public Button loginButton;

    public Text statusText;
    private AuthManager authManager;
    // Start is called before the first frame update
    void Start()
    {
        
        authManager = GetComponent<AuthManager>();
        registerButton.onClick.AddListener(OnRegisterClick);
        loginButton.onClick.AddListener(OnLoginClick);
    }

    private void OnRegisterClick()

    {
       StartCoroutine(RegisterCoroutine()) ;
    }
    private void OnLoginClick()
    {
        StartCoroutine(LoginCoroutine());
    }

    private IEnumerator LoginCoroutine()
    {
        statusText.text = "로그인 중";
        yield return StartCoroutine(authManager.Login(usernameInput.text, passwordInput.text));
        statusText.text = "로그인 성공";
    }
    private IEnumerator RegisterCoroutine()
    {
        statusText.text = "회원가입중...";
        yield return StartCoroutine(authManager.Register(usernameInput.text, passwordInput.text));
        statusText.text = "회원가입 성공 , 로그인 해주세요";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
