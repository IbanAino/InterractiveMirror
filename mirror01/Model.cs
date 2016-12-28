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

        //definition of the delagate
        public delegate void ModelEventEndler(int count);
        //definition of the events associated to the delagate
        public event ModelEventEndler counterChanged;

        //CONSTRUCTOR
        public Model() {

            counter = 0;

            Button button = new Button();
            WarningLight warningLight = new WarningLight();

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
        }

        //EVENTS SENDED TO OTHERS CLASSES
        protected virtual void OnCounterChanged(int newCounter)
        {
            counterChanged(newCounter);
        }
    }
}
