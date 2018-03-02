using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIDongBei : UIBase
{
    private Button mButton_LiaoNing;
    private Button mButton_JiLin;
    private Button mButton_HeiLongJiang;
    private Button mButton_Close;

    private Transform windowTrans;
    private Message msg;

    private void Awake()
    {
        Bind(UIEvent.DONGBEI_PANEL);
    }

    private void Start()
    {
        mButton_LiaoNing = Global.FindChild<Button>(transform, "LiaoNing");
        mButton_JiLin = Global.FindChild<Button>(transform, "JiLin");
        mButton_HeiLongJiang = Global.FindChild<Button>(transform, "HeiLongJiang");
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
        mButton_LiaoNing.onClick.AddListener(OnButtonLiaoNing);
        mButton_JiLin.onClick.AddListener(OnButtonJiLin);
        mButton_HeiLongJiang.onClick.AddListener(OnButtonHeiLongJiang);
        mButton_Close.onClick.AddListener(OnButtonClose);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.DONGBEI_PANEL:
                bool active = (bool)message;
                if(active)
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

    private void OnButtonLiaoNing()
    {
        msg.cityName_ch = "辽宁";
        msg.cityName_en = "LIAONING\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonJiLin()
    {
        msg.cityName_ch = "吉林";
        msg.cityName_en = "JILIN\nSTATION";

        Dispatch(UIEvent.ROUTE_PANEL, msg);
        ExitAnim();
    }

    private void OnButtonHeiLongJiang()
    {
        msg.cityName_ch = "黑龙江";
        msg.cityName_en = "HEILONGJIANG\nSTATION";

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
        windowTrans.DOLocalMoveX(632, 0.4f);
    }

    protected override void ExitAnim()
    {
        cg.DOFade(0, 0.4f);
        windowTrans.DOLocalMoveX(544, 0.4f).OnComplete(() => SetPanelActive(false));
    }
     
}
