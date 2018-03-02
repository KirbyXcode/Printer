using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHuaBei : UIBase 
{
    private Button mButton_BeiJing;
    private Button mButton_TianJin;
    private Button mButton_HeBei;
    private Button mButton_ShanXi;
    private Button mButton_NeiMengGu;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.HUABEI_PANEL);
    }

    private void Start()
    {
        mButton_BeiJing = Global.FindChild<Button>(transform, "BeiJing");
        mButton_TianJin = Global.FindChild<Button>(transform, "TianJin");
        mButton_HeBei = Global.FindChild<Button>(transform, "HeBei");
        mButton_ShanXi = Global.FindChild<Button>(transform, "ShanXi");
        mButton_NeiMengGu = Global.FindChild<Button>(transform, "NeiMengGu");
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
        mButton_BeiJing.onClick.AddListener(OnButtonBeiJing);
        mButton_TianJin.onClick.AddListener(OnButtonTianJin);
        mButton_HeBei.onClick.AddListener(OnButtonHeBei);
        mButton_ShanXi.onClick.AddListener(OnButtonShanXi);
        mButton_NeiMengGu.onClick.AddListener(OnButtonNeiMengGu);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }


    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.HUABEI_PANEL:
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

    private void OnButtonBeiJing()
    {
        msg.cityName_ch = "北京";
        msg.cityName_en = "BEIJING\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonTianJin()
    {
        msg.cityName_ch = "天津";
        msg.cityName_en = "TIANJIN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonHeBei()
    {
        msg.cityName_ch = "河北";
        msg.cityName_en = "HEBEI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonShanXi()
    {
        msg.cityName_ch = "山西";
        msg.cityName_en = "SHANXI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }


    private void OnButtonNeiMengGu()
    {
        msg.cityName_ch = "内蒙古";
        msg.cityName_en = "NEIMENGGU\nSTATION";

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
        windowTrans.DOLocalMoveY(270, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveY(154, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

