﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario
    {
        private string _correoElectronico;
        private string _contrasenia;
        

        public Usuario(string correoElectronico, string contrasenia)
        {
            _correoElectronico = correoElectronico;
            _contrasenia = contrasenia;
        }

        public Usuario() { }

        public string Mail { get {  return _correoElectronico; } set { _correoElectronico = value; } }

        public void ValidarUsuario()
        {
            if (!TieneArroba(_correoElectronico))
            {
                throw new Exception("El correo electronico debe contener un arroba");
            }
            if (_contrasenia.Length < 8)
            {
                throw new Exception("La contraseña debe tener como mínimo 8 caracteres");
            }
        }

        private bool TieneArroba(string mail)
        {
            bool tiene = false;
            int i = 0;

            while (i < mail.Length && tiene == false)
            {
                if (mail[i] == '@')
                {
                    tiene = true;
                }

                i++;
            }

            return tiene;
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;

            if (obj != null && obj is Usuario) 
            { 
                Usuario usuario = (Usuario)obj;
                sonIguales = _correoElectronico ==  usuario._correoElectronico;
            }

            return sonIguales;
        }

        public override string ToString()
        {
            return $"{_correoElectronico} - ";
        }
    }
}
