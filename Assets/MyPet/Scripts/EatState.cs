using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    public class EatState : State<AnimalController>
    {
        private Animator animator; 

        public override void OnInitialized()
        {
            //ÂüÁ¶
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
