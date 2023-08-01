using UnityEngine;
using UnityEngine.Events;

public class TurnBasedEntity : MonoBehaviour
{
  public UnityEvent OnTurn = new UnityEvent();
  public UnityEvent OnEndTurn = new UnityEvent();

  public float Priority = 0;

  void Awake()
  {
    TurnManager.RegisterTileBasedEntity(this);
  }

  public void DoTurn()
  {
    OnTurn.Invoke();
  }

  public void EndTurn()
  {
    OnEndTurn.Invoke();

    TurnManager.EndTurn();
  }
}
