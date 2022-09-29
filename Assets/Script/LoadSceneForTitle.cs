using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneForTitle : MonoBehaviour
{
    [SerializeField]
    SceneLoader _sceneLoader;

    const string FIRE_1 = "Fire1";

    void Update()
    {
        if(Input.GetButtonDown(FIRE_1))
        {
            _sceneLoader.LoadScene(SceneType.HomeScene);
        }
    }
}
