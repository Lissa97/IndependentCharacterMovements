//@LissaArt
using UnityEngine;

namespace SingleColliderPath
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(Moving))]

    internal class StepSaver: MonoBehaviour, IForceControllerDepend
    {
        PlayerController _PC;

        private void Start()
        {
            _PC = GetComponent<PlayerController>();
        }

        float _timeChangeFC = 0;
        ForceController _FC;

        void IForceControllerDepend.ChangeFC(ForceController newFC)
        {
            _timeChangeFC = Time.time;
            _FC = newFC;
        }

        bool forward = false;
        bool back = false;
        bool right = false;
        bool left = false;

        private void FixedUpdate()
        {
            if (!forward && _PC.ForceForward)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.forward, Time.time - _timeChangeFC);
                forward = true;
            }

            else if (forward && !_PC.ForceForward)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.stopForward, Time.time - _timeChangeFC);
                forward = false;
            }

            if (!back && _PC.ForceBack)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.back, Time.time - _timeChangeFC);
                back = true;
            }
            else if (back && !_PC.ForceBack)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.stopBack, Time.time - _timeChangeFC);
                back= false;
            }

            if (!right && _PC.ForceRight)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.right, Time.time - _timeChangeFC);
                right = true;
            }

            else if (right && !_PC.ForceRight)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.stopRight, Time.time - _timeChangeFC);
                right= false;
            }

            if (!left && _PC.ForceLeft)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.left, Time.time - _timeChangeFC);
                left = true;
            }
            else if (left && !_PC.ForceLeft)
            {
                _FC.AddForceToPath(ForceController.PathOfForce.stopLeft, Time.time - _timeChangeFC);
                left= false;
            }
        }
    }
}
