using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIStation : UIBase 
{
    private Button mButton_DongBei;
    private Button mButton_HuaBei;
    private Button mButton_HuaDong;
    private Button mButton_HuaNan;
    private Button mButton_HuaZhong;
    private Button mButton_XiNan;
    private Button mButton_XiBei;
    private Button mButton_Back;

    private Image mImage_SelectPoint;

    public Sprite mSprite_Normal;
    public Sprite mSprite_Press;

    private void Awake()
    {
        Bind(UIEvent.STATION_PANEL, UIEvent.STATION_SETPOINT);
    }

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        mButton_DongBei = Global.FindChild<Button>(transform, "DongBei");
        mButton_HuaBei = Global.FindChild<Button>(transform, "HuaBei");
        mButton_HuaDong = Global.FindChild<Button>(transform, "HuaDong");
        mButton_HuaNan = Global.FindChild<Button>(transform, "HuaNan");
        mButton_HuaZhong = Global.FindChild<Button>(transform, "HuaZhong");
        mButton_XiNan = Global.FindChild<Button>(transform, "XiNan");
        mButton_XiBei = Global.FindChild<Button>(transform, "XiBei");
        mButton_Back = Global.FindChild<Button>(transform, "BackButton");

        InitListener();

        SetPanelActive(false);
    }

    private void InitListener()
    {
        mButton_DongBei.onClick.AddListener(OnButtonDongBei);
        mButton_HuaBei.onClick.AddListener(OnButtonHuaBei);
        mButton_HuaDong.onClick.AddListener(OnButtonHuaDong);
        mButton_HuaNan.onClick.AddListener(OnButtonHuaNan);
        mButton_HuaZhong.onClick.AddListener(OnButtonHuaZhong);
        mButton_XiNan.onClick.AddListener(OnButtonXiNan);
        mButton_XiBei.onClick.AddListener(OnButtonXiBei);

        mButton_Back.onClick.AddListener(OnButtonBack);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.STATION_PANEL:
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
            case UIEvent.STATION_SETPOINT:
                bool mActive = (bool)message;
                SetPoint(mActive);
                break;
        }
    }

    private void OnButtonDongBei()
    {
        Dispatch(UIEvent.DONGBEI_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonHuaBei()
    {
        Dispatch(UIEvent.HUABEI_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonHuaDong()
    {
        Dispatch(UIEvent.HUADONG_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonHuaNan()
    {
        Dispatch(UIEvent.HUANAN_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonXiBei()
    {
        Dispatch(UIEvent.XIBEI_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonXiNan()
    {
        Dispatch(UIEvent.XINAN_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonHuaZhong()
    {
        Dispatch(UIEvent.HUAZHONG_PANEL, true);
        SetPoint(true);
    }

    private void OnButtonBack()
    {
        ExitAnim();
        Dispatch(UIEvent.START_PANEL, true);
    }

    private void SetPoint(bool active)
    {
        if(active)
        {
            mImage_SelectPoint = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
            mImage_SelectPoint.sprite = mSprite_Press;
        }
        else
        {
            mImage_SelectPoint.sprite = mSprite_Normal;
        }
    }
}
