using UnityEngine;

namespace Enemies
{
    public interface IMovement
    {
        public delegate void NavigationStateChange(bool newIsNavigating);

        event NavigationStateChange OnNavigationStateChanged;

        // Move toward a destination, return true once within distanceThreshold
        void MoveNear(Vector3 destination, float distanceThreshold);
    }
}