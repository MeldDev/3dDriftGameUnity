using UnityEngine;
using UniRx;

public class PlayerViewModel
{
    private ReactiveProperty<int> _carId = new ReactiveProperty<int>();
    private ReactiveProperty<Color32> _carColor = new ReactiveProperty<Color32>();

    public IReadOnlyReactiveProperty<int> CarId => _carId;
    public IReadOnlyReactiveProperty<Color32> CarColor => _carColor;

    private CompositeDisposable disposables = new CompositeDisposable();
    private PlayerModel _playerModel;

    public PlayerViewModel(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _playerModel.CarId.Subscribe(carId => {
            _carId.Value = _playerModel.CarId.Value;
        }).AddTo(disposables);

        _playerModel.CarColor.Subscribe(carColor => {
            _carColor.Value = _playerModel.CarColor.Value;
        }).AddTo(disposables);
    }
    public void SetCar(int newCar)
    {
        _carId.Value = newCar;
    }

    public void SetCarColor(Color32 newCarColor)
    {
        _carColor.Value = newCarColor;
    }

    // Очистка ресурсов
    public void Dispose()
    {
        disposables.Dispose();
    }
}