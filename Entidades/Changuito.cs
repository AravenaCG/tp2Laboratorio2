﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> _productos;
        private int _espacioDisponible;

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        public Changuito()
        {
            this._productos = new List<Producto>();
            _productos.Capacity= _espacioDisponible;
        }
        public Changuito(int espacioDisponible):this()
        { 
            this._espacioDisponible = espacioDisponible;
            _productos.Capacity = _espacioDisponible;
         //   this._productos = new List<Producto>(espacioDisponible);
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public  string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Dulce:
                        for (int i = 0; i < c._productos.Count; i++)
                        {
                            if (c._productos[i] is Dulce)
                            {
                                sb.AppendLine(v.Mostrar());
                                Console.Clear();
                            }
                        }
                        
                        break;
                    case ETipo.Leche:
                        sb.AppendLine(v.Mostrar());
                        Console.Clear();
                        break;
                    case ETipo.Snacks:
                        sb.AppendLine(v.Mostrar());
                        Console.Clear();
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        Console.Clear();
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
          
            bool existe = false;
            foreach (Producto v in c._productos)
            {
                
                if (v == p)
                {
                    existe = true;
                    break;
                }
            }
                if(existe == false)
                {
                    if (c._productos.Count <= c._productos.Capacity)
                    {
                        c._productos.Add(p);
                    }
                }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    break;
                }
            }
            c._productos.Remove(p);
            return c;
        }
        #endregion
    }
}