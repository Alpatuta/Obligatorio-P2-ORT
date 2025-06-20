﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Premium:Cliente
    {
        private int _puntos;

        public Premium(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad) 
            : base(correoElectronico, contrasenia, nombre, documento, nacionalidad) { }

        public Premium() : base() { }
        public int Puntos {  get { return _puntos; } set {  _puntos = value; } }    

        public void Validar()
        {
            base.ValidarCliente();
        }

        public override string ToString()
        {
            return base.ToString() + " - " + _puntos + "\n";
        }

        public override double CostoSegunCliente(double costoBase, Equipaje equipaje)
        {
            if ((int)equipaje == 1)
            {
                costoBase *= 1.05;
            }

            return costoBase;
        }
    } 
}
