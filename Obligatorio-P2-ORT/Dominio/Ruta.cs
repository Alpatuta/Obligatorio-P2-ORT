﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta
    {
        private int _idRuta;
        private static int s_ultimoId = 1;
        private Aeropuerto _aeropuertoSalida;
        private Aeropuerto _aeropuertoLlegada;
        private int _distancia;

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, int distancia)
        {
            _idRuta = s_ultimoId ++;
            _aeropuertoSalida = aeropuertoSalida;
            _aeropuertoLlegada = aeropuertoLlegada;
            _distancia = distancia;
        }

        public void ValidarRuta()
        {
            if(_aeropuertoLlegada == null)
            {
                throw new Exception("Seleccione el aeropuerto de llegada");
            }

            if(_aeropuertoSalida == null)
            {
                throw new Exception("Seleccione el aeropuerto de salida");
            }

            if(_distancia <= 0) 
            {
                throw new Exception("La distancia tiene que ser mayor a cero");
            }
        }

        public override bool Equals(object? obj)
        {
            bool existe = false;

            if (obj != null && obj is Ruta)
            {
                Ruta ruta = (Ruta)obj;
                existe = ruta._idRuta == _idRuta;
            }

            return existe;
        }
    }
}
