using System;
using System.Collections.Generic;
using UnityEngine;
using static Enemies.ActionState;

namespace Enemies
{
    public class EnemyBoss : Enemy
    {
        [Header("Movement")]
        public List<Vector3> movementPoints;
        public bool drawMovementGizmos = true;
        private static readonly float DbgPointRadius = 0.2f;
        private static readonly Color 
            DbgColorPointFirst = new(0, 1, 0, 0.5f), // first point color
            DbgColorPointLast = new(1, 0, 0, 0.5f),  // interpolate to (and reach) this color
            DbgColorLine = new(.6f, .6f, 0, 1f);     // connecting line
        
        protected Dictionary<ActionState, Action> StateHandlers;

        private ActionState _curActionState; // not sure this is very useful
        public ActionState CurActionState
        {
            get => _curActionState;
            set
            {
                _curActionState = value;
                InvokeState(value);
            }
        }

        [Header("NPC AI")] public ActionState initialState = Idle;

        // Start is called before the first frame update
        private void Start()
        {
            // TODO: Do derived classes call parental unity events?
            // TODO: Implement checks to validate that all ActionState have valid methods
            StateHandlers = new Dictionary<ActionState, Action>
            {
                { Idle, ActionStateIdle },
                { Movement, ActionStateMovement },
                { AttackBasic, ActionStateNotImplemented },
                { AttackAbility, ActionStateNotImplemented },
            };

            CurActionState = initialState;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        // Passed onto derived classes and uses the StateHandlers dict to select logic
        protected void InvokeState(ActionState newState)
        {
            Debug.Log($"GameObject #{gameObject.GetInstanceID()}: Attempting to enter state: { Enum.GetName(typeof(ActionState), newState) }");
            StateHandlers[newState].Invoke();
        }
        
        // Can be derived and overriden
        protected virtual void ActionStateIdle()
        {
            Debug.Log("Boss Entered State: Idle");
        }

        // Can be derived and overriden
        protected virtual void ActionStateMovement()
        {
            Debug.Log("Boss Entered State: Movement");
        }
        
                // Can be derived and overriden
        protected virtual void ActionStateNotImplemented()
        {
            Debug.Log("BOSS ATTEMPTED TO ENTER UNIMPLEMENTED STATE");
        }
        
        
        private void OnDrawGizmos()
        {
            if (drawMovementGizmos)
                DrawEditorMovementPoints();
        }
    
        // TODO/IDEA: perhaps replace this with the splines package
        private void DrawEditorMovementPoints()
        {
            // lastPointLoc is used for drawing lines between the spheres
            // rider wants the default literal so I guess I'll obey ¯\_(ツ)_/¯ 
            Vector3 lastPointLoc = default;  

            for (var pointIndex = 0; pointIndex < movementPoints.Count; pointIndex++)
            {
                var curLerpAmount =
                    (float)pointIndex / (movementPoints.Count - 1); // 0 at first index, 1 at last index, interpolates between

                var curPointLoc = movementPoints[pointIndex];
            
                Gizmos.color = Color.Lerp(DbgColorPointLast, DbgColorPointFirst, curLerpAmount);
                Gizmos.DrawSphere(curPointLoc, DbgPointRadius);

                if (pointIndex <= 0) continue; // no previous point to draw a line from, skip line drawing
                Gizmos.color = DbgColorLine;
                Gizmos.DrawLine(lastPointLoc, curPointLoc);
                lastPointLoc = curPointLoc; // update for next iteration

            }
        }

    

    }
}