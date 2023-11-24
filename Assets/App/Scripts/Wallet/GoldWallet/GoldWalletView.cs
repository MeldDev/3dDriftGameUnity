using UnityEngine;
using TMPro;
using Zenject;
using UniRx;
using MyServices;

public class GoldWalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldValue_TMP;

    private GoldWalletViewModel _goldWalletViewModel;
    private CompositeDisposable disposables = new CompositeDisposable();

    [Inject]
    public void Constuct(GoldWalletViewModel GoldWalletViewModel)
    {
        _goldWalletViewModel = GoldWalletViewModel;
    }
    private void UpdateUI()
    {
        _goldValue_TMP.text = ConverterDigitToString.FormatNum(_goldWalletViewModel.GoldValue.Value);
    }
    private void OnEnable()
    {
        _goldWalletViewModel.GoldValue.Subscribe(_ => {
            UpdateUI();
        }).AddTo(disposables);
    }
    private void OnDisable()
    {
        disposables.Dispose();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _goldWalletViewModel.PlusValue(12);
        }
    }
}
