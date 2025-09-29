using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gameview Gameview;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = Gameview .gameObject.AddComponent<GameController>();
        gameController.gameview = Gameview;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
