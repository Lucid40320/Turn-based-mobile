using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
  public UnityEvent OnStart = new UnityEvent();

  private void Start()
  {
    OnStart.Invoke();
  }
}
