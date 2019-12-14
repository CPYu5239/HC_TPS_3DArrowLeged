using System.Collections;
using UnityEngine;

public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        //啟動協程(協程名稱)
        StartCoroutine(DelayEffect());
    }

    //宣告協程
    //回傳類型 IEnumerator 傳回等待時間
    public IEnumerator DelayEffect()
    {
        print("開始協程");

        yield return new WaitForSeconds(3); //傳回 新 等待秒數(秒)

        print("3秒後");

        yield return new WaitForSeconds(3); //傳回 新 等待秒數(秒)

        print("3秒後");

        yield return new WaitForSeconds(3); //傳回 新 等待秒數(秒)

        print("3秒後");
    }
}
