﻿namespace curso.api2.Business.Entidades
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodigoUsuario { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}
