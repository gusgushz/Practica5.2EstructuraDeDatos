using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica5._2.Entities
{
    internal class Enlistador
    {
        public List<Palabra> palabrasTodas = new List<Palabra>();
        public List<List<Palabra>> Diccionario = new List<List<Palabra>>();
        private HashSet<Palabra> palabrasAgregadas = new HashSet<Palabra>();

        public void EnlistarPalabra(string palabra)
        {
            Palabra nuevaPalabra = new Palabra(palabra);
            if (!palabrasTodas.Contains(nuevaPalabra) && !string.IsNullOrEmpty(palabra))
            {
                Palabra repetida = palabrasTodas.Find(x => x.p == palabra)!;
                if(repetida == null)
                {
                    palabrasTodas.Add(nuevaPalabra);
                    palabrasTodas = palabrasTodas.OrderBy(x => x.p).ToList();
                }
            }
        }
        public void CrearOrdenarDiccionario(string palabra)
        {
            Palabra nuevaPalabra = new Palabra(palabra);

            if (!string.IsNullOrEmpty(palabra) && !palabrasAgregadas.Contains(nuevaPalabra))
            {
                palabrasAgregadas.Add(nuevaPalabra); // Marcar la palabra como agregada

                string primeraLetra = palabra.Substring(0, 1); // Obtener la primera letra
                char primeraLetraChar = palabra[0];

                bool palabraRepetida = Diccionario
                    .Any(lista => lista.Exists(p => p.p == nuevaPalabra.p));

                if (!palabraRepetida)
                {
                    // Buscar la primera palabra en el diccionario que comienza con la misma letra
                    Palabra primeraPalabraDic = Diccionario
                        .SelectMany(lista => lista)
                        .FirstOrDefault(p => p.p.StartsWith(primeraLetra))!;

                    if (primeraPalabraDic != null)
                    {
                        // Obtener la lista existente
                        List<Palabra> listaExistente = Diccionario.First(lista => lista.Contains(primeraPalabraDic));

                        // Agregar la nueva palabra a la lista existente
                        listaExistente.Add(nuevaPalabra);

                        // Ordenar la lista existente
                        listaExistente.Sort((x, y) => x.p.CompareTo(y.p));
                    }
                    else
                    {
                        // No se encontró ninguna palabra en el diccionario con la misma letra, crea una nueva lista
                        var nuevaLista = new List<Palabra> { nuevaPalabra };
                        Diccionario.Add(nuevaLista);
                    }

                    // Ordenar las listas del diccionario después de cada operación de agregar
                    Diccionario = Diccionario.OrderBy(lista => lista[0].p).ToList();
                }
            }
        }


    }
}