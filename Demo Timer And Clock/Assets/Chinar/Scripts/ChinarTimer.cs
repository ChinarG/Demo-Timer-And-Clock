using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 第一种计时器
/// 以秒数格式化字符串
/// </summary>
public class ChinarTimer : MonoBehaviour
{
    private float currentTime = 0; //当前时间
    private Text  text01;          //第一种时间显示方式
    private Text  text02;          //第二种时间显示方式


    void Start()
    {
        text02 = GameObject.Find("02-系统时间").GetComponent<Text>();
        sbTime = new StringBuilder(16);
        //totalFloat.ToString(".00").Split('.')[1]
    }


    private StringBuilder sbTime;


    void Update()
    {
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
        int totalOfSeconds = (int) totalFloat;
        int hour           = totalOfSeconds                 / 3600;
        int minutes        = (totalOfSeconds - hour * 3600) / 60;
        int seconds        = totalOfSeconds - hour * 3600 - minutes * 60;
        return string.Format("{0}:{1}:{2}", hour < 10 ? "0" + hour : hour.ToString(), minutes < 10f ? "0" + minutes : minutes.ToString(), seconds < 10 ? "0" + seconds : seconds.ToString());
    }
}