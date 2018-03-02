public class UIManager : ManagerBase 
{
    public static UIManager Instance = null;

    void Awake()
    {
        Instance = this;
    }
}
