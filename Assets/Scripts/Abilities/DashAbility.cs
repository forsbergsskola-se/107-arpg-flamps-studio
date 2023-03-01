using System.Collections;
using UnityEngine;

namespace Abilities
{
    public class DashAbility : MonoBehaviour
    {
        public float dashDistance = 5f;
        public float dashSpeed = 10f;
        public float dashDelay = 1f;
        private bool dashing = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !dashing)
            {
                dashing = true;
                StartCoroutine(PerformDash());
            }
        }

        IEnumerator PerformDash()
        {
            Vector3 startPos =  transform.position;
            Vector3 endPos = startPos + transform.forward * dashDistance;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * dashSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }
            dashing = false;
            yield return new WaitForSeconds(dashDelay);
        }
    }
}

