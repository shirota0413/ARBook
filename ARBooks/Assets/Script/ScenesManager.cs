using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {
    public string SceneName;
    public void Scene_transition () {
        SceneManager.LoadScene(SceneName);
    }

}
