using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UICombat : MonoBehaviour
{
    public Label health;
    public Label points;

    public Label wave;
    public Label enemiesLeft;

    public Player player;
    public CombatManager combatManager;

    private void Start()
    {

    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        health = root.Q<Label>("HealthNumber");
        points = root.Q<Label>("PointNumber");
        wave = root.Q<Label>("WaveNumber");
        enemiesLeft = root.Q<Label>("EnemiesNumber");

        ChangeHealth();
        ChangePoints();
        ChangeWave();
        ChangeEnemiesLeft();

        player.GetComponent<HitboxComponent>().OnHitboxCollide.AddListener(ChangeHealth);
    }

    public void ChangeHealth()
    {
        health.text = player.GetComponent<HealthComponent>().GetHealth().ToString();
    }

    public void ChangePoints()
    {
        points.text = combatManager.points.ToString();
    }

    public void ChangeWave()
    {
        wave.text = (combatManager.waveNumber - 1).ToString();
    }

    public void ChangeEnemiesLeft()
    {
        enemiesLeft.text = combatManager.totalEnemies.ToString();
    }
}
