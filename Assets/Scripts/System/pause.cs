using UnityEngine;

public class pause : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = (Time.timeScale+1)%2;
    }
}
