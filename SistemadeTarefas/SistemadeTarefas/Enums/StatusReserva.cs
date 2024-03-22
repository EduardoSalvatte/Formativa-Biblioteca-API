using System.ComponentModel;

namespace SistemadeTarefas.Enums
{
    public enum StatusReserva
    {
        [Description("Não Reservado")]
        NaoReservado = 1,
        [Description("Reservado")]
        Reservado = 2
    }
}
