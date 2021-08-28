using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica_II.Pages
{
    public class NominaModel : PageModel
    {
        public List<Empleados> listaEmpleados;

        //listado de empleados
        public NominaModel()
        {
            listaEmpleados = new List<Empleados>();

            listaEmpleados.Add(new Empleados { Nombre = "Michael", Apellido = "Scott", Cargo = "Gerente Regional", Salario = 60000.00 });
            listaEmpleados.Add(new Empleados { Nombre = "Jim", Apellido = "Halpert", Cargo = "Representante de Ventas", Salario = 37000.00 });
            listaEmpleados.Add(new Empleados { Nombre = "Dwight", Apellido = "Schrute", Cargo = "Representante de Ventas", Salario = 37000.00 });
            listaEmpleados.Add(new Empleados { Nombre = "Pam", Apellido = "Beesly", Cargo = "Recepcion", Salario = 33500.00 });
            listaEmpleados.Add(new Empleados { Nombre = "Toby", Apellido = "Flenderson", Cargo = "Recursos Humanos", Salario = 40000.00 });

        }
        
        public void OnGet()
        {
        }

    }
    public class Descuentos
    {
        public Empleados desc = new Empleados();

        public double descAFP(double salario)
        {
            return salario * desc.Afp;
        }
        public double descARS(double salario)
        {
            return salario * desc.Ars;
        }
        public double calcularISR(double salario)
        {
            double isrAnual;
            double isrMensual;
            double descuentoSalario = salario - descAFP(salario) - descARS(salario);
            double salarioAnual = descuentoSalario * 12;
            if (salarioAnual <= 416220)
            {
                isrMensual = 0;
                return Math.Round(isrMensual,2);
            }
            else if (salarioAnual >= 416220.01 && salarioAnual <= 624329.00)
            {
                isrAnual= (salarioAnual - 416220.01) * 0.15;
                isrMensual = isrAnual / 12;

                return Math.Round(isrMensual, 2);
            }
            else if(salarioAnual >= 624329.01 && salarioAnual <= 867123.00)
            {
                isrAnual = (salarioAnual - 624329.01) * 0.20;
                isrAnual += 31216.00;
                isrMensual = isrAnual / 12;

                return Math.Round(isrMensual, 2);
            }
            else if(salarioAnual >= 867123.01)
            {
                isrAnual = (salarioAnual - 867123.01) * 0.25;
                isrAnual += 79776.00;
                isrMensual = isrAnual / 12;

                return Math.Round(isrMensual, 2);
            }
            return 0;
        }
        public double descuentoTotal(double salario)
        {
            double resultado = Math.Round(descAFP(salario) + descARS(salario) + calcularISR(salario), 2);
            return resultado;
        }
    }

    public class Empleados
    {
        private double _afp = 0.0287;
        private double _ars = 0.0304;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public double Afp { get { return _afp; } set { _afp = value; } }
        public double Ars { get { return _ars; } set { _ars = value; } }

    }
}
