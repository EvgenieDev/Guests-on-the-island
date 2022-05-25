using UnityEngine;
using UnityEngine.SceneManagement;

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
            Time.timeScale = (Time.timeScale + 1) % 2;
            Menu.gameObject.SetActive(!Menu.gameObject.activeSelf);
        }
    }

    public void Disconnect()
    {
        Time.timeScale = (Time.timeScale + 1) % 2;

        SceneManager.UnloadSceneAsync("Game");

        Menu.gameObject.SetActive(!Menu.gameObject.activeSelf);
        SceneManager.LoadScene("Launcher");
        Debug.Log("Exiting");
        Resources.ReCreate();
        //PhotonNetwork.Disconnect();
    }
}
