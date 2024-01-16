using UnityEngine.EventSystems;

public class CheckRawImage : MyMonoBehavior, IPointerDownHandler, IPointerUpHandler
{
    private static CheckRawImage instance;
    public static CheckRawImage Instance => instance;

    private bool isPointerDown = false;
    public bool IsPointerDown => isPointerDown;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        isPointerDown = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        CrossbowCtrl.Instance.Show("Rare");
    }
}
