using UnityEngine;
using Zenject;

public class CarSlotInGarage : MonoBehaviour
{
    [SerializeField] private GameObject _currentSpawnedCar;
    [SerializeField] private Transform _carSpawnPoint;
    
    private PlayerViewModel _playerViewModel;
    
    [Inject]
    public void Construct(PlayerViewModel playerViewModel)
    {
        _playerViewModel = playerViewModel;
    }

    void Start()
    {
        SetCar(_playerViewModel.CarId.Value);
    }
    public void SetCar(int idCar)
    {
        var linkOnCar = CarPrefabsPath.CarList[idCar];
        var myPrefab = Resources.Load(linkOnCar) as GameObject;
        _currentSpawnedCar = Instantiate(myPrefab, _carSpawnPoint.position, Quaternion.identity);
        _currentSpawnedCar.transform.rotation = Quaternion.Euler(0,30f,0);
        _currentSpawnedCar.GetComponent<PrometeoCarController>().enabled = false;
    }
}
