using UniRx;

public class GoldWallet : WalletBase
{
    public const string KEY = "GoldWallet";

    public void Init() {
        LoadWallet();
        base.Currency.Subscribe(save => { SaveWallet(); }).AddTo(base.disposables);
    }
    public void LoadWallet()
    {
        var value = SaveManager.Load<double>(KEY);
        base.SetValue(value);
    }
    public void SaveWallet()
    {
        SaveManager.Save(KEY, Currency.Value);
    }
}
