//@LissaArt
using UnityEngine;


namespace MultyColliderPath
{
    [RequireComponent(typeof(PlayerController))]

    internal class StepSaver : MonoBehaviour
    {
        PlayerController _PC;

        private void Start()
        {
            _PC = GetComponent<PlayerController>();
        }

        public GameObject AddForce;
        public Transform ParentStep;

        bool forward = false;


        private void FixedUpdate()
        {
            if (!forward && _PC.ForceForward)
            {
                CreateStep().GetComponent<AddForce>().pF = MultyColliderPath.AddForce.PathOfForce.forward;
                forward = true;
            }

            else if (forward && !_PC.ForceForward)
            {
                CreateStep().GetComponent<AddForce>().pF = MultyColliderPath.AddForce.PathOfForce.stopForward;
                forward = false;
            }

        }

        GameObject CreateStep()
        {

            return Instantiate(AddForce, transform.position, transform.localRotation, ParentStep);

        }
    }
}
