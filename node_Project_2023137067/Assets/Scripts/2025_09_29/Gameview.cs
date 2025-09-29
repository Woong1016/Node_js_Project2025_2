using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Gameview : MonoBehaviour
{

    public Text playerNameText;
    public Text metalText;
    public Text crystalText;
    public Text deuteriumText;
    public InputField platerNameInput;

    public Button registerButton;
    public Button loginButton;
    public Button collectButton;
    public Button developButton;
    public Slider progressBar;


    public void SetPlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void UpdateResources(int metal , int crystal , int deuterium)
    {
        metalText.text = $"Metal : {metal}";
        crystalText.text = $"crystal : {crystal}";
        deuteriumText.text = $"Deuterium : {deuterium}";
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }

    public void SetRegisterButtonListener(UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }

    public void SetLoginButtonListener(UnityAction action)
    {
        loginButton.onClick.RemoveAllListeners();
        loginButton.onClick.AddListener(action);
    }

    public void SetcollectButtonButtonListener(UnityAction action)
    {
        collectButton.onClick.RemoveAllListeners();
        collectButton.onClick.AddListener(action);
    }

    public void SetdevelopButtonButtonListener(UnityAction action)
    {
        developButton.onClick.RemoveAllListeners();
        developButton.onClick.AddListener(action);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
