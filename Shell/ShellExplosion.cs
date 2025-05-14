using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;
            // Add an explosion force.
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            // Find the TankHealth script associated with the rigidbody.
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;
            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damage = CalculateDamage(targetRigidbody.position);
            // Deal this damage to the tank.
            targetHealth.TakeDamage(damage);
        }
        // Unparent the particles from the shell.
        m_ExplosionParticles.transform.parent = null;
        // Play the particle system.
        m_ExplosionParticles.Play();
        // Play the explosion sound effect.
        m_ExplosionAudio.Play();
        // Once the particles have finished, destroy the gameobject they are on.
        ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
        Destroy(m_ExplosionParticles.gameObject, mainModule.duration);
        // Destroy the shell.
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        //create vector for shell to target
        Vector3 explosionToTarget = targetPosition - transform.position;
        //calculator distance from shell to target
        float explosionDistance = explosionToTarget.magnitude;
        //Calculator proportion that target is away from the explosion
        float relativeDisrance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        //Calculate damage as a proportion of maximum damage
        float damage = relativeDisrance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}