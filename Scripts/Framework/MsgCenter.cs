public class MsgCenter : MonoBase
{
    public static MsgCenter Instance = null;

    void Awake()
    {
        Instance = this;

        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<PrinterManager>();
        gameObject.AddComponent<JsonManager>();

        DontDestroyOnLoad(gameObject);
    }

    public void Dispatch(int areaCode, int eventCode, object message)
    {
        switch (areaCode)
        {
            case AreaCode.AUDIO:
                AudioManager.Instance.Execute(eventCode, message);
                break;
            case AreaCode.UI:
                UIManager.Instance.Execute(eventCode, message);
                break;
            case AreaCode.PRINTER:
                PrinterManager.Instance.Execute(eventCode, message);
                break;
            case AreaCode.JSON:
                JsonManager.Instance.Execute(eventCode, message);
                break;
        }
    }
}