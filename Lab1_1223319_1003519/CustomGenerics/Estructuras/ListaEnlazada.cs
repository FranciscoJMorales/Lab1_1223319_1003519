﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGenerics.Interfaces;
using System.Collections;

namespace CustomGenerics.Estructuras
{
    public class ListaEnlazada<T> : EstructuraDeDatosLineal<T>, IEnumerable<T>
    {
        private Nodo<T> First { get; set; }
        public int Count { get; set; } = 0;

        public void Add(T value)
        {
            Insert(value);
        }

        protected override void Insert(T value)
        {
            if (First == null)
            {
                First = new Nodo<T>
                {
                    Valor = value,
                    Siguiente = null,
                    Anterior = null
                };
            }
            else
            {
                var posicion = First;
                while (posicion.Siguiente != null)
                {
                    posicion = posicion.Siguiente;
                }
                posicion.Siguiente = new Nodo<T>
                {
                    Valor = value,
                    Siguiente = null,
                    Anterior = posicion
                };
            }
            Count++;
        }

        public override void Delete(int position)
        {
            Nodo<T> aux = First;
            try
            {
                for (int i = 0; i < position; i++)
                {
                    aux = aux.Siguiente;
                }
                if (aux == First)
                {
                    First = aux.Siguiente;
                }
                if (aux.Anterior != null)
                {
                    aux.Anterior.Siguiente = aux.Siguiente;
                }
                if (aux.Siguiente != null)
                {
                    aux.Siguiente.Anterior = aux.Anterior;
                }
                Count--;
            }
            catch
            {
            }
        }

        public override T Get(int position)
        {
            Nodo<T> aux = First;
            try
            {
                for (int i = 0; i < position; i++)
                {
                    aux = aux.Siguiente;
                }
                return aux.Valor;
            }
            catch
            {
                return default(T);
            }
            
        }

        public override void Set(T value, int position)
        {
            Nodo<T> aux = First;
            try
            {
                for (int i = 0; i < position; i++)
                {
                    aux = aux.Siguiente;
                }
                aux.Valor = value;
            }
            catch
            {   
            }
        }

        public void Clear()
        {
            First = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> aux = First;
            while (aux != null)
            {
                yield return aux.Valor;
                aux = aux.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
