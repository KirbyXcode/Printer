//using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using System;
using System.Drawing;

public class PrinterManager : ManagerBase
{
    public static PrinterManager Instance = null;

    public string printerName;
    public int copies = 1;
    private string path;

    void Awake()
    {
        Instance = this;

        Add(0, this);
    }

    private void Start()
    {
        printerName = JsonManager.Instance.GetData().printerName;
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case 0:
                string path = message as string;
                PrintTicket(path);
                break;
        }
    }

    private void PrintTicket(string path)
    {
        if (!File.Exists(path)) return;
        this.path = path;

        PrintDocument pri = new PrintDocument();
        pri.PrintPage += new PrintPageEventHandler(MyPrintPage);
        pri.Print();
    }

    private void MyPrintPage(object sender, PrintPageEventArgs e)
    {
        try
        {
            Image image = Image.FromFile(path);
            Graphics g = e.Graphics;

            //g.TranslateTransform(0, 0);
            //g.RotateTransform(0);
            g.DrawImage(image, 0, 0, 398.85f, 281.8f);
        }
        catch (Exception ee)
        {
            UnityEngine.Debug.LogError(ee.Message);
        }
    }

    public void InvokePrint01()
    {
        Process.Start("mspaint.exe", "/pt d:\\44.png");
    }

    public void InvokePrint02(string path)
    {
        if (!File.Exists(path)) return;

        Process process = new Process(); //系统进程

        process.StartInfo.CreateNoWindow = false; //不显示调用程序窗口

        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        process.StartInfo.UseShellExecute = true; //采用操作系统自动识别模式

        process.StartInfo.FileName = path; //要打印的文件路径

        process.StartInfo.Verb = "print"; //指定执行的动作

        process.Start(); //开始打印
    }
}

