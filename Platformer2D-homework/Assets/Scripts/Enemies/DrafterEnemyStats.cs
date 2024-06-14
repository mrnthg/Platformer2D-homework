using UnityEngine;
using UnityEngine.UI;

public class DrafterEnemyStats : MonoBehaviour
{

    [SerializeField] private Text _healthOnScreen;
    private EnemyBattler _enemyBattler;

    private void Awake()
    {
        _enemyBattler = GetComponent<EnemyBattler>();
    }

    private void OnEnable()
    {
        _enemyBattler.changeHealth += DrawHealthBar;
    }

    private void DrawHealthBar(float health)
    {
        _healthOnScreen.text = ("HP: " + health.ToString());
    }
}
