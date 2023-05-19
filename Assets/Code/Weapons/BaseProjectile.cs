using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class BaseProjectile : MonoBehaviour
    {
        #region Variables
        [Header("Base Projectile Properties")]
        public float projectileSpeed = 200;
        public float damagePower = 10f;
        public float timeoutTime = 10f;

        protected Rigidbody rb;
        protected CapsuleCollider col;

        protected float startTime = 0f;
        #endregion




        #region Main Methods
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<CapsuleCollider>();

            //  col.isTrigger = true;

            if (rb)
            {
                startTime = Time.time;
                FireProjectile();
            }
        }

        private void Update()
        {
            if (Time.time >= startTime + timeoutTime)
            {
                DestroyProjectile();
            }
        }
        #endregion





        #region Custom Methods
        public virtual void FireProjectile()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }

        public void DestroyProjectile()
        {
            Destroy(this.gameObject);
        }
        #endregion

        #region Collision Methods
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
            }
           
        }
        #endregion
    }
}
