//@LissaArt
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;


namespace SingleColliderPath
{
    public class ForceController: MonoBehaviour
    {

        public enum PathOfForce
        {
            forward,
            stopForward,
            back,
            stopBack,
            right,
            stopRight,
            left,
            stopLeft
        }

        [System.Serializable]
        public class Force
        {
            public PathOfForce pF;
            public float timeMark;

            public Force() {
                this.pF = PathOfForce.forward;
                this.timeMark = 0;
            }
            public Force(PathOfForce pF, float timeMark)
            {
                this.pF = pF;
                this.timeMark = timeMark;
            }
        }

        public List<Force> path = new List<Force>();

        public void AddForceToPath(PathOfForce pF, float timeMark)
        {
            path.Add(new Force(pF, timeMark));

            Debug.Log(pF.ToString() + timeMark.ToString());
        }

        public Force GetNextForceFromPath(float timeMark) 
        {
            var newPath = path.Where(f => f.timeMark >= timeMark).ToList<Force>();
             
            if (newPath.Count() > 0) {
                var elem = newPath[0];

                newPath.RemoveAt(0);
                path = newPath;

                return elem;
            }
                

            return null;
        }

        private void OnTriggerEnter(Collider other)
        {
            var iF = other.gameObject.GetComponents<IForceControllerDepend>();

            foreach(var fcd in iF)
            {
                fcd.ChangeFC(this);
 
            }
        }
    }
}
