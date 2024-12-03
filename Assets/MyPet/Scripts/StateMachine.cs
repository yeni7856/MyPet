using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPet.AI
{
    /// <summary>
    /// <T>상태를 관리하는 클래스
    /// </summary>
    [System.Serializable]
    public abstract class State<T>
    {
        protected StateMachine<T> stateMachine;         //현 state가 등록 되어잇는 Machine
        protected T context;                                            //stateMachine을 가지고 있는 주체

        public State() { }                                  //생성자

        public void SetMachineAndContext(StateMachine<T> stateMachine, T context)  //context가져와서 실행
        {
            this.stateMachine = stateMachine;
            this.context = context;
            OnInitialized();
        }


        public virtual void OnInitialized() { }    //생성후 1회 실행, 초기값 설정 
        public virtual void OnEnter() { }           //상태 전환시 상태로 들어올때 1회 실행 
        public abstract void Update(float deltaTime);      //상태 실행중   //업데이트 돌리기
        public virtual void OnExit() { }                //상태 전환시 상태를 나갈때 1회 실행
    }


    /// <summary>
    /// <T>State를 관리하는 클래스
    /// </summary>
    public class StateMachine<T>
    {
        private T context;                          //StateMachine을 가지고 있는 주체
        private State<T> currentState;       //현재상태
        public State<T> CurrentState => currentState;    //읽기전용

        public State<T> previousState;    //이전상태
        public State<T> peviousState => previousState;    //읽기전용
        public float elapsedTimeInState = 0.0f;                 //현재 상태 지속시간
        public float ElapsedTimeInState => elapsedTimeInState;  

        //등록된 상태를 상태의 타입을 키값으로 저장
        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();
        //생성자 : 매개변수 context
        public StateMachine(T context, State<T> initialState)   //context주체 initialState초기화
        {
            this.context=context;
            AddState(initialState);
            currentState = initialState;
            currentState.OnEnter();

        }
        //StateMachine에 State 등록
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, context);  //OnInitialized 초기화
            states[state.GetType()] = state;                //states 등록
        }

        //StateMechine에서 State의 업데이트 실행
        public void Update(float deltaTime)
        {
            elapsedTimeInState += deltaTime;            //지속시간
            currentState.Update(deltaTime);                 //currentState 업데이트
        }

        //currentState의 상태 바뀍
        public R ChangeState<R>() where R : State<T>                 //R은 T를 상속받는 상태만 
        {
            //현상태와 새로운 상태 비교
            var newType = typeof(R);
            if(currentState.GetType() == newType)
            {
                return currentState as R;           //동일하면 리턴
            }

            //상태 변경이전
            if(currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            //상태 변경
            currentState = states[newType];     //새로운거 가져오고
            currentState.OnEnter();                 //시작하고
            elapsedTimeInState = 0.0f;          //상태변경후 시간초기화 

            return currentState as R;                    //바뀐 상태 리턴
        }


    }
}
