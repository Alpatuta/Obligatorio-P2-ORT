using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje:IComparable<Pasaje>
    {
        private int _idPasaje;
        private static int s_ultimoId;
        private Vuelo _vuelo;
        private DateTime _fecha;
        private Cliente _pasajero;
        private Equipaje _equipaje;
        private double _precio;
        

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
        {
            _idPasaje = s_ultimoId ++;
            _vuelo = vuelo;
            _fecha = fecha;
            _pasajero = pasajero;
            _equipaje = equipaje;
            _precio = Math.Round(CostoPasaje(), 0);
        }

        public int IdPasaje { get { return _idPasaje; } }

        public Vuelo Vuelo { get { return _vuelo; } }

        public DateTime Fecha { get { return _fecha; } }

        public Cliente Pasajero { get { return _pasajero; } }

        public Equipaje Equipaje { get { return _equipaje; } }

        public double Precio { get { return _precio; } }

        public void ValidarPasaje()
        {
            if (_pasajero == null)
            {
                throw new Exception("El pasaje tiene que tener asigando un pasajero");
            }

            if(_vuelo == null)
            {
                throw new Exception("El pasaje tiene que tener un vuelo asignado");
            }

            if(_fecha == DateTime.MinValue)
            {
                throw new Exception("Ingresar una fecha");
            }

            if(_equipaje != Equipaje.Light && _equipaje != Equipaje.Cabina && _equipaje != Equipaje.Bodega)
            {
                throw new Exception("Ingrese el tipo de equipaje");
            }
            if ((int)_fecha.DayOfWeek != (int)_vuelo.Frecuencia)
            {
                throw new Exception("La fecha del pasaje no coicide con la frecuencia del vuelo");
            }

        }

        public override bool Equals(object? obj)
        {
            bool existe = false;

            if(obj != null && obj is Pasaje)
            {
                Pasaje pasaje = (Pasaje)obj;
                existe = pasaje._idPasaje == _idPasaje;
            }

            return existe;
        }

        public override string ToString()
        {
            return $"{_idPasaje} - {_pasajero.Nombre} - {_precio} - {_fecha} - {_vuelo.NumeroVuelo} \n";
        }

        public double CostoPasaje()
        {
            double costoBase = _vuelo.CalcularPrecioCostoAsiento() * 1.25;

            costoBase = _pasajero.CostoSegunCliente(costoBase, _equipaje) + _vuelo.CostoOperacionSumadoRuta();

            return costoBase;
        }

        public int CompareTo(Pasaje ? other)
        {
            return _fecha.CompareTo(other._fecha);
        }
    }
}
