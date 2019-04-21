using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {

    }
    #endregion

    #region Public Methods
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }
    #endregion

    #region Private Methods
    #endregion
}
