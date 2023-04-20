using CodeMonkey.Utils;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    private enum Sub
    {
        Main,
        HowToPlay,
    }
    private void Awake()
    {
        transform.Find("HowToPlayArea").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("MainMenu").Find("PlayBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); };
        transform.Find("MainMenu").Find("QuitBtn").GetComponent<Button_UI>().ClickFunc = () => { Application.Quit(); };
        transform.Find("MainMenu").Find("HowToPlayBtn").GetComponent<Button_UI>().ClickFunc = () => { ShowSub(Sub.HowToPlay); };
        transform.Find("HowToPlayArea").Find("ExitBtn").GetComponent<Button_UI>().ClickFunc = () => { ShowSub(Sub.Main); };

        ShowSub(Sub.Main);
    }

    private void ShowSub(Sub sub)
    {
        transform.Find("MainMenu").gameObject.SetActive(false);
        transform.Find("HowToPlayArea").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
                transform.Find("MainMenu").gameObject.SetActive(true); break;
            case Sub.HowToPlay:
                transform.Find("HowToPlayArea").gameObject.SetActive(true); break;
        }
    }
}
