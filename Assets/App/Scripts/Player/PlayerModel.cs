using UniRx;
using UnityEngine;

public class PlayerModel
{
    ReactiveProperty<int> _carId = new ReactiveProperty<int>();
    ReactiveProperty<Color32> _carColor = new ReactiveProperty<Color32>();

    public IReadOnlyReactiveProperty<int> CarId => _carId;
    public IReadOnlyReactiveProperty<Color32> CarColor => _carColor;

    protected CompositeDisposable disposables = new CompositeDisposable();
    private const string KEY = "PlayerModel";

    private PlayerModel()
    {
        var save = SaveManager.Load<PlayerData>(KEY);
        if (save != null)
        {
            _carId.Value = save.CarId;
            _carColor.Value = new Color32(save.Color32[0], save.Color32[1], save.Color32[2], save.Color32[3]);
        }
        else
        {
            _carId.Value = 0;
            _carColor.Value = new Color32(225,0,0,225);
            Save();
        }
    }
    public void Save()
    {
        var data = new PlayerData();
        data.CarId = _carId.Value;
        data.Color32 = new byte[4] {_carColor.Value.r, _carColor.Value.g, _carColor.Value.b, _carColor.Value.a };
        SaveManager.Save(KEY, data);
    }

    public void SetCar(int newCar)
    {
        _carId.Value = newCar;
        Save();
    }
    public void SetCarColor(Color32 newCarColor)
    {
        _carColor.Value = newCarColor;
        Save();
    }
}
