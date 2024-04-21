using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public Transform mainMenu, levelScelect;

    public void LoadScene(string name){
        SceneManager.LoadScene(name);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void LevelScelect(bool clicked){
        if (clicked == true){
            levelScelect.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }else {
            levelScelect.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }


}
