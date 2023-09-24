using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    private Background[] _backgrounds;

    private void Awake()
    {
        _backgrounds = GetComponentsInChildren<Background>();
    }

    public void Switch()
    {
        foreach (var background in _backgrounds)
        {
            background.gameObject.SetActive(false);
        }

        _backgrounds[Random.Range(0, _backgrounds.Length)].gameObject.SetActive(true);
    }
}
