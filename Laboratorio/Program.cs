using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio
{
    internal class Program
    {
        static public string[]
        codigos = { "OC-101", "OC-102", "0C-103", "0C-104", "OC-105", "OC-106" };
        static public string[]
        proveedores = { "TechCorp", "LogiExpress", "InsumosGlobal", "TechCorp", "AlfaSuministros", "ServiRedes" };
        static public double[,]
        datos = { { 150.0, 10 }, { 450.0, 2 }, { 80.0, 50 }, { 1200.0, 1 }, { 25.0, 100 }, { 600.0, 3 } };
        static public bool validar_datos(double precio, double cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("El precio y la cantidad no pueden ser menor a 0");
                return false;
            }
        }
        static public double calcular_monto(int i)
        {
            return datos[i, 0] * datos[i, 1];
        }
        //ordenamiento burbuja
        static public void ordenar_burbuja()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    double monto1 = calcular_monto(j);
                    double monto2 = calcular_monto(j + 1);
                    if (monto1 < monto2)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            double temporal = datos[j, k];
                            datos[j, k] = datos[j + 1, k];
                            datos[j, k + 1] = temporal;
                        }
                        string tempCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCodigo;
                        string tempProveedores = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = tempProveedores;
                    }
                }
            }
        }
        static public void buscar_orden(String codigo)
        {
            if (codigo == null)
            {
                Console.WriteLine("Error el código esta vacío");
                return;
            }
            bool encontrado = false;
            for (int i = 0; i < codigo.Length; i++)
            {
                if (codigos[i] == codigo)
                {
                    double monto = calcular_monto(i);
                    Console.WriteLine("ORDEN ENCONTRADA");
                    Console.WriteLine("Código: " + codigo[i]);
                    Console.WriteLine("Proveedor: " + proveedores[i]);
                    Console.WriteLine("Monto: $" + monto);
                    encontrado = true;
                    break;
                }
            }
            if (encontrado == false)
            {
                Console.WriteLine("Codigo no encontrado");
            }
        }
        static void Main(string[] args)
        {
            double gran_total = 0;
            int contador_montos_altos = 0;
            Console.WriteLine("=================================================");
            Console.WriteLine("\t\tCONTROL DE ÓRDENES DE COMPRA");
            Console.WriteLine("=================================================");
            for (int i = 0; i < codigos.Length; i++)
            {
                double precio = datos[i, 0];
                double cantidad = datos[i, 1];
                if (validar_datos(precio, cantidad))
                {
                    double monto = calcular_monto(i);
                    gran_total = gran_total + monto;
                    if (monto > 1000)
                    {
                        contador_montos_altos++;
                    }
                }
            }
            ordenar_burbuja();
            Console.WriteLine("REPORTE ORDENADO POR MONTO NETO (DECRECIENTE)");
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine("Proveedores: " + proveedores[i]);
            }
        }
    }
}
