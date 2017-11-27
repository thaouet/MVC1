using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC1
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            // Create the View, Model and Controller object yourself and comment out the Application.Run with a new form
            // Create a controller object with the concreate implementation IncController and pass the view and model.
            // Controller will store its associated model and view inside the constructor
            // View which is inside the form will tie the controller automatically who was associated in this step
            // Run the view object created by you which is infact the form
            Form1 view = new Form1();
            IModel mdl = new IncModel();
            IController cnt = new Controller(view, mdl);
            Application.Run(view);


        }
    }
}
