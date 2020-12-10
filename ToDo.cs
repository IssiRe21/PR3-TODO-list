using System;

namespace PR3___TODO_list
{
    /// <summary>
    /// Objeto que representa una tarea, incluye una descripción y un booleano que indica si la tarea está pendiente o terminada
    /// </summary>
    class ToDo
    {
        string descripcion { get; set; }
        bool pendiente  { get; set; }

        public ToDo (string descripcion, bool pendiente)
        {
            this.descripcion = descripcion;
            this.pendiente = pendiente;
        }

/// <summary>
/// Regresa unicamente la descripción de la tarea 
/// </summary>
        public string TomarDescrpcion()
        {
            return descripcion;
        }
/// <summary>
/// Regresa unicamente el booleano de la tarea 
/// </summary>
        public bool TomarPendiente()
        {
            return pendiente;
        }
    }
}
