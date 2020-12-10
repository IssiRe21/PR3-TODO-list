using System;
using System.Collections.Generic;

namespace PR3___TODO_list
{
    /// <summary>
    /// Contiene toda la funcionalidad de el programa
    /// </summary>
    class ToDoList
    {
        
        string pantalla = "";
        /// <summary>
        /// Lista que contiene todas las tareas agregadas, sin importar si estan terminadas o no
        /// </summary>
        List<ToDo> listaTodos = new List<ToDo>();
        /// <summary>
        /// Lista que contiene las tareas agregadas que se encuentran pendientes
        /// </summary>
        List<ToDo> listaPendientes = new List<ToDo>();
        /// <summary>
        /// Lista que contiene las tareas agregadas que se encuentran terminadas
        /// </summary>
        List<ToDo> listaTerminados = new List<ToDo>();

        public string MensajeEnPantalla()
        {
            return this.pantalla;
        }

        /// <summary>
        /// Permite añadir una tarea nueva, la tarea debe estar pendiente para poder añadirla
        /// </summary>
        public void Añadir(ToDo pendiente)
        {
            if(pendiente.TomarPendiente() == false)
            {
                this.listaTodos.Add(pendiente);
                this.pantalla = "Se agrego correctamente";
            }
            else
            {
                this.pantalla = "Error, no se pueden agregar tareas ya terminadas";
            } 
        }

        /// <summary>
        /// Permite borrar una tarea sin importar si esta pendiente o terminada, para poder borrarla se necesita el numero que ocupa en la lista
        /// </summary>
        public void Borrar(int numerodelpendiente)
        {
            if(this.listaTodos.Count >= numerodelpendiente)
            {
                this.listaTodos.RemoveAt(numerodelpendiente-1);
                this.pantalla = "Se borro correctamente";
            }
            else
            { 
                this.pantalla = "Error, verifica que el quehacer que quieres borrar existe";
            }
        }

        /// <summary>
        /// Permite cambiar una tarea pendiente a una tarea terminada, conservando la misma descripción
        /// </summary>
        public void CambiarATerminado(ToDo quehacer)
        {
            if(this.listaTodos.Contains(quehacer))
            {
                this.listaTodos.Remove(quehacer);
                ToDo quehacerTerminado = new ToDo(quehacer.TomarDescrpcion(), true);
                this.listaTodos.Add(quehacerTerminado);
            
                this.pantalla = "La tarea se marco como terminada correctamente";
            }
            else
            { 
                this.pantalla = "Error, verifica que la tarea que quieres marcar como terminada existe";
            }
        }

        /// <summary>
        /// Imprime en la pantalla una de las listas (Todas las tareas, tareas pendientes o tareas terminadas)
        /// </summary>
        public void ImprimirLista(List<ToDo> lista)
        {
            this.pantalla = "";
            
            if(lista.Count == 0)
            {
                this.pantalla = "Error, no hay ninguna tarea";
            }
            else
            {
                foreach (var item in lista)
                {
                    this.pantalla = this.pantalla + item.TomarDescrpcion() + ":"; 
                    if (item.TomarPendiente() == false)
                    {
                        this.pantalla = this.pantalla + " Pendiente. ";
                    } 
                    else
                    {
                        this.pantalla = this.pantalla + " Terminado. ";
                    }
                }
            }
        }
        
        /// <summary>
        /// Llama el metodo para imprimir la lista de todas las tareas
        /// </summary>
        public void ConsultarTodos()
        {
            ImprimirLista(this.listaTodos);
        }
        
        /// <summary>
        /// Llena la lista de tareas pendientes y llama el metodo para imprimir dicha lista
        /// </summary>
        public void ConsultarPendientes()
        {
            this.listaPendientes.Clear();

            foreach (var item in this.listaTodos)
            {
                if(item.TomarPendiente() == false)
                {
                    this.listaPendientes.Add(item);
                }
            }

            ImprimirLista(this.listaPendientes);
        }


        /// <summary>
        /// Llena la lista de tareas terminadas y llama el metodo para imprimir dicha lista 
        /// </summary>
        public void ConsultarTerminadas()
        {
            this.listaTerminados.Clear();

            foreach (var item in this.listaTodos)
            {
                if(item.TomarPendiente() == true)
                {
                    this.listaTerminados.Add(item);
                }
            }

            ImprimirLista(this.listaTerminados);
        }
    }
}