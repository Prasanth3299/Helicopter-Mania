using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public interface IHeliRotor
    {
        #region Methods
        void UpdateRotor(float dps, InputController input);
        #endregion  
    }
}
