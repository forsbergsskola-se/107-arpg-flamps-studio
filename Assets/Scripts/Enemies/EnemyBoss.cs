using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public List<Vector3> MovementPoints;


    #region Editor Drawing Configuration

    private const float DbgPointDrawRadius = 0.2f;
    private static readonly Color DbgPointDrawColorFirst = new(1, 0, 0, 0.5f),
                                  DbgPointDrawColorLast  = new(0, 1, 0, 0.5f);  // interpolate towards this
    #endregion

    private void OnDrawGizmos()
    {
        DrawEditorMovementPoints();
    }

    private void DrawEditorMovementPoints()
    {
        for (int pointIndex = 0; pointIndex < MovementPoints.Count; pointIndex++)
        {
            float curLerpAmount = ((float)pointIndex / MovementPoints.Count-1); // 0 at first index, 1 at last index, interpolates between

            Gizmos.color = Color.Lerp(DbgPointDrawColorFirst, DbgPointDrawColorLast, curLerpAmount);
            // Debug.Log("");
            Gizmos.DrawSphere(MovementPoints[pointIndex], DbgPointDrawRadius);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
