﻿namespace ApiLocadora.Models
{
    public class Estudio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        public string Distribuidor { get; set; }
    }
}
