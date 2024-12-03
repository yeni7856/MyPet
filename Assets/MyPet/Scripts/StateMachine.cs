using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    /// <summary>
    /// <T>���¸� �����ϴ� Ŭ����
    /// </summary>
    [System.Serializable]
    public abstract class State<T>
    {
        protected StateMachine<T> stateMachine;         //�� state�� ��� �Ǿ��մ� Machine
        protected T context;                                            //stateMachine�� ������ �ִ� ��ü

        public State() { }                                  //������

        public void SetMachineAndContext(StateMachine<T> stateMachine, T context)  //context�����ͼ� ����
        {
            this.stateMachine = stateMachine;
            this.context = context;
            OnInitialized();
        }


        public virtual void OnInitialized() { }    //������ 1ȸ ����, �ʱⰪ ���� 
        public virtual void OnEnter() { }           //���� ��ȯ�� ���·� ���ö� 1ȸ ���� 
        public abstract void Update(float deltaTime);      //���� ������   //������Ʈ ������
        public virtual void OnExit() { }                //���� ��ȯ�� ���¸� ������ 1ȸ ����
    }


    /// <summary>
    /// <T>State�� �����ϴ� Ŭ����
    /// </summary>
    public class StateMachine<T>
    {
        private T context;                          //StateMachine�� ������ �ִ� ��ü
        private State<T> currentState;       //�������
        public State<T> CurrentState => currentState;    //�б�����

        public State<T> previousState;    //��������
        public State<T> peviousState => previousState;    //�б�����
        public float elapsedTimeInState = 0.0f;                 //���� ���� ���ӽð�
        public float ElapsedTimeInState => elapsedTimeInState;  

        //��ϵ� ���¸� ������ Ÿ���� Ű������ ����
        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();
        //������ : �Ű����� context
        public StateMachine(T context, State<T> initialState)   //context��ü initialState�ʱ�ȭ
        {
            this.context=context;
            AddState(initialState);
            currentState = initialState;
            currentState.OnEnter();

        }
        //StateMachine�� State ���
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, context);  //OnInitialized �ʱ�ȭ
            states[state.GetType()] = state;                //states ���
        }

        //StateMechine���� State�� ������Ʈ ����
        public void Update(float deltaTime)
        {
            elapsedTimeInState += deltaTime;            //���ӽð�
            currentState.Update(deltaTime);                 //currentState ������Ʈ
        }

        //currentState�� ���� �م�
        public R ChangeState<R>() where R : State<T>                 //R�� T�� ��ӹ޴� ���¸� 
        {
            //�����¿� ���ο� ���� ��
            var newType = typeof(R);
            if(currentState.GetType() == newType)
            {
                return currentState as R;           //�����ϸ� ����
            }

            //���� ��������
            if(currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            //���� ����
            currentState = states[newType];     //���ο�� ��������
            currentState.OnEnter();                 //�����ϰ�
            elapsedTimeInState = 0.0f;          //���º����� �ð��ʱ�ȭ 

            return currentState as R;                    //�ٲ� ���� ����
        }


    }
}
