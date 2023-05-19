using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RevolutionGames
{

    public class BaseEnemyBehaviour : MonoBehaviour,IEnemyBehaviour
    {

        #region Variables

        [Header ("Base Enemy properties")]
        public Camera basicCamera;

        private Image healthBarImage;
        private float healthValue = 1f;
        private GameObject blastParticleEffect;
        private float sliderColorChangeValue = 0.5f;
        private Color32 redColorValue = new Color32(255, 3, 3, 255);
        private Color32 greenColorValue = new Color32(7, 255, 0, 255);
        private float healthReduceValueCannonBullet = 0.1f;
        private float healthReduceValueRocketBullet = 0.15f;
        private float gameobjectsRemainingHealth;
        private float multiplyHealth = 100;
        private Vector3 hitPosition;
        private float startTime = 0f;
        private float timeoutTime = 1.5f;
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            healthBarImage = transform.GetComponentInChildren<Image>();
            healthBarImage.fillAmount = healthValue;
            gameobjectsRemainingHealth = healthValue * multiplyHealth;
            blastParticleEffect = transform.GetChild(0).gameObject;
           
        }
        void Update()
        {
            if (startTime > 0)
            {
                if (Time.time >= startTime + timeoutTime)
                {
                     DestroyBlastParticleObjects(); // Destroy game object
                }
            }
        }
        void FixedUpdate()
        {
            HealthBarLookatCamera(); //Health bar rotation update
        }
        #endregion

        #region Virtual Methods
        protected virtual void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="CannonBullet")
            {
                healthValue -= healthReduceValueCannonBullet;
            }
            else
            {
                healthValue -= healthReduceValueRocketBullet;
            }
            gameobjectsRemainingHealth = healthValue * multiplyHealth;
            hitPosition = collision.transform.position;
            healthBarImage.fillAmount = healthValue;
            if (blastParticleEffect)
            {
                blastParticleEffect.transform.position = hitPosition;
                if (gameobjectsRemainingHealth <= 0)
                {
                    blastParticleEffect.SetActive(true);
                    startTime = Time.time;
                }
            }
            UpdateSlideColor(); // change health bar color
        }

        #endregion

        #region Interface Methods

        public virtual void UpdateSlideColor()
        {
            if (healthValue > sliderColorChangeValue)
            {
                healthBarImage.color = greenColorValue;
            }
            else
            {
                healthBarImage.color = redColorValue;
            }
        }
        public void DestroyBlastParticleObjects()
        {
            Destroy(this.gameObject);
        }

        public void HealthBarLookatCamera()
        {
            healthBarImage.gameObject.transform.LookAt(basicCamera.transform);
        }
        #endregion

    }
}
