using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
  public static TurnManager Me { get; private set; }

  private List<TurnBasedEntity> _turnBasedEntities = new List<TurnBasedEntity>();
  private List<TurnBasedEntity> _turnBasedEntityQueue = new List<TurnBasedEntity>();

  private void Awake()
  {
    if (Me != null)
    {
      Destroy(gameObject);

      return;
    }

    Me = this;

    foreach (TurnBasedEntity entity in FindObjectsOfType<TurnBasedEntity>())
    {
      RegisterTileBasedEntity(entity);
    }
  }

  public static void RegisterTileBasedEntity(TurnBasedEntity entity)
  {
    if (Me == null) return;

    if (Me._turnBasedEntities.Contains(entity)) return;

    Me._turnBasedEntities.Add(entity);
  }

  public static void StartRound()
  {
    Me._turnBasedEntityQueue = new List<TurnBasedEntity>(Me._turnBasedEntities);
    Me._turnBasedEntityQueue.Sort((a, b) => a.Priority.CompareTo(b.Priority));

    if (Me._turnBasedEntityQueue.Count == 0) return;

    TurnBasedEntity nextEntity = Me._turnBasedEntityQueue[0];

    Me._turnBasedEntityQueue.RemoveAt(0);

    nextEntity.DoTurn();
  }

  public static void EndTurn()
  {
    if (Me._turnBasedEntityQueue.Count == 0)
    {
      StartRound();

      return;
    }

    TurnBasedEntity nextEntity = Me._turnBasedEntityQueue[0];

    Me._turnBasedEntityQueue.RemoveAt(0);

    nextEntity.DoTurn();
  }
}
