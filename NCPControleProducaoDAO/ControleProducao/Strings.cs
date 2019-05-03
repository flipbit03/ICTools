using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS.Strings
{
    internal class CPStrings
    {
        public static String sql_hmcadtrabman()
        {
            return @"
            DECLARE @PERIODO AS INT = {0};
            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            maq.matricula EQUIPAMENTO, sum(a.qtdHoraMin)/60.0 HM_TOTAL_TRABALHADO
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (0, 12, 13, 14, 15, 16, 17, 18, 80)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO

            group by maq.matricula
            order by maq.matricula;

            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            sum(a.qtdHoraMin)/60.0 SOMA_HM_TOTAL_TRABALHADO
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (0, 12, 13, 14, 15, 16, 17, 18, 80)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO;

            -------------------------------------------------
            -- HMCADMAN
            -------------------------------------------------
            select
	            maq.matricula EQUIPAMENTO, sum(a.qtdHoraMin)/60.0 HM_TOTAL_MANUT
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (25)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO

            group by maq.matricula
            order by maq.matricula;

            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            sum(a.qtdHoraMin)/60.0 SOMA_HM_TOTAL_MANUT
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (25)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO;";
        }

        public static String sql_listaperiodosapropriacao()
        {
            return @"
                select 
                pkPeriodo, dataInicio, dataFim, dataFechamento, mesReferencia, anoReferencia 
                from PeriodoApropriacao
                order by anoReferencia desc, mesReferencia desc;";
        }

        public static String sql_apropriadosporapontador()
        {
            return @"
                    with EquipeLista 
                    as
                    (
	                    select
		                    e.matricula, e.nome, f.nome funcao, e.fkEquipe, p.fkApontador
	                    from 
		                    Empregado e join Equipe p on e.fkEquipe = p.pkEquipe,
		                    Situacao s,
		                    Funcao f
	                    where
		                    e.fkSituacao = s.pkSituacao
		                    and s.nome = 'Ativo'
		                    and e.fkFuncao = f.pkFuncao

                    )
                    select 
	                    eql.matricula, eql.nome, eql.funcao, e.apelido apontador, eq.nome nome_da_equipe
                    from 
	                    EquipeLista eql,
	                    Equipe eq left join Empregado e on eq.fkApontador = e.pkEmpregado
                    where 
	                    eql.fkEquipe = eq.pkEquipe
	                    and eq.fkApontador in (
			                    -- Apenas apontadores de producao
			                    select e.pkEmpregado from Empregado e, Funcao f
			                    where e.fkFuncao = f.pkFuncao
			                    and f.nome like '%APONT. PRODUCAO%')

                    order by
	                    Apontador, Nome_da_Equipe, eql.matricula;";
        }

        public static String sql_apropriadosporautoapropriador()
        {
            return @"
-- Lista todos os funcionários ""ATIVOS"" que estão em equipes AUTO-APROPRIADAS
-- Autor: Carlos Eduardo Coelho Baptista Shinagawa

select
  e.matricula matricula, e.nome nome, e.apelido, f.nome funcao, 
  e_a.matricula matr_apontador,   e_a.nome apontador,
  e_r.matricula matr_responsavel, e_r.nome responsavel,
  eq.nome nome_da_equipe, eq.descricao descricao_equipe

from 

Empregado e
	join Funcao f on e.fkFuncao = f.pkFuncao
	join Situacao s on e.fkSituacao = s.pkSituacao
	join TipoMaoObra tmo on e.fkTipoMaoObra = tmo.pkTipoMaoObra
	join Equipe eq on e.fkEquipe = eq.pkEquipe
		left join Empregado e_r on eq.fkResponsavel = e_r.pkEmpregado
		left join Empregado e_a on eq.fkApontador   = e_a.pkEmpregado

where

-- Precisa estar numa equipe
e.fkEquipe = eq.pkEquipe and

-- Somente mão de obra ativa
s.nome = 'Ativo' and

-- Remova mão de obra não-apropriada
tmo.codigo <> 2 and

-- Remova apontadores de produção.
eq.fkApontador in (
	-- Apenas não-apontadores de producao (auto apropriados)
	select e.pkEmpregado from Empregado e, Funcao f
		where e.fkFuncao = f.pkFuncao
		and f.nome not like '%APONT. PRODUCAO%')

order by
	Apontador, Nome_da_Equipe, e.matricula;";
        }

    }
}
