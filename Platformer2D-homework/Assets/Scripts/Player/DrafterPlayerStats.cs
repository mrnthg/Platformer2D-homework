using UnityEngine;
using UnityEngine.UI;

public class DrafterPlayerStats : MonoBehaviour
{
    [SerializeField] private Text _healthOnScreen;
    private PlayerBattler _playerBattler;

    private void Awake()
    {
        _playerBattler = GetComponent<PlayerBattler>();
    }

    private void OnEnable()
    {
        _playerBattler.changeHealth += DrawHealthBar;
    }

    private void DrawHealthBar(float health)
    {
        _healthOnScreen.text = ("HP: " + health.ToString());
    }
}
