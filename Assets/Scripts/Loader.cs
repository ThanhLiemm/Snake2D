using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class Loader
{
    private static Action loaderCallbackAction;
    public enum Scene
    {
        GameScene,
        Loading,
    }

    public static void Load(Scene scene)
    {
        //set up the callback action that will be triggered after the Loading scene is loaded
        loaderCallbackAction = () =>
        {
            //load target scene when the loading scene is loaded
            SceneManager.LoadScene(scene.ToString());
        };

        // load loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());

    }

    public static void LoaderCallback()
    {
        if (Loader.loaderCallbackAction != null)
        {
            loaderCallbackAction();
            loaderCallbackAction = null;
        }
    }
}
