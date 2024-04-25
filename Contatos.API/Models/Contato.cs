﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contatos.API.Dto;
using Dapper.Contrib.Extensions;

namespace Contatos.API.Models
{
    [Table("Contatos")]
    public record Contato
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O contato deve ser vinculado à uma região")]
        public required int IdRegiao { get; set; }

        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public required string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public required string Email { get; set; }
       
        [Write(false)]
        public Regiao? Regiao { get; set; }

        public static implicit operator ContatoDto (Contato contato)
        {
            var contatoDto = new ContatoDto()
            {
                Id = contato.Id,
                Nome = contato.Nome,
                IdRegiao = contato.IdRegiao,
                Telefone = contato.Telefone,
                Email = contato.Email,
                Regiao = contato.Regiao
            };

            return contatoDto;
        }
    }
}
