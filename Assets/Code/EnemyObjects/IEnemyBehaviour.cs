using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public interface IEnemyBehaviour
    {
        #region Interface Methods

        void UpdateSlideColor();
        void DestroyBlastParticleObjects();
        void HealthBarLookatCamera();

        #endregion
    }
}
