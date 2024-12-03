using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyPet.AI
{
    [System.Serializable]
    public class IdleState : State<AnimalController>
    {
        private Animator animator;
        //private CharacterController characterController;
        //private NavMeshAgent agent;
        public override void OnInitialized()
        {
            //����
            animator = context.GetComponent<Animator>(); 
            /*characterController = context.GetComponent<CharacterController>();
            agent = context.GetComponent<NavMeshAgent>(); */
        }
        public override void OnEnter()
        {

        }
        public override void OnExit()
        {

        }

        public override void Update(float deltaTime)
        {

        }
    }
}