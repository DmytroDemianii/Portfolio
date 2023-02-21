using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingMenu;

    public static bool isPaused;


    public void CloseSettingMenu()
    {
        _settingMenu.SetActive(true);
        Pause();   
    }
    public void OpenSettingMenu()
    {
        _settingMenu.SetActive(false);
        Resume();
    }

    public void Resume()
    {
        isPaused = true;
    }
    void Pause()
    {
        isPaused = false;
    }
}