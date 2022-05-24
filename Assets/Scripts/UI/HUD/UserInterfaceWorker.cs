using Assets.Scripts.DamagedObject;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceWorker : MonoBehaviour
{
    public Text text;
    public GameObject Table;
    public Text DeadTimeTextBox;

    void Start()
    {
        //StartCoroutine(LoopWave());
        var DO = FindObjectsOfType<DamagedObject>();
        Resources.BaracEnemyCount = DO.Where(x => x.name.Contains("BaracEnemy"))
                                        .Count();

        Resources.BaracFriendCount = DO.Where(x => x.name.Contains("BaracFriend"))
                                        .Count();
    }

    private void Update()
    {
        UpdateStatus();
    }

    //public IEnumerator LoopWave()
    //{
    //    while (true)
    //    {
    //        if (Resources.BaracEnemyCount == 0)
    //        {
    //            Table.active = true;
    //            text.text = "You Win!" + Environment.NewLine;
    //            text.text += Environment.NewLine;
    //        }

    //        if (Resources.BaracFriendCount == 0)
    //        {
    //            Table.active = true;
    //            text.text = "You Lose!" + Environment.NewLine;
    //            text.text += Environment.NewLine;
    //        }
    //        yield return new WaitForSeconds(1);
    //    }
    //}

    void UpdateStatus()
    {
        if (Resources.DeadTime >= 0 && Resources.DeadTime <= 1000)
            DeadTimeTextBox.text = "До возрождения: " + Resources.DeadTime;
        else
            DeadTimeTextBox.text = string.Empty;

        if (Resources.BaracEnemyCount == 0)
        {
            Table.active = true;
            text.text = "You Win!" + Environment.NewLine;
            text.text += Environment.NewLine;
        }

        if (Resources.BaracFriendCount == 0)
        {
            Table.active = true;
            text.text = "You Lose!" + Environment.NewLine;
            text.text += Environment.NewLine;
        }
    }
}
