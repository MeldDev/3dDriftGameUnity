using UnityEngine;
using TMPro;
using Zenject;
using UniRx;
using MyServices;

public class CashWalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cashValue_TMP;

    private CashWalletViewModel _cashWalletViewModel;
    private CompositeDisposable disposables = new CompositeDisposable();

    [Inject]
    public void Constuct(CashWalletViewModel CashWalletViewModel)
    {
        _cashWalletViewModel = CashWalletViewModel;
    }
    private void UpdateUI()
    {
        _cashValue_TMP.text = ConverterDigitToString.FormatNum(_cashWalletViewModel.CashValue.Value);
    }
    private void OnEnable()
    {
        _cashWalletViewModel.CashValue.Subscribe(_ => {
            UpdateUI();
        }).AddTo(disposables);
    }
    private void OnDisable()
    {
        disposables.Dispose();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _cashWalletViewModel.PlusValue(12);
        }
    }
}
