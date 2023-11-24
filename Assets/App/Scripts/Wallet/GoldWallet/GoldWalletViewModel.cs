using UniRx;

public class GoldWalletViewModel
{
    public IReadOnlyReactiveProperty<double> GoldValue => _goldValue;

    private ReactiveProperty<double> _goldValue = new ReactiveProperty<double>();
    private CompositeDisposable _disposables = new CompositeDisposable();
    private WalletBase _wallet;
    
    public GoldWalletViewModel(GoldWallet wallet)
    {
        wallet.Init();
        _wallet = wallet;

        _wallet.Currency.Subscribe(_ => {
        _goldValue.Value = _wallet.Currency.Value;
        }).AddTo(_disposables);
    }
    public void PlusValue(double value)
    {
        var sum = _wallet.Currency.Value + value;
        _wallet.SetValue(sum);
    }
    public void MinusValue(double value)
    {
        var difference = _wallet.Currency.Value - value;
        if (_wallet.Currency.Value >= difference)
        {
            _wallet.SetValue(difference);
        }
    }

}
