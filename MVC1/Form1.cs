using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC1
{
    public partial class Form1 : Form, IView, IModelObserver
    {

        IController controller;

        public event ViewHandler<IView> changed;


        // View will set the associated controller, this is how view is linked to the controller.
        public void setController(IController cont)
        {
            controller = cont;
        }

        public Form1()
        {
            InitializeComponent();
        }

        // when the user clicks the button just ask the controller to increment the value
        // do not worry about how and where it is done
        private void button1_Click(object sender, EventArgs e)
        {
            controller.incvalue();
        }

        // This event is implementation from IModelObserver which will be invoked by the
        // Model when there is a change in the value with ModelEventArgs which is derived
        // from the EventArgs. The IModel object is the one from which invoked this.
        public void valueIncremented(IModel m, ModelEventArgs e)
        {
            textBox1.Text = "" + e.newval;
        }

        // When this event is raised can mean the user must have changed the value.
        // Invoke the view changed event in the controller which will call the method
        // in IModel to set the new value, the user can enter a new value and the
        // incrementing starts from that value onwards
        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                changed.Invoke(this, new ViewEventArgs(int.Parse(textBox1.Text)));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number");
            }

        }

       


    }

}
