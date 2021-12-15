using System;
using System.ComponentModel.DataAnnotations;
using W3.Entities;

namespace Entities
{
    public class Usuario
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(1, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoSexo(ErrorMessage = "Escolha M para Masculino ou F para Feminino")]
        public string sexo { get; set; }

        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoData(ErrorMessage = "Formato de data Inválido")]
        [DataType(DataType.Date)]
        public string dt_nasc { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cpf { get; set; }

    }
}
