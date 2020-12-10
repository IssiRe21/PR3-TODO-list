using System;
using NUnit.Framework;

namespace PR3___TODO_list
{
    /// <summary>
    /// Clase que se utiliza para llevar a cabo las pruebas
    /// </summary>
    [TestFixture]
    class UnitTests
    {
        /// <summary>
        /// Pone a prueba la funcionalidad de agregar una nueva tarea
        /// </summary>
        [Test]
        [TestCase(TestName = "Agregar un TODO")]
        public void Agregar()
        {
            // agregar un quehacer pendiente
            ToDoList programa = new ToDoList();
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Se agrego correctamente"));

            // agregar un quehacer terminado (No se permite)
            ToDo quehacer2 = new ToDo("Trapear la casa", true);
            programa.Añadir(quehacer2);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no se pueden agregar tareas ya terminadas"));


        }

        /// <summary>
        /// Pone a prueba la funcionalidad de borrar una tarea
        /// </summary>
        [Test]
        [TestCase(TestName = "Borrar un TODO")]
        public void Borrar()
        {
            ToDoList programa = new ToDoList();
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);

            //Borrar un TODO que existe (Está registrado)
            programa.Borrar(1);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Se borro correctamente"));

            //Borrar un TODO que NO existe (No está registrado)
            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.Borrar(2);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, verifica que el quehacer que quieres borrar existe"));
        }

        /// <summary>
        /// Pone a prueba la funcionalidad de marcar como terminada una tarea pendiente
        /// </summary>
        [Test]
        [TestCase(TestName = "Marcar quehacer (TODO) como terminado")]
        public void MarcarComoTerminado()
        {
            ToDoList programa = new ToDoList();
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            
            //Terminar un TODO que existe (Está registrado)
            programa.Añadir(quehacer1);
            programa.CambiarATerminado(quehacer1);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("La tarea se marco como terminada correctamente"));

            //Terminar un TODO que NO existe (No está registrado)
            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.CambiarATerminado(quehacer2);
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, verifica que la tarea que quieres marcar como terminada existe"));

        }

        /// <summary>
        /// Pone a prueba la funcionalidad de consultar todas las tareas
        /// </summary>
        [Test]
        [TestCase(TestName = "Consultar todos los quehaceres")]
        public void ConsultarQuehaceres()
        {
            ToDoList programa = new ToDoList();

            //Consultar pero no hay tareas
            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no hay ninguna tarea"));

            // Consultar una tarea pendiente
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);
            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. "));

            //Consultar dos tareas, ambas pendientes
            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.Añadir(quehacer2);
            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. Trapear la casa: Pendiente. "));

            //Consultar dos tareas, una pendiente y otra terminada
            programa.CambiarATerminado(quehacer2);
            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. Trapear la casa: Terminado. "));
        }

        /// <summary>
        /// Pone a prueba la funcionalidad de consultar las tareas pendientes
        /// </summary>
        [Test]
        [TestCase(TestName = "Consultar los quehaceres pendientes")]
        public void ConsultarTareasPendientes()
        {
            ToDoList programa = new ToDoList();

            //Consultar pero no hay tareas
            programa.ConsultarPendientes();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no hay ninguna tarea"));

            // Consultar pendientes con una tarea pendiente
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);
            programa.ConsultarPendientes();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. "));

            //Consultar dos tareas, ambas pendientes
            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.Añadir(quehacer2);
            programa.ConsultarPendientes();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. Trapear la casa: Pendiente. "));

            //Consultar dos tareas, una pendiente y otra terminada (Solo debe aparecer la pendiente)
            programa.CambiarATerminado(quehacer2);
            programa.ConsultarPendientes();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. "));

        }

        /// <summary>
        /// Pone a prueba la funcionalidad de consultar las tareas terminadas
        /// </summary>
        [Test]
        [TestCase(TestName = "Consultar los quehaceres terminados")]
        public void ConsultarTareasTerminadas()
        {
            ToDoList programa = new ToDoList();

            //Consultar pero no hay tareas
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no hay ninguna tarea"));

            // Consultar pendientes con una tarea pendiente (Debe salir error, por que no hay tareas terminadas)
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no hay ninguna tarea"));

            // Consultar pendientes con una tarea terminada
            programa.CambiarATerminado(quehacer1);
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Terminado. "));

            // Consultar dos tareas, una pendiente y otra terminada (Solo debe aparecer la terminada)
            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.Añadir(quehacer2);
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Terminado. "));

            // Consultar dos tareas, ambas terminadas
            programa.CambiarATerminado(quehacer2);
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Terminado. Trapear la casa: Terminado. "));
        }

        /// <summary>
        /// Utiliza distintas funcionalidades, simulando un uso real del programa
        /// </summary>
        [Test]
        [TestCase(TestName = "Mezcla de opciones")]
        public void Mezcla()
        {
            ToDoList programa = new ToDoList();

            //Consultar pero no hay tareas
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Error, no hay ninguna tarea"));

            // agregar 3 tareas
            ToDo quehacer1 = new ToDo("Barrer la casa", false);
            programa.Añadir(quehacer1);

            ToDo quehacer2 = new ToDo("Trapear la casa", false);
            programa.Añadir(quehacer2);
            
            ToDo quehacer3 = new ToDo("Comprar comida", false);
            programa.Añadir(quehacer3);

            // Consultar todas las tareas

            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Barrer la casa: Pendiente. Trapear la casa: Pendiente. Comprar comida: Pendiente. "));

            // Marcar las primeras 2 como terminadas y Consultar de nuevo
            
            programa.CambiarATerminado(quehacer1);
            programa.CambiarATerminado(quehacer2);
            programa.ConsultarTodos();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Comprar comida: Pendiente. Barrer la casa: Terminado. Trapear la casa: Terminado. "));

            //borrar el  quehacer "barrer la casa" y consultar solo terminadas

            programa.Borrar(2);
            programa.ConsultarTerminadas();
            Assert.That(programa.MensajeEnPantalla(), Is.EqualTo("Trapear la casa: Terminado. "));
        }
    }
}