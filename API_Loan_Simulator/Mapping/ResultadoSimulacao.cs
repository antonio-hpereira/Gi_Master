
using global::Core_Simulator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Loan_Simulator.Mapping
{
    

    public class ResultadoSimulacaoConfiguration : IEntityTypeConfiguration<ResultadoSimulacao>
    {
        public void Configure(EntityTypeBuilder<ResultadoSimulacao> builder)
        {
            builder.ToTable("ResultadoSimulacao");

            builder.HasKey(rs => rs.ResultadoSimulacaoId);

            builder.Property(rs => rs.NumeroParcela)
                   .IsRequired();

            builder.Property(rs => rs.ValorAmortizacao)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(rs => rs.ValorJuros)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(rs => rs.ValorParcela)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(rs => rs.SaldoDevedor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

        }
    }

}
