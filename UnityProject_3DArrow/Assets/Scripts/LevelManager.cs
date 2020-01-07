using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("是否顯示隨機技能")]
    public bool showRandomSkill;
    [Header("是否直接開門")]
    public bool autoOpenDoor;
    [Header("隨機技能選單")]
    public GameObject randomSkill;

    private Animator door;
    private Image cross;   //轉場畫面

    private void Start()
    {
        door = GameObject.Find("門").GetComponent<Animator>();
        cross = GameObject.Find("轉場畫面").GetComponent<Image>();

        if (autoOpenDoor) Invoke("OpenDoor", 8);    //Invoke -> 延遲調用方法
        if (showRandomSkill) ShowRandomSkill();
    }

    /// <summary>
    /// 顯示隨機技能畫面
    /// </summary>
    private void ShowRandomSkill()
    {
        randomSkill.SetActive(true);
    }

    /// <summary>
    /// 播放開門動畫
    /// </summary>
    private void OpenDoor()
    {
        door.SetTrigger("開門");
    }

    /// <summary>
    /// 載入關卡
    /// </summary>
    private IEnumerator LoadLevel()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("關卡2");
        ao.allowSceneActivation = false;    //是否允許切換場景

        while (!ao.isDone)
        {
            print(ao.progress);
            cross.color = new Color(1, 1, 1, ao.progress);   //利用進度條0~0.9的性質來調整透明度
            yield return new WaitForSeconds(0.01f);

            if (ao.progress >= 0.9f)
            {
                cross.color = new Color(1, 1, 1, 1);
                ao.allowSceneActivation = true;
            }
        }
    }
}
