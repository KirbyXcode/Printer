using UnityEngine;
using UnityEngine.UI;

public class UIStart : UIBase 
{
    private Button mButton_Start;
    //private GameObject glow;

    private void Awake()
    {
        Bind(UIEvent.START_PANEL);
    }

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        //glow = Global.FindChild<Transform>(transform, "Glow").gameObject;
        mButton_Start = Global.FindChild<Button>(transform, "StartButton");
        mButton_Start.onClick.AddListener(OnButtonStart);
    }

    private void OnButtonStart()
    {
        ExitAnim();
        Dispatch(UIEvent.STATION_PANEL, true);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.START_PANEL:
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

    protected override void EnterAnim() 
    {
        base.EnterAnim();
        //glow.SetActive(true);
    }

    protected override void ExitAnim()
    {
        base.ExitAnim();
        //glow.SetActive(false);
    }
}

