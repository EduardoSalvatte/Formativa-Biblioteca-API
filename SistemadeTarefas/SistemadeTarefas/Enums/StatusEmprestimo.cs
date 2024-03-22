using System.ComponentModel;

namespace SistemadeTarefas.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Não Pago")]
        NaoPago = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Pago")]
        Pago = 3
    }
}
