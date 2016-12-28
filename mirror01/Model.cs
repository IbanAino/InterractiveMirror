using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mirror01
{
    class Model
    {
        // ATTRIBUTS
        //variables
        private int counter;
        private EmotionApi emotionApi;

        //definition of the delagate
        public delegate void ModelEventEndler(int count);
        public delegate void ModelEventEndler02(string text);
        //definition of the events associated to the delagate
        public event ModelEventEndler counterChanged;
        public event ModelEventEndler02 textChanged;

        //CONSTRUCTOR
        public Model() {

            counter = 0;

            //instanciation of classes
            Button button = new Button();
            WarningLight warningLight = new WarningLight();
            emotionApi = new EmotionApi();


            //subscription of classes to events
            button.buttonPressed += this.OnButtonPressed;
            button.buttonPressed += warningLight.OnButtonPressed;

            //evenement pour vérifier que les infoes transitent bien jusqu'à la mainPage
        }

        //EVENTS LISTENED AND EXECUTED
        private void OnButtonPressed(object source, EventArgs e)
        {
            counter++;
            OnCounterChanged(counter);

            string response = emotionApi.MakeRequest("Charlotte").Result;

            OnTextChanged(response);
        }

        //EVENTS SENDED TO OTHERS CLASSES
        protected virtual void OnCounterChanged(int newCounter)
        {
            counterChanged(newCounter);
        }

        protected virtual void OnTextChanged(string newText)
        {
            textChanged(newText);
        }
    }
}
