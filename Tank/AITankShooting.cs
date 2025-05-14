using UnityEngine;
using UnityEngine.UI;

public class AITankShooting : MonoBehaviour
{    
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;

    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    [SerializeField] private float delay = 2.0f;
    private float lastShot;


    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }
    

    private void Update()
    {
        
    }


    public void Fire()
    {
        if (!(lastShot + delay < Time.time))
        {
            return;
        }
        else
        {
            lastShot = Time.time;
            // Instantiate and launch the shell.
            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
            // Change the clip to the firing clip and play it.
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
            // Reset the launch force. This is a precaution in case of missing button events.
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
    }
}