using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLoad : MonoBehaviour
{
    [SerializeField]
    SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader.LoadScene(SceneType.TitleScene);
    }
}
