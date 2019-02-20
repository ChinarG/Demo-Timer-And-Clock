// ========================================================
// 描述：钟表、手表效果
// 作者：Chinar 
// 创建时间：2019-02-16 19:49:39
// 版 本：1.0
// ========================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;


/// <summary>
/// 钟表控制脚本
/// </summary>
public class ChinarHorologe : MonoBehaviour
{
    public        Transform Hour, Minute, Second; //时、分、秒
    public        bool      IsTimeOfDay;          //是否开启精准刷新钟表
    private       DateTime  currentTime;          //当前时间
    private const int       hourDegrees   = 30;   //时针每次转30度
    private const int       minuteDegrees = 6;    //时针每次转6度


    void Start()
    {
        Hour   = GameObject.Find("钟表/时针").transform;
        Minute = GameObject.Find("钟表/分针").transform;
        Second = GameObject.Find("钟表/秒针").transform;
        UpdateClock(); //首次刷新
        sw.Start();    //开始计时
        Second2     = GameObject.Find("秒表/秒针").transform;
        totalSecond = GameObject.Find("秒表/Canvas-TotalSecond/TotalSecond Text").GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        SecondChronograph();
        if (!IsTimeOfDay)
        {
            UpdateClock(); //实时
        }
        else
        {
            PreciseUpdateClock(); //精准
        }
    }


    /// <summary>
    /// 1——刷新钟表
    /// </summary>
    private void UpdateClock()
    {
        currentTime     = DateTime.Now;
        Hour.rotation   = Quaternion.Euler(0, currentTime.Hour   * hourDegrees,   0);
        Minute.rotation = Quaternion.Euler(0, currentTime.Minute * minuteDegrees, 0);
        Second.rotation = Quaternion.Euler(0, currentTime.Second * minuteDegrees, 0);
    }


    /// <summary>
    /// 2——刷新钟表，非常精确的过渡动画
    /// </summary>
    private void PreciseUpdateClock()
    {
        TimeSpan span = DateTime.Now.TimeOfDay;
        Hour.rotation   = Quaternion.Euler(0, (float) (span.TotalHours   * hourDegrees),   0);
        Minute.rotation = Quaternion.Euler(0, (float) (span.TotalMinutes * minuteDegrees), 0);
        Second.rotation = Quaternion.Euler(0, (float) (span.TotalSeconds * minuteDegrees), 0);
    }


    public  Transform       Second2;              //秒表的秒针
    private TextMeshProUGUI totalSecond;          //秒表的总秒数
    private Stopwatch       sw = new Stopwatch(); //实例化计时器类


    /// <summary>
    /// 3——秒表
    /// </summary>
    private void SecondChronograph()
    {
        var elapsedMilliseconds = (float) (sw.ElapsedMilliseconds - sw.Elapsed.Seconds * 1000) / 1000; //毫秒 :0-1000
        Second2.rotation = Quaternion.Euler(0, elapsedMilliseconds * 360, 0);
        totalSecond.text = sw.Elapsed.Seconds.ToString();
    }
}