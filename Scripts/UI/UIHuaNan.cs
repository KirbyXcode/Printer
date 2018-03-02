using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHuaNan : UIBase 
{
    private Button mButton_GuangDong;
    private Button mButton_GuangXi;
    private Button mButton_HaiNan;
    private Button mButton_XiangGang;
    private Button mButton_AoMeng;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.HUANAN_PANEL);
    }

    private void Start()
    {
        mButton_GuangDong = Global.FindChild<Button>(transform, "GuangDong");
        mButton_GuangXi = Global.FindChild<Button>(transform, "GuangXi");
        mButton_HaiNan = Global.FindChild<Button>(transform, "HaiNan");
        mButton_XiangGang = Global.FindChild<Button>(transform, "XiangGang");
        mButton_AoMeng = Global.FindChild<Button>(transform, "AoMeng");
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
        mButton_GuangDong.onClick.AddListener(OnButtonGuangDong);
        mButton_GuangXi.onClick.AddListener(OnButtonGuangXi);
        mButton_HaiNan.onClick.AddListener(OnButtonHaiNan);
        mButton_XiangGang.onClick.AddListener(OnButtonXiangGang);
        mButton_AoMeng.onClick.AddListener(OnButtonAoMeng);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }


    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.HUANAN_PANEL:
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

    private void OnButtonGuangDong()
    {
        msg.cityName_ch = "广东";
        msg.cityName_en = "GUANGDONG\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonGuangXi()
    {
        msg.cityName_ch = "广西";
        msg.cityName_en = "GUANGXI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonHaiNan()
    {
        msg.cityName_ch = "海南";
        msg.cityName_en = "HAINAN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonXiangGang()
    {
        msg.cityName_ch = "香港";
        msg.cityName_en = "XIANGGANG\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonAoMeng()
    {
        msg.cityName_ch = "澳门";
        msg.cityName_en = "AOMENG\nSTATION";

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
        windowTrans.DOLocalMoveY(-182, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveY(-300, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

