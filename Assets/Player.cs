using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private TurnBasedEntity _turnBasedEntity;

  private void Awake()
  {
    _turnBasedEntity = GetComponent<TurnBasedEntity>();
  }

  public void Up() => Move(Vector2Int.up);
  public void Left() => Move(Vector2Int.left);
  public void Right() => Move(Vector2Int.right);
  public void Down() => Move(Vector2Int.down);

  public void Move(Vector2Int direction)
  {
    transform.position += new Vector3(direction.x, direction.y, 0);

    _turnBasedEntity.EndTurn();
  }
}
