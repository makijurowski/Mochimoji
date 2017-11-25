using CnControls;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CnInputManager.GetButtonDown("Jump");
            }
        }

        private void FixedUpdate()
        {
            // Pass all parameters to the character control script.
            bool powerUp = TriggerPowerUpScript.powerUp;
            float PowerSpeed = TriggerPowerUpScript.PowerSpeed;
            float h = CnInputManager.GetAxis("Horizontal");
            bool blink = Input.GetKey(KeyCode.UpArrow);
            m_Character.Move(h, m_Jump, powerUp);
            m_Jump = false;
        }
    }
}