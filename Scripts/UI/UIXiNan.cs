using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIXiNan : UIBase 
{
    private Button mButton_ChongQing;
    private Button mButton_SiChuan;
    private Button mButton_GuiZhou;
    private Button mButton_YunNan;
    private Button mButton_XiZang;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.XINAN_PANEL);
    }

    private void Start()
    {
        mButton_ChongQing = Global.FindChild<Button>(transform, "ChongQing");
        mButton_SiChuan = Global.FindChild<Button>(transform, "SiChuan");
        mButton_GuiZhou = Global.FindChild<Button>(transform, "GuiZhou");
        mButton_YunNan = Global.FindChild<Button>(transform, "YunNan");
        mButton_XiZang = Global.FindChild<Button>(transform, "XiZang");
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
        mButton_ChongQing.onClick.AddListener(OnButtonChongQing);
        mButton_SiChuan.onClick.AddListener(OnButtonSiChuan);
        mButton_GuiZhou.onClick.AddListener(OnButtonGuiZhou);
        mButton_YunNan.onClick.AddListener(OnButtonYunNan);
        mButton_XiZang.onClick.AddListener(OnButtonXiZang);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }


    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.XINAN_PANEL:
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

    private void OnButtonChongQing()
    {
        msg.cityName_ch = "重庆";
        msg.cityName_en = "CHONGQING\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonSiChuan()
    {
        msg.cityName_ch = "四川";
        msg.cityName_en = "SICHUAN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonGuiZhou()
    {
        msg.cityName_ch = "贵州";
        msg.cityName_en = "GUIZHOU\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonYunNan()
    {
        msg.cityName_ch = "云南";
        msg.cityName_en = "YUNNAN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }


    private void OnButtonXiZang()
    {
        msg.cityName_ch = "西藏";
        msg.cityName_en = "XIZANG\nSTATION";

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
        windowTrans.DOLocalMoveX(-370, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveX(-226, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

