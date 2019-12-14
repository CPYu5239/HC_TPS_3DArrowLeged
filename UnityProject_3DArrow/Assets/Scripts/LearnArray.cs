using UnityEngine;

public class LearnArray : MonoBehaviour
{
    //任何類型都能宣告成陣列 -> Public可以從Unity裡面直接設定陣列大小和值
    public int[] enemys;
    public float[] speeds;
    public GameObject[] enemyObjs;

    //宣告陣列
    public int[] array1;
    //宣告固定數量的陣列
    public int[] array2 = new int[10];
    //宣告列並給值
    public int[] array3 = { 100, 200, 300 };

    public GameObject[] players;

    private void Start()
    {
        //抓取陣列值
        for (int i = 0; i < array3.Length; i++)  //利用Length取得陣列長度
        {
            print("取得陣列內部資料 : 第" + (i + 1) + "筆資料 : " + array3[i]);
        }
        //透過標籤尋找物件 -> 會傳回GameObject陣列
        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    //喚醒時呼叫 : 在Strat前執行一次
    private void Awake()
    {
        //透過標籤尋找物件 -> 會傳回GameObject陣列
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
