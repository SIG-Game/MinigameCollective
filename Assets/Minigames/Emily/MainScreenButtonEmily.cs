using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenButtonEmily : MonoBehaviour
{
    public string SceneName;

    public void MouseClick() {
        SceneManager.LoadScene(SceneName);
    }
}
