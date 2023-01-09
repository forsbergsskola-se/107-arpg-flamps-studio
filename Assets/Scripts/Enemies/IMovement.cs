using UnityEngine;

namespace Enemies
{
    public interface IMovement
    {
        // public delegate void NavigationStateChange(bool newIsNavigating);

        // event NavigationStateChange OnNavigationStateChanged;
        public bool IsNavigating { get; }

        // Move toward a destination, return true once within distanceThreshold
        void UpdateDestination(Vector3 destination, float stoppingDistance);
    }
}