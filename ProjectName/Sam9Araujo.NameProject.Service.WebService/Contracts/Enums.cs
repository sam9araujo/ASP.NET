using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sam9araujo.NameProject.Service.WebService.Contracts
{
    public enum GetPointsEnum
    {
        CONSULTA_REALIZADA_COM_SUCESSO = 0,
        ERRO_NA_CONSULTA = 1
    }

    public enum GetCustomerDataEnum
    {
        CONSULTA_REALIZADA_COM_SUCESSO = 0,
        ERRO_NA_CONSULTA = 1
    }

    public enum ValidateOrderEnum
    {
        TRANSACAO_AUTORIZADA_ = 0,
        ERRO_NA_CONSULTA = 1,
        TRANSACAO_NEGADA_SALDO_INSUFICIENTE = 2,
        FALHA_GERAL =3
    }

    public enum FinalizeOrderEnum
    {
        TRANSACAO_AUTORIZADA = 0,
        ERRO_NA_CONSULTA = 1,
        TRANSACAO_NEGADA_SALDO_INSUFICIENTE = 2,
        FALHA_GERAL = 3
    }

    public enum RefundPointsEnum
    {
        PONTOS_EXTORNADOS_COM_SUCESSO = 0,
        ERRO_NA_CONSULTA = 1
    }
}