using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public GameObject Menu;

    private void Start()
    {
        Menu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Show");
            Menu.gameObject.SetActive(!Menu.gameObject.activeSelf);
        }
    }

    public void Disconnect()
    {
        SceneManager.LoadScene("Launcher");
        var t = SceneManager.UnloadSceneAsync("Game");
        while (!t.isDone)
        {

        }
        Menu.gameObject.SetActive(!Menu.gameObject.activeSelf);
        SceneManager.LoadScene("Launcher");
        Debug.Log("Exiting");
        Resources.ReCreate();
        //PhotonNetwork.Disconnect();
    }
}
