using System;
using System.Collections.Generic;

class Menu
{
    static List<Articulo> articulos = new List<Articulo>();
    static Dictionary<int, string> categorias = new Dictionary<int, string>()
    {
        {1, "Comida"},
        {2, "Tegnologia"},
        {3, "Mascotas"},
        {4, "Abarrotes"},
        {5, "Panaderia"}
    };
    static Dictionary<int, string> vendedores = new Dictionary<int, string>()
    {
        {1, "Vendedor1"},
        {2, "Vendedor2"}
    };

    public static void MainMenu()
    {
        char opcion;
        do
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+=============================+");
            Console.WriteLine("|       Menú Principal        |");
            Console.WriteLine("+=============================+");
            Console.WriteLine("| a- Artículos                |");
            Console.WriteLine("| b- Facturación              |");
            Console.WriteLine("| c- Reporte                  |");
            Console.WriteLine("| d- Salir                    |");
            Console.WriteLine("+-----------------------------+\n");
            Console.ResetColor();

            opcion = char.ToLower(Console.ReadKey().KeyChar);

            switch (opcion)
            {
                case 'a':
                    ArticulosMenu();
                    break;
                case 'b':
                    Facturacion();
                    break;
                case 'c':
                    Reporte();
                    break;
                case 'd':
                    Console.WriteLine("Saliendo del sistema...\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpción inválida. \nSelecciona una opción valida.\n");
                    Console.ResetColor();
                    break;
            }
        } while (opcion != 'd');
    }

    static void ArticulosMenu()
    {
        char opcion;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+============================+");
            Console.WriteLine("|       Menú Artículos        |");
            Console.WriteLine("+=============================+");
            Console.WriteLine("| a- Agregar Artículo         |");
            Console.WriteLine("| b- Borrar Artículo          |");
            Console.WriteLine("| c- Consultar Artículo       |");
            Console.WriteLine("| d- Volver al Menú Principal |");
            Console.WriteLine("+-----------------------------+\n");
            Console.ResetColor();


            opcion = char.ToLower(Console.ReadKey().KeyChar);

            switch (opcion)
            {
                case 'a':
                    AgregarArticulo();
                    break;
                case 'b':
                    BorrarArticulo();
                    break;
                case 'c':
                    ConsultarArticulo();
                    break;
                case 'd':
                    Console.WriteLine("\nVolviendo al Menú Principal...\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpción inválida. \nSelecciona una opción valida.\n");
                    Console.ResetColor();
                    break;
            }
        } while (opcion != 'd');
    }

    static void AgregarArticulo()
    {
        if (articulos.Count < 5)
        {
            Console.WriteLine("\nIngrese el código del artículo:\n");
            int codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("\nIngrese el nombre del artículo:\n");
            string nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese el precio del artículo:\n");
            double precio = double.Parse(Console.ReadLine());
            articulos.Add(new Articulo(codigo, nombre, precio));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nArtículo agregado correctamente.\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo se pueden agregar más artículos, la lista está llena.\n");
            Console.ResetColor();
        }
    }

    static void BorrarArticulo()
    {
        Console.WriteLine("\nIngrese el código del artículo a borrar:");
        int codigo = int.Parse(Console.ReadLine());
        Articulo articulo = articulos.Find(a => a.Codigo == codigo);
        if (articulo != null)
        {
            articulos.Remove(articulo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nArtículo borrado correctamente.\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nArtículo no encontrado.\n");
            Console.ResetColor();
        }
    }

    static void ConsultarArticulo()
    {
        Console.WriteLine("\nIngrese el código del artículo a consultar:\n");
        int codigo = int.Parse(Console.ReadLine());
        Articulo articulo = articulos.Find(a => a.Codigo == codigo);
        if (articulo != null)
        {
            Console.WriteLine($"Nombre: {articulo.Nombre}, Precio: {articulo.Precio}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nArtículo no encontrado.\n");
            Console.ResetColor();
        }
    }

    static void Facturacion()
    {
        Console.WriteLine("\nFacturación\n");
        Console.WriteLine("\nIngrese el código del artículo:\n");
        int codigoArticulo = int.Parse(Console.ReadLine());
        Articulo articulo = articulos.Find(a => a.Codigo == codigoArticulo);
        if (articulo != null)
        {
            Console.WriteLine("\nNombre del artículo: " + articulo.Nombre);
            Console.WriteLine("\nPrecio del artículo: " + articulo.Precio);
            Console.WriteLine("\nCategorías existentes:\n");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"{categoria.Key}-{categoria.Value}");
            }
            Console.WriteLine("\nIngrese el código de la categoría:\n");
            int codigoCategoria = int.Parse(Console.ReadLine());
            if (categorias.ContainsKey(codigoCategoria))
            {
                Console.WriteLine("\nCategoría seleccionada: " + categorias[codigoCategoria]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCategoría no válida.\n");
                Console.ResetColor();
            }
            Console.WriteLine("\nIngrese el código del vendedor:\n");
            int codigoVendedor = int.Parse(Console.ReadLine());
            if (vendedores.ContainsKey(codigoVendedor))
            {
                Console.WriteLine("Vendedor: " + vendedores[codigoVendedor]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nVendedor no encontrado.\n");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nArtículo no encontrado.\n");
            Console.ResetColor();
        }
    }

    static void Reporte()
    {
        Console.WriteLine("\nReporte\n");
        Console.WriteLine("\nArtículos ingresados:\n");
        foreach (var articulo in articulos)
        {
            Console.WriteLine($"Código: {articulo.Codigo}, Nombre: {articulo.Nombre}, Precio: {articulo.Precio}");
        }
        Console.WriteLine("Vendedores:");
        foreach (var vendedor in vendedores)
        {
            Console.WriteLine($"Código: {vendedor.Key}, Nombre: {vendedor.Value}");
        }
        Console.WriteLine("Categorías:");
        foreach (var categoria in categorias)
        {
            Console.WriteLine($"Código: {categoria.Key}, Nombre: {categoria.Value}");
        }
    }
}

class Articulo
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Articulo(int codigo, string nombre, double precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }
}

class Categoria
{
    public virtual void Promocion()
    {
        Console.WriteLine("\nDescuentos y promociones\n");
    }

    public void ListadoCategorias()
    {
        Console.WriteLine("\nListado de Categorías\n");
    }

    public bool CategoriaExiste(int codigo)
    {
        return true;
    }
}

class Categoria1 : Categoria
{
    public override void Promocion()
    {
        Console.WriteLine("\nDescuento de 15%\n");
    }
}

class Categoria2 : Categoria
{
    public override void Promocion()
    {
        Console.WriteLine("\nPromoción 2x1\n");
    }
}

class Categoria3 : Categoria
{
    public override void Promocion()
    {
      Console.WriteLine("\nTodo a mitad de precio\n");
    }
}

class Vendedores
{
    static Dictionary<int, string> vendedores = new Dictionary<int, string>()
    {
        {1, "Vendedor1"},
        {2, "Vendedor2"}
    };

    public static void ListadoVendedores()
    {
        Console.WriteLine("\nListado de Vendedores\n");
        foreach (var vendedor in vendedores)
        {
            Console.WriteLine($"Código: {vendedor.Key}, Nombre: {vendedor.Value}");
        }
    }

    public static string BuscarVendedor(int codigo)
    {
        if (vendedores.ContainsKey(codigo))
        {
            return vendedores[codigo];
        }
        else
        {
            return "Vendedor no encontrado.";
        }
    }
}

interface IVendedor1
{
    void VentasContado();
}

interface IVendedor2
{
    string VentasCredito();
}

class Vendedor1 : IVendedor1
{
    public string Nombre { get; }

    public Vendedor1(string nombre)
    {
        Nombre = nombre;
    }

    public void VentasContado()
    {
        Console.WriteLine("\nRealizando ventas al contado...\n");
    }
}

class Vendedor2 : IVendedor2
{
    public string Nombre { get; }

    public Vendedor2(string nombre)
    {
        Nombre = nombre;
    }

    public string VentasCredito()
    {
        return "Realizando ventas a crédito...";
    }
}

    class Interfaces : IVendedor1, IVendedor2
    {
        public void VentasContado()
        {
            Console.WriteLine("\nRealizando ventas al contado...\n");
        }

        public string VentasCredito()
        {
            return "Realizando ventas a crédito...";
        }
    }



class Program
{
    static void Main(string[] args)
    {
        Menu.MainMenu();
    }
}
