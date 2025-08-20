using API_Loan_Simulator.Entities.ViewModel;

namespace API_Loan_Simulator.Core_Simulator.ISimulator
{
    public interface ISimuladorFinanciamento
    {
        ResultadoFinalSimulacaoViewModel Simular(DadosSimulacao dados);
    }

}
