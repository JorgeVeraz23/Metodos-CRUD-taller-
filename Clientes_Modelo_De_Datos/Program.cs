using System.Collections.Generic;
using Clientes_Modelo_De_Datos.Models;

class Program
{
    static void Main(string[] args)
    {
        //agregarCliente();
        consultarClientes();
        //consultarCliente();
        //modificarCliente();
        //eliminarCliente();
        //consultarClienteFunciones();
    }

    //Agregar cliente
    public static void agregarCliente()
    {
        Console.WriteLine("Metodo agregar cliente");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        Cliente cli = new Cliente();
        cli.Nombre = "Maria";
        cli.Apellido = "Zambrano";
        cli.Direccion = "Guayaquil";
        cli.Telefono = "0986360649";
        cli.FechaNacimiento = Convert.ToDateTime("1996-10-13");
        cli.Estado = "Activo";
        context.Clientes.Add(cli);
        context.SaveChanges();

        Console.WriteLine("Codigo: " + cli.Id + " Nombre: " + cli.Nombre);
    }
    
    //Consulta general
    public static void consultarClientes()
    {
        Console.WriteLine("Consultar cliente");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        List<Cliente> listEstudiantes = context.Clientes.ToList();

        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.Id + " Nombre: " + item.Nombre);
        }
    }
    
    //Consulta por ID
    public static void consultarCliente()
    {
        Console.WriteLine("Consultar cliente por Id");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        Cliente cli = new Cliente();
        cli = context.Clientes.Find(3);

        Console.WriteLine("Codigo: " + cli.Id + " - Nombre: " + cli.Nombre + " - Direccion: " + cli.Direccion + " - Telefono: " + cli.FechaNacimiento + " - Estado: " + cli.Estado);
    }
   
    //Modificar cliente por ID
    public static void modificarCliente()
    {
        Console.WriteLine("Modificar cliente: ");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        Cliente cli = new Cliente();
        cli = context.Clientes.Find(3);

        cli.Nombre = "Anahi";
        context.SaveChanges();
        Console.WriteLine("Codigo: " + cli.Id + " Nombre: " + cli.Nombre);
    }
   
    //Eliminar cliente por ID
    public static void eliminarCliente()
    {
        Console.WriteLine("Metodo eliminar cliente");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        Cliente std = new Cliente();
        std = context.Clientes.Find(1);
        context.Remove(std);
        context.SaveChanges();
        Console.WriteLine("Codigo: " + std.Id + " Nombre: " + std.Nombre);
    }
   

    //Consultar funciones
    public static void consultarClienteFunciones()
    {
        Console.WriteLine("Metodo consultar estudiantes con el uso de funciones");
        ModeloDeDatosContext context = new ModeloDeDatosContext();
        List<Cliente> listEstudiantes;

        Console.WriteLine("Cantidad de registros: " + context.Clientes.Count());
        Cliente std = context.Clientes.First();

        Console.WriteLine("Primer elemento de la tabla:" + std.Id + "-" + std.Nombre);

        listEstudiantes = context.Clientes.Where(s => s.Nombre.StartsWith("A")).ToList();



        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.Id + " Nombre: " + item.Nombre);
        }
    }
   
}



