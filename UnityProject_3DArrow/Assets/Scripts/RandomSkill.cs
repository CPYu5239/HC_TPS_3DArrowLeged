using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//利用程式碼添加原件 -> 可用於任何元件類型,並在套用腳本到元件時執行
[RequireComponent(typeof(AudioSource))]   
public class RandomSkill : MonoBehaviour
{
    #region 欄位
    [Header("圖片隨機")]
    public Sprite[] spritesRandom;
    [Header("圖片")]
    public Sprite[] sprites;
    [Header("要修改的技能圖片")]
    public Image imgSkill;
    [Header("間隔時間"), Range(0f,0.5f)]
    public float speed = 0.1f;
    [Header("隨機次數"), Range(1, 10)]
    public int count = 5;
    [Header("技能名稱")]
    public string[] skillNames = { "連射", "添加弓箭", "前後", "左右", "血量增加", "攻擊增加", "攻速增加", "爆擊增加" };
    #endregion

    private int randomIndex;
    private Text skillText;
    private AudioClip soundRandom;
    private AudioClip soundOK;
    private AudioSource aud;
    private Button btn;
    private GameObject objSkill;

    private void Start()
    {
        skillText = transform.GetChild(0).GetComponent<Text>();  //利用transform.GetChild可以抓到子物件
        skillText.text = "";
        randomIndex = Random.Range(0, sprites.Length);
        soundRandom = (AudioClip)Resources.Load("SkillRandom");
        soundOK = (AudioClip)Resources.Load("SkillOK");
        aud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        objSkill = GameObject.Find("隨機技能");

        StartCoroutine(StartRandom());    //啟動協程

        btn.onClick.AddListener(ChooseSkill);
    }

    /// <summary>
    /// 選取技能
    /// </summary>
    private void ChooseSkill()
    {
        print("選取"+ skillNames[randomIndex] + "技能!!");
        objSkill.SetActive(false); //隱藏選單
    }

    /// <summary>
    /// 隨機效果開始
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartRandom()    //建立協程,每speed秒換一張圖片
    {
        btn.interactable = false;
        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < spritesRandom.Length; i++)
            {
                imgSkill.sprite = spritesRandom[i];
                aud.PlayOneShot(soundRandom, 0.05f);
                yield return new WaitForSeconds(speed);
            }
        }

        for (int i = 0; i < 8; i++)
        {
            RandomSkill[] games = { GameObject.Find("技能 1").GetComponent<RandomSkill>(),
            GameObject.Find("技能 2").GetComponent<RandomSkill>(),
            GameObject.Find("技能 3").GetComponent<RandomSkill>() };
            if (games[0].randomIndex != games[1].randomIndex && games[0].randomIndex != games[2].randomIndex && games[1].randomIndex != games[2].randomIndex)
            {
                break;
            }
            else
            {
                randomIndex = Random.Range(0, sprites.Length);
            }
        }

        aud.PlayOneShot(soundOK, 1);
        imgSkill.sprite = sprites[randomIndex];
        skillText.text = skillNames[randomIndex];
        btn.interactable = true;
    }
}
