using System.Collections;
using UnityEngine;

public class MiniMapActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject minimap;
    [SerializeField]
    private GameObject fpsMeter;

    void Start()
    {
        StartCoroutine(MiniMapCheck());
    }

    public IEnumerator MiniMapCheck()
    {
        while (true)
        {
            minimap.active = Resources.MiniMapState;
            fpsMeter.active = Resources.FPSState;
            yield return new WaitForSeconds(5);
        }
    }
}
