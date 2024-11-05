using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] protected int level;

  public EnemySpawner enemySpawner;

  public void SetLevel(int level)
  {
    this.level = level;
  }

  public int GetLevel()
  {
    return level;
  }

  private void OnDestroy()
  {
    enemySpawner.OnEnemyKilled();
  }
}
