using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIXiBei : UIBase 
{
    private Button mButton_ShanXi;
    private Button mButton_GanSu;
    private Button mButton_QingHai;
    private Button mButton_NingXia;
    private Button mButton_XinJiang;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.XIBEI_PANEL);
    }

    private void Start()
    {
        mButton_ShanXi = Global.FindChild<Button>(transform, "ShanXi");
        mButton_GanSu = Global.FindChild<Button>(transform, "GanSu");
        mButton_QingHai = Global.FindChild<Button>(transform, "QingHai");
        mButton_NingXia = Global.FindChild<Button>(transform, "NingXia");
        mButton_XinJiang = Global.FindChild<Button>(transform, "XinJiang");
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
        mButton_ShanXi.onClick.AddListener(OnButtonShanXi);
        mButton_GanSu.onClick.AddListener(OnButtonGanSu);
        mButton_QingHai.onClick.AddListener(OnButtonQingHai);
        mButton_NingXia.onClick.AddListener(OnButtonNingXia);
        mButton_XinJiang.onClick.AddListener(OnButtonXinJiang);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }


    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.XIBEI_PANEL:
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

    private void OnButtonShanXi()
    {
        msg.cityName_ch = "陕西";
        msg.cityName_en = "XIBEI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonGanSu()
    {
        msg.cityName_ch = "甘肃";
        msg.cityName_en = "GANSU\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonQingHai()
    {
        msg.cityName_ch = "青海";
        msg.cityName_en = "QINGHAI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonNingXia()
    {
        msg.cityName_ch = "宁夏";
        msg.cityName_en = "NINGXIA\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonXinJiang()
    {
        msg.cityName_ch = "新疆";
        msg.cityName_en = "XINJIANG\nSTATION";

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
        windowTrans.DOLocalMoveY(280, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveY(146, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

