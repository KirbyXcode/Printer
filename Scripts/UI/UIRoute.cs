using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIRoute : UIBase 
{
    private Text mText_OriginCity;
    private Button mButton_Sure;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.ROUTE_PANEL);
    }

    private void Start()
    {
        mText_OriginCity = Global.FindChild<Text>(transform, "OriginCity");
        mButton_Sure = Global.FindChild<Button>(transform, "SureButton");
        mButton_Close = Global.FindChild<Button>(transform, "CloseButton");
        windowTrans = transform.Find("Window");

        windowTrans.localScale = Vector3.zero;

        InitListener();

        SetPanelActive(false);
    }

    private void InitListener()
    {
        mButton_Sure.onClick.AddListener(OnButtonSure);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.ROUTE_PANEL:
                msg = message as Message;
                EnterAnim();
                SetOrigin(msg.cityName_ch);
                break;
        }
    }

    private void OnButtonSure()
    {
        ExitAnim();
        Dispatch(UIEvent.STATION_SETPOINT, false);
        Dispatch(UIEvent.STATION_PANEL, false);
        Dispatch(UIEvent.TICKET_PANEL_ACTIVE, msg);
    }

    private void OnButtonClose()
    {
        ExitAnim();
        Dispatch(UIEvent.STATION_SETPOINT, false);
    }

    private void SetOrigin(string cityName)
    {
        if (cityName != null)
            mText_OriginCity.text = cityName;
    }

    protected override void EnterAnim()
    {
        SetPanelActive(true);
        windowTrans.DOScale(1, 0.4f);
    }

    protected override void ExitAnim()
    {
        windowTrans.DOScale(0, 0.4f).OnComplete(() => SetPanelActive(false));
    }
}

