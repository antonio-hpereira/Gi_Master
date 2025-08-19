using Core_Simulator;

namespace API_Loan_Simulator.Core_Simulator.ISimulator
{
    public interface ISimuladorFinanciamento
    {
        ResultadoFinalSimulacao Simular(DadosSimulacao dados);
    }

}
