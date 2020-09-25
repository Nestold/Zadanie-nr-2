using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals instance;

    public Game game;
    public System.Random random;
    private void Awake()
    {
        if (instance == null)
        {
            random = new System.Random();
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        if(game == null)
        {
            game = new Game();
            game.Load();
        }
    }
    public void CreateCurtain(CurtainType curtainType, string sceneName = "")
    {
        switch(curtainType)
        {
            case CurtainType.cin:
                var curt = Instantiate(Resources.Load<CurtainManager>("Prefabs/Curtain"), GameObject.Find("Canvas").transform, false);
                curt.In();
                break;

            case CurtainType.cout:
                curt = Instantiate(Resources.Load<CurtainManager>("Prefabs/Curtain"), GameObject.Find("Canvas").transform, false);
                curt.Out(sceneName);
                break;
        }
    }
   
    public void PrintMessage(string[] messages, string from = "Me:")
    {
        var pom = Instantiate(Resources.Load<DialogManager>("Prefabs/DialogPanel"), GameObject.Find("Canvas").transform, false);
        pom.Init(messages, from);
    }
}

public class Game
{
    public float music, vfx;
    public List<Item> items;
    public int selectedEqSlot;

    private void NewGame()
    {
        music = 0.5f;
        vfx = 0.5f;
        items = new List<Item>();
    }
    public void Load()
    {
        //ToDo Zrobić ładowanie z pliku
        NewGame();
    }
    public void Save()
    {
        //ToDo Zrobić zapis do pliku
    }
}

public enum CurtainType
{
    cin,
    cout
}
