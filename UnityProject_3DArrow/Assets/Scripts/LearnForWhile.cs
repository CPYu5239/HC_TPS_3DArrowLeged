using UnityEngine;

public class LearnForWhile : MonoBehaviour
{

    public LearnArray learnArray;
    void Start()
    {
        //while迴圈
        //判斷式內的條件若為true則會繼續執行
        int count = 5;
        while (count > 0)
        {
            print("while 迴圈 : " + count);
            count--;
        }

        //for迴圈
        //(初始值 ; 條件 ; 迭代器)
        for (int i = 0; i < 5; i++)
        {
            print("for 迴圈 : " + i);
        }

        for (int j = 0; j < learnArray.players.Length; j++)
        {
            print(learnArray.players[j].name);
        }
    }
}
