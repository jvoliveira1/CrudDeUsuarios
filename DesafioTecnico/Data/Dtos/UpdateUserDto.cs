using System.ComponentModel.DataAnnotations;

namespace DesafioTecnico.Data.Dtos
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string UserNome { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        public string UserTelefone { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        public string UserEmail { get; set; }

        public bool UserAtivo { get; set; }


    }
}
