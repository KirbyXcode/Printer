using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHuaDong : UIBase 
{
    private Button mButton_Shanghai;
    private Button mButton_Jiangsu;
    private Button mButton_Zhejiang;
    private Button mButton_Anhui;
    private Button mButton_Fujian;
    private Button mButton_Jiangxi;
    private Button mButton_Shandong;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.HUADONG_PANEL);
    }

    private void Start()
    {
        mButton_Shanghai = Global.FindChild<Button>(transform, "Shanghai");
        mButton_Jiangsu = Global.FindChild<Button>(transform, "Jiangsu");
        mButton_Zhejiang = Global.FindChild<Button>(transform, "Zhejiang");
        mButton_Anhui = Global.FindChild<Button>(transform, "Anhui");
        mButton_Fujian = Global.FindChild<Button>(transform, "Fujian");
        mButton_Jiangxi = Global.FindChild<Button>(transform, "Jiangxi");
        mButton_Shandong = Global.FindChild<Button>(transform, "Shandong");
        mButton_Close = Global.FindChild<Button>(transform, "CloseButton");

        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
        windowTrans = transform.Find("Window");
        msg = new Message();

        InitListener();

        SetPanelActive(false);
    }

    private void InitListener()
    {
        mButton_Shanghai.onClick.AddListener(OnButtonShanghai);
        mButton_Jiangsu.onClick.AddListener(OnButtonJiangsu);
        mButton_Zhejiang.onClick.AddListener(OnButtonZhejiang);
        mButton_Anhui.onClick.AddListener(OnButtonAnhui);
        mButton_Fujian.onClick.AddListener(OnButtonFujian);
        mButton_Jiangxi.onClick.AddListener(OnButtonJiangxi);
        mButton_Shandong.onClick.AddListener(OnButtonShandong);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.HUADONG_PANEL:
                bool active = (bool)message;
                if (active)
                {
                    EnterAnim();
                }
                else
                {
                    ExitAnim();
                }
                break;
        }
    }

    private void OnButtonShanghai()
    {
        msg.cityName_ch = "上海";
        msg.cityName_en = "SHANGHAI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonJiangsu()
    {
        msg.cityName_ch = "江苏";
        msg.cityName_en = "JIANGSU\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonZhejiang()
    {
        msg.cityName_ch = "浙江";
        msg.cityName_en = "ZHEJIANG\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonAnhui()
    {
        msg.cityName_ch = "安徽";
        msg.cityName_en = "ANHUI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }


    private void OnButtonFujian()
    {
        msg.cityName_ch = "福建";
        msg.cityName_en = "FUJIAN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonJiangxi()
    {
        msg.cityName_ch = "江西";
        msg.cityName_en = "JIANGXI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonShandong()
    {
        msg.cityName_ch = "山东";
        msg.cityName_en = "SHANDONG\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonClose()
    {
        ExitAnim();
        Dispatch(UIEvent.STATION_SETPOINT, false);
    }

    protected override void EnterAnim()
    {
        gameObject.SetActive(true);
        cg.DOFade(1, 0.4f);
        windowTrans.DOLocalMoveX(633, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveX(512, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

