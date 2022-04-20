//@LissaArt
using UnityEngine;


namespace MultyColliderPath
{
    [RequireComponent(typeof(Moving))]
    internal class GetForce : MonoBehaviour
    {
        Moving _move;
        private void Start()
        {
            _move = GetComponent<Moving>();
        }

        public void AddForce(AddForce pF)
        {
            switch (pF.pF)
            {
                case MultyColliderPath.AddForce.PathOfForce.forward:
                    _move.Forward();
                    break;
                case MultyColliderPath.AddForce.PathOfForce.stopForward:
                    _move.Forward(true);
                    break;
            }
        }
    }
}
