using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;    
    public GameObject m_ExplosionPrefab;

    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   
    private float m_CurrentHealth;  
    private bool m_Dead;
    public LevelClear enemyCounter;
    [SerializeField] private TankHealth playerHealth;


    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        if (playerHealth != null && VariableManager.Instance.startingHealth < 100.0f)
        {
            VariableManager.Instance.currentHealth = m_CurrentHealth;
            VariableManager.Instance.startingHealth = m_StartingHealth;
        }
        else if (playerHealth != null)
        {
            m_CurrentHealth = VariableManager.Instance.currentHealth;
            m_StartingHealth = VariableManager.Instance.startingHealth;
        }
        m_Dead = false;

        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;
        if (playerHealth != null)
        {
            VariableManager.Instance.currentHealth = m_CurrentHealth;
        }
        //update the UI
        SetHealthUI();
    }

    public void Recover()
    {
        m_CurrentHealth += 50.0f;
        SetHealthUI();
    }

    public void IncreaseMaxHealth()
    {
        float temp = m_StartingHealth;
        m_StartingHealth = m_StartingHealth * 1.3f;
        if (playerHealth != null)
        {
            VariableManager.Instance.startingHealth = m_StartingHealth;
        }
        float topup = m_StartingHealth - temp;
        m_CurrentHealth += topup;
        if (playerHealth != null)
        {
            VariableManager.Instance.currentHealth = m_CurrentHealth;
        }
        SetHealthUI();
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        if (m_CurrentHealth <=0f && !m_Dead)
        {
            OnDeath();
        }
        //set slider value appropriately
        m_Slider.value = m_CurrentHealth;

        //work out UI colour
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        gameObject.SetActive(false);
        enemyCounter.trackEnemiesDefeated();
    }
}