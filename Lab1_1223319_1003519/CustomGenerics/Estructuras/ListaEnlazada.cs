using System;
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
        }

        public T Remove()
        {
            var valor = Get();
            Delete();
            return valor;
        }

        protected override void Delete()
        {
            if (First != null)
            {
                First = First.Siguiente;
                if (First != null)
                {
                    First.Anterior = null;
                }
            }
        }

        protected override T Get()
        {
            return First.Valor;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var CopiaLista = this;
            while (CopiaLista.First != null)
            {
                yield return CopiaLista.Remove();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
