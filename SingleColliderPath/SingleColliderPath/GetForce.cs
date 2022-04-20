//@LissaArt
using UnityEngine;

namespace SingleColliderPath
{
    [RequireComponent(typeof(Moving))]
    internal class GetForce: MonoBehaviour, IForceControllerDepend
    {
        Moving _move;
        private void Start()
        {
            _move = GetComponent<Moving>();
        }

        public void AddForce(ForceController.Force f)
        {
            switch (f.pF)
            {
                case ForceController.PathOfForce.forward:
                    _move.Forward();
                    break;
                case ForceController.PathOfForce.stopForward:
                    _move.Forward(true);
                    break;
                case ForceController.PathOfForce.back:
                    _move.Back();
                    break;
                case ForceController.PathOfForce.stopBack:
                    _move.Back(true);
                    break;
                case ForceController.PathOfForce.right:
                    _move.Right();
                    break;
                case ForceController.PathOfForce.stopRight:
                    _move.Right(true);
                    break;
                case ForceController.PathOfForce.left:
                    _move.Left();
                    break;
                case ForceController.PathOfForce.stopLeft:
                    _move.Left(true);
                    break;
            }
        }

        float _timeChangeFC = 0;
        ForceController _FC;
        public void ChangeFC(ForceController newFC)
        {
            _timeChangeFC = Time.time;
            _FC = newFC;
        }

        ForceController.Force _currentForce;
        private void FixedUpdate()
        {
            
            while (_currentForce != null && _currentForce.timeMark < Time.time - _timeChangeFC) 
            {
                AddForce(_currentForce);
                _currentForce = _FC.GetNextForceFromPath(_currentForce.timeMark);
            }

            if (_FC != null && _currentForce == null)
            {
                _currentForce = _FC.GetNextForceFromPath(Time.time - _timeChangeFC);
            }
        }
    }
}
