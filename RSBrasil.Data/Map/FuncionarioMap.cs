using Microsoft.EntityFrameworkCore;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RSBrasil.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("funcionario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Ativo)
                .HasColumnName("Ativo");

            builder.Property(c => c.Banco)
                .HasColumnName("banco");

            builder.Property(c => c.Celular)
                .HasColumnName("Celular");

            builder.Property(c => c.DataAdmissao)
                .HasColumnName("dataAdmissao");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.DataLimiteFerias)
                .HasColumnName("DataLimiteFerias");

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento");

            builder.Property(c => c.Deficiencia)
                .HasColumnName("deficiencia");

            builder.Property(c => c.DeficienciaObservacao)
                .HasColumnName("deficienciaObservacao");

            builder.Property(c => c.Escolaridade)
                .HasColumnName("escolaridade");

            builder.Property(c => c.EstadoCivil)
                .HasColumnName("EstadoCivil");

            builder.Property(c => c.FeriasGozadas)
                .HasColumnName("FeriasGozadas");

            builder.Property(c => c.FeriasGozar)
                .HasColumnName("FeriasGozar");

            builder.Property(c => c.IdCargo)
                .HasColumnName("IdCargo");

            builder.Property(c => c.IdEndereco)
                .HasColumnName("IdEndereco");
            
            builder.Property(c => c.IdFuncionarioDocumento)
                .HasColumnName("IdFuncionarioDocumento");

            builder.Property(c => c.IdPerfilAcesso)
                .HasColumnName("IdPerfilAcesso");

            builder.Property(c => c.Login)
                .HasColumnName("Login");

            builder.Property(c => c.Nacionalidade)
                .HasColumnName("nacionalidade");

            builder.Property(c => c.NacionalidadeUF)
                .HasColumnName("nacionalidadeUF");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome");

            builder.Property(c => c.NomeMae)
                .HasColumnName("NomeMae");

            builder.Property(c => c.NomePai)
                .HasColumnName("NomePai");

            builder.Property(c => c.NumeroAgencia)
                .HasColumnName("numeroAgencia");

            builder.Property(c => c.NumeroConta)
                .HasColumnName("numeroConta");

            builder.Property(c => c.RacaCor)
                .HasColumnName("racaCor");

            builder.Property(c => c.Senha)
                .HasColumnName("Senha");

            builder.Property(c => c.Sexo)
                .HasColumnName("sexo");

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone");

            builder.Property(c => c.TipoConta)
                .HasColumnName("tipoConta");

            builder.Property(c => c.UltimoPeriodoFeriasFim)
                .HasColumnName("ultimoPeriodoFeriasFim");

            builder.Property(c => c.UltimoPeriodoFeriasInicio)
                .HasColumnName("ultimoPeriodoFeriasInicio");
        }
    }
}
