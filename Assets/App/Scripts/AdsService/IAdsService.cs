public interface IAdsService
{
    // ѕоказывает межстраничный рекламный баннер
    void ShowInterstitialAd();

    // ѕровер€ет, готов ли межстраничный рекламный баннер дл€ показа
    bool IsInterstitialAdReady();

    // ѕоказывает рекламный баннер с возможностью получени€ вознаграждени€
    void ShowRewardedAd();

    // ѕровер€ет, готов ли рекламный баннер с возможностью получени€ вознаграждени€ дл€ показа
    bool IsRewardedAdReady();

    // «агружает рекламный контент из сети
    void LoadAd(string placementName);

    // ѕоказывает баннер
    void ShowBannerAd();

    // —крывает показанный баннер
    void HideBannerAd();

    // ѕауза показа рекламы
    void PauseAd();

    // ¬озобновление показа рекламы
    void ResumeAd();
}