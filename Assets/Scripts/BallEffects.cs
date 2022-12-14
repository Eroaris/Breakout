using UnityEngine;

public class BallEffects : MonoBehaviour
{
   private Ball myBall;
   private ParticleSystem particleSystem;
   public int particleCount;
   public Explosion explosionPrefab;
   private float delay = 2f;
   private Explosion explosionAnimation;
   private void Awake()
   {
      myBall = GetComponentInParent<Ball>();
      particleSystem = GetComponent<ParticleSystem>();
   }

   private void OnEnable()
   { 
      myBall.PowerupActive += CheckPowerupState;
      myBall.PowerupHit += triggerExplosion;
   }

   private void OnDisable()
   { 
      myBall.PowerupActive -= CheckPowerupState;
      myBall.PowerupHit-= triggerExplosion;
     
   }
   
    
   public void triggerExplosion(Vector2 ballLocation)
   {
      if (CheckPowerupState(true))
      {
         transform.position = myBall.transform.position;
         explosionAnimation = Instantiate(explosionPrefab, ballLocation, Quaternion.identity);
         Destroy(explosionAnimation.gameObject, delay);
      }
   }
   private bool CheckPowerupState(bool isActive)
   {
      if (isActive == true)
      {
         particleSystem.Play();
         return true;
      }

      if (isActive == false)
      {
         particleSystem.Stop();
         return false;
      }
      return default;
   }

      
}