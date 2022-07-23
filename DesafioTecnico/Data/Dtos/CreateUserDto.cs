﻿using System.ComponentModel.DataAnnotations;

namespace DesafioTecnico.Data.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Campo Cpf é obrigatório")]
        [MaxLength(14, ErrorMessage = "Cpf deve estar no formato xxx.xxx.xxx-xx")]
        [MinLength(14, ErrorMessage = "Cpf deve estar no formato xxx.xxx.xxx-xx")]
        public string UserCPF { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string UserNome { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        public string UserTelefone { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        public string UserEmail { get; set; }

        public bool UserAtivo { get; set; }

    }
}
