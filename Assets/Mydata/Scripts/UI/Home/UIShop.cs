public class UIShop : BaseAppear
{
    protected override void OnDisable()
    {
        base.OnDisable();
        Hide();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Appear();
    }
}