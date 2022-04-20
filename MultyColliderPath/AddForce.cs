//@LissaArt

using UnityEngine;


namespace MultyColliderPath
{
    internal class AddForce : MonoBehaviour
    {
        public enum PathOfForce
        {
            forward,
            stopForward,
            
        }

        public PathOfForce pF;
        float dist = 0;

        private void OnTriggerEnter(Collider collision)
        {
            var getf = collision.gameObject.GetComponentInChildren<GetForce>();

            if (getf != null && getf.enabled)
            {
                player = getf;
                dist = d(player.transform.position, transform.position) + 0.1f;
                
            }
        }

        GetForce player;
        int counter = 0;
        private void FixedUpdate()
        {
            if (player != null)
            {
                if (d(player.transform.position, transform.position) < 0.001f) {
                    player.transform.position = new Vector3(transform.position.x,
                                                            player.transform.position.y,
                                                            transform.position.z);
                    player.transform.localRotation = transform.localRotation;
                    player.AddForce(this);

                    player = null;
                    dist = 0;
                }
            }
        }

        float d(Vector3 a, Vector3 b) {

            return (a.x - b.x)*(a.x - b.x) + (a.z - b.z) * (a.z - b.z);
        }
    }
}
