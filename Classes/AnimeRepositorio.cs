using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> ListaAnime = new List<Anime>();
        public void Atualiza(int id, Anime objeto)
        {
            ListaAnime[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaAnime[id].Excluir();
        }

        public void Insere(Anime objeto)
        {
            ListaAnime.Add(objeto);
        }

        public List<Anime> Lista()
        {
            return ListaAnime;
        }

        public int ProximoId()
        {
            return ListaAnime.Count;
        }

        public Anime RetornaPorId(int id)
        {
            return ListaAnime[id];
        }
    }
}