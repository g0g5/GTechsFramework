using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.Character
{
    public class Character : MonoBehaviour
    {
        public enum CharacterAnimState
        {
            None = 0,
            Idle,

        }



        public CharacterData data;
        public bool isPlayer { get; private set; }

        private CharacterController m_controller;
        private CharacterController m_playercontrol;
        private Animator m_animator;

        private CharacterAnimState m_state;

        void Awake()
        {
            m_controller = GetComponent<CharacterController>();
            m_animator = GetComponent<Animator>();

            if (m_playercontrol != null ) { isPlayer = true; }

            Instantiate(data.model, transform);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            switch (m_state) 
            {
                case CharacterAnimState.Idle:
                    m_animator.Play("Idle"); 
                    break;
                default:
                    break;
            }
        }
    }
}