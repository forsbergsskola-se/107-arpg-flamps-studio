using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public List<Vector3> MovementPoints;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        DrawEditorMovementPoints();
    }

    private void DrawEditorMovementPoints()
    {
        for (var pointIndex = 0; pointIndex < MovementPoints.Count; pointIndex++)
        {
            var curLerpAmount =
                (float)pointIndex / (MovementPoints.Count - 1); // 0 at first index, 1 at last index, interpolates between

            Gizmos.color = Color.Lerp(DbgPointDrawColorFirst, DbgPointDrawColorLast, curLerpAmount);
            // Debug.Log("");
            Gizmos.DrawSphere(MovementPoints[pointIndex], DbgPointDrawRadius);
        }
    }


    #region Editor Drawing Configuration

    private const float DbgPointDrawRadius = 0.2f;

    private static readonly Color DbgPointDrawColorFirst = new(1, 0, 0, 0.5f),
        DbgPointDrawColorLast = new(0, 1, 0, 0.5f); // interpolate towards this

    #endregion
}