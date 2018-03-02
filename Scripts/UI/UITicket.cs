using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class UITicket : UIBase
{
    private Text mText_VisitorNum;
    private Text mText_Date;
    private Text mText_Location;
    private Text mText_Origin_CN;
    private Text mText_Origin_EN;
    private Text mText_Origin;
    private Button mButton_Ticket;
    private Button mButton_Back;

    private Texture2D texture;
    private Data data;
    private Message msg;

    private string path;

    private void Awake()
    {
        Bind(UIEvent.TICKET_PANEL_ACTIVE, UIEvent.TICKET_PANEL_DEACTIVE);
    }

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        mText_VisitorNum = Global.FindChild<Text>(transform, "VisitorNum");
        mText_Date = Global.FindChild<Text>(transform, "Date");
        mText_Location = Global.FindChild<Text>(transform, "Location");
        mText_Origin_CN = Global.FindChild<Text>(transform, "Origin_CN");
        mText_Origin_EN = Global.FindChild<Text>(transform, "Origin_EN");
        mText_Origin = Global.FindChild<Text>(transform, "Origin");
        mButton_Ticket = Global.FindChild<Button>(transform, "TicketButton");
        mButton_Back = Global.FindChild<Button>(transform, "BackButton");

        InitListener();

        data = JsonManager.Instance.GetData();
        msg = new Message();
        path = Application.streamingAssetsPath + "/ticket.jpg";

        SetPanelActive(false);
    }

    private void InitListener()
    {
        mButton_Ticket.onClick.AddListener(OnButtonTicket);
        mButton_Back.onClick.AddListener(OnButtonBack);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.TICKET_PANEL_ACTIVE:
                msg = message as Message;
                EnterAnim();
                SetInfo();
                break;
        }
    }

    private void OnButtonTicket()
    {
        ScreenShot();
        ExitAnim();
        Dispatch(UIEvent.START_PANEL, true);
        msg = null;
    }

    private void OnButtonBack()
    {
        ExitAnim();
        Dispatch(UIEvent.STATION_PANEL, true);
    }

    private void ScreenShot()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                texture = new Texture2D(1000, 1000, TextureFormat.RGB24, false);
                texture.ReadPixels(new Rect(10f, 100f, 398.85f, 281.8f), 0, 0, false);
                texture.Apply();
                byte[] bytes1 = texture.EncodeToJPG();
                File.WriteAllBytes(path, bytes1);

                Dispatch(AreaCode.PRINTER, 0, path);
                break;
            case RuntimePlatform.WindowsPlayer:
                texture = new Texture2D(399, 282, TextureFormat.RGB24, false);
                texture.ReadPixels(new Rect(757.55f, 431.78f, 398.85f, 281.8f), 0, 0, false);
                texture.Apply();
                byte[] bytes = texture.EncodeToJPG();
                File.WriteAllBytes(path, bytes);

                Dispatch(AreaCode.PRINTER, 0, path);
                break;
        }
    }

    private void SetInfo()
    {
        SetVisitorNum();
        SetDate();
        SetLocation();
        SetOrigin();
    }

    private void SetVisitorNum()
    {
        data.visitorIndex++;

        Dispatch(AreaCode.JSON, 0, data);

        mText_VisitorNum.text = "您是第" + data.visitorIndex + "位参观者";
    }

    private void SetDate()
    {
        string date = DateTime.Now.ToString("MM-dd");
        string[] strs = date.Split('-');
        strs[0] = int.Parse(strs[0]).ToString();
        strs[1] = int.Parse(strs[1]).ToString();
        mText_Date.text = strs[0] + "月" + strs[1] + "日";
    }

    private void SetLocation()
    {
        int coach = UnityEngine.Random.Range(1, 19);
        int seat = UnityEngine.Random.Range(1, 119);
        mText_Location.text = coach + "節" + seat + "座";
    }

    private void SetOrigin()
    {
        if (msg != null)
        {
            mText_Origin.text = string.Empty;
            mText_Origin_CN.text = msg.cityName_ch;
            mText_Origin_EN.text = msg.cityName_en;

            for (int i = 0; i < msg.cityName_ch.Length; i++)
            {
                if(i == msg.cityName_ch.Length-1)
                {
                    mText_Origin.text += msg.cityName_ch[i];
                }
                else
                {
                    mText_Origin.text += msg.cityName_ch[i] + "\n";
                }
            }
        }
    }
}

