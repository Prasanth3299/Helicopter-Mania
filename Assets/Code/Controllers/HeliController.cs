using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    [RequireComponent(typeof(InputController))]
    public class HeliController : BaseRBController
    {
        #region Variables
        [Header("Helicopter Properties")]
        public List<HeliEngine> engines = new List<HeliEngine>();

        [Header("Helicopter Rotors")]
        public HeliRotorController rotorCtrl;

        private InputController input;
        private HeliCharacteristics characteristics;
        private HeliWeaponController weapons;
        #endregion


        #region Built in Methods
        public override void Start()
        {
            base.Start();
            characteristics = GetComponent<HeliCharacteristics>();
            weapons = GetComponentInChildren<HeliWeaponController>();
        }
        #endregion


        #region Custom Methods
        protected override void HandlePhysics()
        {
            input = GetComponent<InputController>();
            if (input)
            {
                HandleEngines();
                HandleRotors();
                HandleCharacteristics();
                HandleWeapons();
            }
        }
        #endregion



        #region Helicopter Control Methods
        protected virtual void HandleEngines()
        {
            for (int i = 0; i < engines.Count; i++)
            {
                engines[i].UpdateEngine(input.StickyThrottle);
            }
        }

        protected virtual void HandleRotors()
        {
            if (rotorCtrl && engines.Count > 0)
            {
                rotorCtrl.UpdateRotors(input, engines[0].CurrentRPM);
            }
        }

        protected virtual void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics(rb, input);
            }
        }

        protected virtual void HandleWeapons()
        {
            if (weapons)
            {
                weapons.UpdateWeapons(input);
            }
        }
        #endregion
    }
}
