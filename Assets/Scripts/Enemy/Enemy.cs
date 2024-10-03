using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int Level { get; private set; }

  private void Awake()
  {
    Level = Mathf.CeilToInt(GetComponent<HealthComponent>().maxHealth / 100);
  }
}
