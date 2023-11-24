using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CashWallet>().AsSingle();
        Container.Bind<CashWalletViewModel>().AsSingle();

        Container.Bind<GoldWallet>().AsSingle();
        Container.Bind<GoldWalletViewModel>().AsSingle();

        Container.Bind<PlayerModel>().AsSingle().NonLazy();
        Container.Bind<PlayerViewModel>().AsSingle().NonLazy();
    }
}
