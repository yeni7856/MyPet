using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    public class DrinkState : State<AnimalController>
    {
        private Animator animator;

        //animator parametor
        protected int isDrinkHash = Animator.StringToHash("IsDrink");       //��Ʈ �ؽ������� ��ȯ

        public override void OnInitialized()
        {
            //����
            animator = context.GetComponent<Animator>();
            /*characterController = context.GetComponent<CharacterController>();
            agent = context.GetComponent<NavMeshAgent>(); */
        }
        public override void OnEnter()
        {
            animator.SetBool(isDrinkHash, true);
        }
        public override void OnExit()
        {
            animator.SetBool(isDrinkHash, false);
        }

        public override void Update(float deltaTime)
        {

        }

    }
}
