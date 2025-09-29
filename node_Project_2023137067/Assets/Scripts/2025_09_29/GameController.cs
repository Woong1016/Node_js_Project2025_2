using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Gameview gameview;
    public PlayerModel playerModel;
    private GameApi gameApi;
    // Start is called before the first frame update
    void Start()
    {
        gameApi = gameObject.AddComponent<GameApi>();
        gameview.SetRegisterButtonListener(OnRegisterButtonClicked);
        gameview.SetLoginButtonListener(OnLoginButtonClicked);
    }
    public void OnRegisterButtonClicked()
    {
        string playerName = gameview.platerNameInput.text;
        StartCoroutine(gameApi.RegitsterPlayer(playerName, "1234"));
    }
    public void OnLoginButtonClicked()
    {
        string playerName = gameview.platerNameInput.text;

    }
    private IEnumerator LoginPlayerCoroutine(string playername , string password)
    {
        yield return gameApi.LoginPlayer(playername, password, player =>
            {
                playerModel = player;
                UpdateResourcesDisplay();
            });
    }
    private void UpdateResourcesDisplay()
    {
        if(playerModel !=null)
        {
            gameview.UpdateResources(playerModel.metal, playerModel.crystal, playerModel.deuturium);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
