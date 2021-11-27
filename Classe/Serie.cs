using System;
using Series.Enum;

namespace Series.Classe
{
    public class Serie : EntidadeBase
    {
         //Atributos

        private Genero genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        public bool Excluido { get; private set; }


        //Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            retorno += "Excluido: " + this.Excluido;


            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
