//using App01.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Algoritmos
{
    public class AlgoritmoGenerador
    {

        public List<List<int>> Montecarlo(int n, int tamx, int limIn, int limSu)
        {
            List<List<int>> matrizSalida = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                Random random = new Random();
                int escogerColumna = random.Next(0, tamx);
                int guardar = 0;

                List<int> fila = new List<int>();
                for (int j = 0; j < tamx+1; j++)
                {
                    int numeroAleatorio = random.Next(limIn, limSu + 1);
                    
                    if (j == escogerColumna)
                    {
                        guardar = numeroAleatorio;
                    }
                    if (j == tamx)
                    {
                        fila.Add(guardar);
                    }
                    else
                    {
                        fila.Add(numeroAleatorio);
                    }
                }
                matrizSalida.Add(fila);
            }
            return matrizSalida;
        }
    }
}
