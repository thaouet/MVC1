using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC1
{
    public interface IController
    {
        void incvalue();
    }
    public class Controller : IController
    {
        IView view;
        IModel model;
        // Le contrôleur qui implémente l'interface IController lie la vue et le modèle 
        //ensemble et attache la vue via le IModelInterface et ajoute le gestionnaire de l'événement
        // à la fonction view_changed. La vue lie le contrôleur à lui-même.
      public Controller(IView v, IModel m)
        {
            view = v;
            model = m;
            view.setController(this);
            model.attach((IModelObserver)view);
            view.changed += new ViewHandler<IView>(this.view_changed);
        }
        // événement qui se déclenche à partir de la vue lorsque l'utilisateur change la valeur
        public void view_changed(IView v, ViewEventArgs e)
        {
            model.setvalue(e.value);
        }
        // demander au modele de faire le travail demandé
        public void incvalue()
        {
            model.increment();
        }
    }
}
