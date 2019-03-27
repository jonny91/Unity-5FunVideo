public interface IVideo
{
    void Init();
    void LoadVideoAd(string[] args);
    void ShowVideoAd(string[] args);
    bool IsAdReady();
}