using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class HUDBars : MonoBehaviour
{
    [SerializeField]
    public Text gold;

    [SerializeField]
    private Text playerHealthText;

    [SerializeField]
    private Slider playerHealthSlider;

    [SerializeField]
    private Text playerExperienceText;

    [SerializeField]
    private Slider playerExperienceSlider;

    [SerializeField]
    private float playerExperiencePerLevel = 100;

    [SerializeField]
    private Text playerAttackText;
    [SerializeField]
    private Text playerSpeedText;
    [SerializeField]
    private Text playerArmorText;

    private PlayerDamagedObject targetPDO;
    private MainCharacterUnit targetMCU;
    private NavMeshAgent targetNMA;

    void Start()
    {
        //StartCoroutine(LoopWave());
    }

    private void Update()
    {
        if (targetPDO == null)
        {
            var mcu = FindObjectOfType<MainCharacterUnit>();
            if (mcu != null)
            {
                targetPDO = mcu.GetComponent<PlayerDamagedObject>();
                targetMCU = mcu.GetComponent<MainCharacterUnit>();
                targetNMA = mcu.GetComponent<NavMeshAgent>();
            }
        }
        else
            UpdateGui();
    }

    //public IEnumerator LoopWave()
    //{
    //    while (true)
    //    {
    //        if (target == null)
    //        {
    //            var mcu = FindObjectOfType<MainCharacterUnit>();
    //            if (mcu != null)
    //            {
    //                target = mcu.GetComponent<PlayerDamagedObject>();
    //            }
    //        }
    //        else
    //            UpdateGui();
    //        yield return new WaitForSeconds(1);
    //    }
    //}

    void UpdateGui()
    {
        if (playerHealthSlider != null)
        {
            var health = targetPDO.Health < 0 ? 0 : targetPDO.Health;
            playerHealthSlider.value = health / targetPDO.MaxHealth;
            playerHealthText.text = $"{(int)health} / {targetPDO.MaxHealth}";
        }

        if (playerExperienceSlider != null)
        {
            playerExperienceSlider.value = Resources.MainHeroExperience / playerExperiencePerLevel;
            playerExperienceText.text = ((int)(Resources.MainHeroExperience / playerExperiencePerLevel)).ToString();
        }

        playerAttackText.text = ((int)targetMCU.Damage).ToString();
        playerSpeedText.text = ((int)targetNMA.speed).ToString();
        playerArmorText.text = ((int)targetPDO.Armor).ToString();

        gold.text = ((int)Resources.MainHeroGold).ToString();
    }
}
