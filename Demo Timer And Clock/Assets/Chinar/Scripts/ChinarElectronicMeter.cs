// ========================================================
// 描述：电子表示例
// 作者：Chinar 
// 创建时间：2019-02-18 23:13:26
// 版 本：1.0
// ========================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class ChinarElectronicMeter : MonoBehaviour
{
    private float currentTime = 0; //当前时间
    private Text  text01;          //第一种时间显示方式
    private Text  text02;          //第二种时间显示方式


    void Start()
    {
        text01 = GameObject.Find("01-自定义时间").GetComponent<Text>();
        text02 = GameObject.Find("02-系统时间").GetComponent<Text>();
        sbTime = new StringBuilder(16);
        //totalFloat.ToString(".00").Split('.')[1]
    }


    private StringBuilder sbTime;


    void Update()
    {
        /*
         * 1：自定义时间显示
         */
        text01.text = TimeFormatting(currentTime += Time.deltaTime);
        /*
         * 2:系统时间显示
         */
        sbTime.Clear();
        text02.text = sbTime.AppendFormat("系统时间：{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToString();

    }


    /// <summary>
    /// 时间格式化：传入秒数，字符串格式化为电子表格式
    /// </summary>
    /// <param name="totalFloat">总秒数</param>
    public string TimeFormatting(float totalFloat)
    {
        int totalOfSeconds = (int)totalFloat;
        int hour           = totalOfSeconds                 / 3600;
        int minutes        = (totalOfSeconds - hour * 3600) / 60;
        int seconds        = totalOfSeconds - hour * 3600 - minutes * 60;
        return string.Format("{0}:{1}:{2}", hour < 10 ? "0" + hour : hour.ToString(), minutes < 10f ? "0" + minutes : minutes.ToString(), seconds < 10 ? "0" + seconds : seconds.ToString());
    }
}
