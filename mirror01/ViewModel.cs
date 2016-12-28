using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mirror01
{
    class ViewModel
    {
        //ATTRIBUTES
        private Model model;

        //definition of the delagate
        public delegate void ViewModelEventEndler(string e);
        //definition of the event associated to the delagate
        public event ViewModelEventEndler textChanged;
        public event ViewModelEventEndler text02Changed;

        //CONSTRUCTOR
        public ViewModel(Model model)
        {
            this.model = model;

            //subscription of classes to events
            model.counterChanged += this.OnCounterChanged;
            model.textChanged += this.OnTextBlock02Changed;
        }

        //METHODS

        //EVENTS LISTENED ANS EXECUTED
        private void OnCounterChanged(int newCounter)
        {
            OnTextBlockChanged(newCounter);
        }

        //EVENTS SENDED TO OTHER CLASSES
        protected virtual void OnTextBlockChanged(int newCount)
        {
            string text = newCount.ToString();
            textChanged(text);
        }

        protected virtual void OnTextBlock02Changed(string newText)
        {
            text02Changed(newText);
        }

    }
}
