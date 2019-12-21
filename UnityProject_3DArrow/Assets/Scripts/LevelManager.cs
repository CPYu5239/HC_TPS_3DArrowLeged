using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("是否顯示隨機技能")]
    public bool showRandomSkill;
    [Header("是否直接開門")]
    public bool autoOpenDoor;
    [Header("隨機技能選單")]
    public GameObject randomSkill;

    private Animator door;

    private void Start()
    {
        door = GameObject.Find("門").GetComponent<Animator>();

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
}
