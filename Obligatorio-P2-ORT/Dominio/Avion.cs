using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion
    {
        private string _fabricante;
        private string _modelo;
        private int _cantAsientos;
        private int _alcance;
        private double _costoOperacion;

        public Avion(string fabricante, string modelo, int cantAsientos, int alcance, double costoOperacion) 
        { 
            _fabricante = fabricante;
            _modelo = modelo;
            _cantAsientos = cantAsientos;
            _alcance = alcance;
            _costoOperacion = costoOperacion;
        }

        public void ValidarAvion()
        {
            if (string.IsNullOrEmpty(_fabricante))
            {
                throw new Exception("Fabricante no puede ser vacio");
            }

            if (string.IsNullOrEmpty(_modelo)) 
            {
                throw new Exception("Modelo no puede ser vacio");
            }

            if(_cantAsientos <= 0)
            {
                throw new Exception("Cantidad de asientos tiene que ser mayor a cero");
            }

            if(_alcance <= 0)
            {
                throw new Exception("Alcance nunca puede ser cero");
            }

            if(_costoOperacion <= 0)
            {
                throw new Exception("El costo de operacion tiene que ser mayor a cero");
            }
        }
    }
}
