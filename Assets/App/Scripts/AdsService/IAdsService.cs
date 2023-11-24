public interface IAdsService
{
    // ���������� ������������� ��������� ������
    void ShowInterstitialAd();

    // ���������, ����� �� ������������� ��������� ������ ��� ������
    bool IsInterstitialAdReady();

    // ���������� ��������� ������ � ������������ ��������� ��������������
    void ShowRewardedAd();

    // ���������, ����� �� ��������� ������ � ������������ ��������� �������������� ��� ������
    bool IsRewardedAdReady();

    // ��������� ��������� ������� �� ����
    void LoadAd(string placementName);

    // ���������� ������
    void ShowBannerAd();

    // �������� ���������� ������
    void HideBannerAd();

    // ����� ������ �������
    void PauseAd();

    // ������������� ������ �������
    void ResumeAd();
}