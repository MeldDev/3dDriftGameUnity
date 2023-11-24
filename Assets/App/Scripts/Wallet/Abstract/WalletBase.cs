using UniRx;

public abstract class WalletBase
{
    ReactiveProperty<double> _currency = new ReactiveProperty<double>();
    protected CompositeDisposable disposables = new CompositeDisposable();
    public IReadOnlyReactiveProperty<double> Currency => _currency;

    public void SetValue(double newValue)
    {
        _currency.Value = newValue;
    }

}
