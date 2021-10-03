using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Button _localButton;

    [SerializeField] private Button _cloudButton;

    [SerializeField] private Button _newButton;

    private void Start()
    {
        _newButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(1);
        });

        _localButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            UserDataManager.LoadFromLocal();
            SceneManager.LoadScene(1);
        });

        _cloudButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            StartCoroutine(UserDataManager.LoadFromCloud(() => SceneManager.LoadScene(1)));
        });

        // Button didisable agar mencegah tidak terjadinya spam klik ketika
        // proses onclick pada button sedang berjalan
    }

    // Mendisable button agar tidak bisa ditekan
    private void SetButtonInteractable(bool interactable)
    {
        _localButton.interactable = interactable;
        _cloudButton.interactable = interactable;
        _newButton.interactable = interactable;
    }
}
