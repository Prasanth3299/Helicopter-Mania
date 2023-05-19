using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RevolutionGames
{
    public class HeliRotorController : MonoBehaviour
    {
        #region Variables
        public bool isArcade = false;
        public float maxDps = 3000f;
        private List<IHeliRotor> rotors;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            rotors = GetComponentsInChildren<IHeliRotor>().ToList<IHeliRotor>();
        }
        #endregion

        #region Custom Methods
        public void UpdateRotors(InputController input, float curentRPMs)
        {
            //Debug.Log("Updating Rotor Controller");
            //Degrees per second calculation
            float dps = ((curentRPMs * 360f) / 60f);
            dps = Mathf.Clamp(dps, 0f, maxDps);

            if (isArcade)
            {
                dps = 4000f;
            }


            //Update our Rotors
            if (rotors.Count > 0)
            {
                foreach (var rotor in rotors)
                {
                    rotor.UpdateRotor(dps, input);
                }
            }
        }
        #endregion
    }
}
