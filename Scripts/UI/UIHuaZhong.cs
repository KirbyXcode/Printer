using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHuaZhong : UIBase 
{
    private Button mButton_HeNan;
    private Button mButton_HuBei;
    private Button mButton_HuNan;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.HUAZHONG_PANEL);
    }

    private void Start()
    {
        mButton_HeNan = Global.FindChild<Button>(transform, "HeNan");
        mButton_HuBei = Global.FindChild<Button>(transform, "HuBei");
        mButton_HuNan = Global.FindChild<Button>(transform, "HuNan");
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
        mButton_HeNan.onClick.AddListener(OnButtonHeNan);
        mButton_HuBei.onClick.AddListener(OnButtonHuBei);
        mButton_HuNan.onClick.AddListener(OnButtonHuNan);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.HUAZHONG_PANEL:
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

    private void OnButtonHeNan()
    {
        msg.cityName_ch = "河南";
        msg.cityName_en = "HENAN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonHuBei()
    {
        msg.cityName_ch = "湖北";
        msg.cityName_en = "HUBEI\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonHuNan()
    {
        msg.cityName_ch = "湖南";
        msg.cityName_en = "HUNAN\nSTATION";

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
        windowTrans.DOLocalMoveY(33, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveY(-88, 0.4f).OnComplete(() => SetPanelActive(false));
    }

}

