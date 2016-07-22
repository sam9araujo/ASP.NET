﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public static class QuerysSQL
    {
        //***********************************************************************************************************************************
        //SELECT                          
        //***********************************************************************************************************************************
        public const string selectAmbiente = "SELECT AMBIENTE.idAmbiente, AMBIENTE.descricao, AMBIENTE.dataCadastro, AMBIENTE.mostra, AMBIENTE.imagemGrd, AMBIENTE.imagemPeq, AMBIENTE.cssClassStyle,AMBIENTE.imagemBanner FROM AMBIENTE";
        public const string selectAtributo = "SELECT idAtributo, atributo, descricao, isDisponivel, dataCadastro, idProduto, idParceiro FROM ATRIBUTO";
        public const string selectCategoria = "SELECT CATEGORIA.idCategoria,CATEGORIA.idParceiro,CATEGORIA.descricao,CATEGORIA.dataCadastro,CATEGORIA.mostra,CATEGORIA.idPaiCategoria FROM CATEGORIA";
        public const string selectImagem = "SELECT idImagem, imagem, dataCadastro, idProduto, idParceiro FROM IMAGEM";
        public const string selectItemPedido = "SELECT idPedido,idParceiro,idItem,precoUnitario,quantidade,nomeProduto,valorRebate,nivel,pontos FROM ITEM_PEDIDO";
        public const string selectNewsletter = "SELECT idParceiro,nome,dataCadastro,percentualPreco,percentualPontos FROM newsletter";
        public const string selectOrderPointsTemp = "SELECT idPedido, idParceiro, idOrderPoints, dataHora FROM ORDERPOINTSTEMP";
        public const string selectParceiro = "SELECT PARCEIRO.idParceiro, PARCEIRO.nome, PARCEIRO.dataCadastro, PARCEIRO.percentualPreco, PARCEIRO.percentualPontos, PARCEIRO.imagem, PARCEIRO.link FROM PARCEIRO";
        public const string selectPedido = "SELECT idPedido,idParceiro,data,status,nome,formaPagamento,endereco,bairro,cidade,uf,cep,cpfCnpj,frete FROM PEDIDO";
        public const string selectProduto = "SELECT PRODUTO.idProduto, PRODUTO.idParceiro, PRODUTO.link, PRODUTO.precoCheio, PRODUTO.preco, PRODUTO.imagem, PRODUTO.pontos, PRODUTO.isDisponivel, PRODUTO.IsAtivo, PRODUTO.dataCadastro, PRODUTO.dataAlteracao, PRODUTO.usuario, PRODUTO.nome, PRODUTO.nivel, PRODUTO.ordemDestaque, PRODUTO.titulo, PRODUTO.descricao, PRODUTO.observacao, PRODUTO.frete, PRODUTO.idCategoria, PRODUTO.totalUpdate FROM PRODUTO";
        public const string selectRebate = "SELECT idProduto,idParceiro,data,valor FROM REBATE";
        public const string selectTracking = "SELECT idPedido,idParceiro,idTracking,status,data FROM TRACKING";
        public const string selectUsuario = "SELECT idUsuario, nome, email, login, senha, isAtivo, dataCadastro FROM USUARIO";

        //***********************************************************************************************************************************
        //INSERT
        //***********************************************************************************************************************************
        public const string insertAmbiente = "INSERT INTO AMBIENTE (idAmbiente, descricao, dataCadastro, mostra, imagemGrd, imagemPeq, cssClassStyle, imagemBanner) " +
                                              "VALUES (@idAmbiente, @descricao, @dataCadastro, @mostra, @imagem, @cssClassStyle, @imagemBanner)";

        public const string insertAtributo  = "INSERT INTO ATRIBUTO (atributo, descricao, isDisponivel, dataCadastro, idProduto, idParceiro)" +
                                              "VALUES (@atributo, @descricao, @isDisponivel, @dataCadastro, @idProduto, @idParceiro)";

        public const string insertCategoria = "INSERT INTO CATEGORIA (idCategoria,idParceiro,descricao,dataCadastro,mostra,idPaiCategoria) " +
                                              "VALUES(@idCategoria,@idParceiro,@descricao,@dataCadastro,@mostra,@idPaiCategoria)";

        public const string insertImagem    = "INSERT INTO IMAGEM (imagem, dataCadastro, idProduto, idParceiro)" +
                                              "VALUES (@imagem, @dataCadastro, @idProduto, @idParceiro)";

        public const string insertItemPedido = "INSERT INTO ITEM_PEDIDO (idPedido,idParceiro,idItem,precoUnitario,quantidade,nomeProduto,valorRebate,nivel,pontos)" +
                                               "VALUES (@idPedido,@idParceiro,@idItem,@precoUnitario,@quantidade,@nomeProduto,@valorRebate,@nivel,@pontos) ";

        public const string insertNewsletter = "INSERT INTO NEWSLETTER (idParceiro,nome,dataCadastro,percentualPreco,percentualPontos)" +
                                               "VALUES (@idParceiro,@nome,@dataCadastro,@percentualPreco,@percentualPontos)";

        public const string insertOrderPointsTemp = "INSERT INTO ORDERPOINTSTEMP (idPedido ,idParceiro, idOrderPoints ,dataHora)" +
                                                    "VALUES(@idPedido ,@idParceiro, @idOrderPoints ,@dataHora)";

        public const string insertParceiro = "INSERT INTO PARCEIRO (id, nome, dataCadastro, percentualPreco, percentualPontos, imagem, link)" +
                                             "VALUES(@id, @nome, @dataCadastro, @percentualPreco, @percentualPontos, @link)";

        public const string insertPedido = "INSERT INTO PEDIDO (idPedido,idParceiro,data,status,nome,formaPagamento,endereco,bairro,cidade,uf,cep,cpfCnpj,frete)" +
                                           "VALUES(@idPedido,@idParceiro,@data,@status,@nome,@formaPagamento,@endereco,@bairro,@cidade,@uf,@cep,@cpfCnpj,@frete)";

        public const string insertProduto   = "INSERT INTO PRODUTO (idProduto, idParceiro, link, precoCheio, preco, imagem, pontos, isDisponivel, IsAtivo, dataCadastro, dataAlteracao, usuario, nome, nivel, ordemDestaque, titulo, descricao, observacao, frete, idCategoria, totalUpdate)" +
                                              "VALUES(@idProduto, @idParceiro, @link, @precoCheio, @preco, @imagem, @pontos, @isDisponivel, @IsAtivo, @dataCadastro, @dataAlteracao, @usuario, @nome, @nivel, @ordemDestaque, @titulo, @descricao, @observacao, @frete, @idCategoria, @totalUpdate)";

        public const string insertRebate = "INSERT INTO REBATE (idProduto,idParceiro,data,valor)" +
                                            "VALUES (@idProduto,@idParceiro,@data,@valor)";

        public const string insertTracking = "INSERT INTO TRACKING (idPedido,idParceiro,idTracking,status,data) " +
                                             "VALUES (@idPedido,@idParceiro,@idTracking,@status,@data)";

        public const string insertUsuario = "INSERT INTO USUARIO (nome, email, login, senha, isAtivo, dataCadastro) " +
                                             "VALUES (@nome,@email,@login,@senha,@isAtivo, @dataCadastro)";

        //***********************************************************************************************************************************
        //UPDATE
        //***********************************************************************************************************************************
        public const string updateAmbiente = "UPDATE AMBIENTE                                " +
                                             "SET idAmbiente = @idAmbiente                   " +
                                             "    ,descricao = @descricao                    " +
                                             "    ,dataCadastro = @dataCadastro              " +
                                             "    ,mostra = @mostra                          " +
                                             "    ,imagemGrd = @imagemGrd                    " +
                                             "    ,imagemPeq = @imagemPeq                    " +
                                             "    ,cssClassStyle = @cssClassStyle            " +
                                             "    ,imagemBanner = @ImagemBanner              ";

        public const string updateAtributo = "UPDATE ATRIBUTO                               " +
                                             "SET atributo = @atributo                         " +
                                             ",descricao = @descricao                       " +
                                             ",isDisponivel = @isDisponivel                 " +
                                             ",dataCadastro = @dataCadastro                 " +
                                             ",idProduto = @idProduto                       " +
                                             ",idParceiro = @idParceiro                     ";


        public const string updateCategoria = "UPDATE CATEGORIA                             " +
                                              "SET idCategoria = @idCategoria               " +
                                              ",idParceiro = @idParceiro                    " +
                                              ",descricao = @descricao                      " +
                                              ",dataCadastro = @dataCadastro                " +
                                              ",mostra = @mostra                            " +
                                              ",idPaiCategoria = @idPaiCategoria            ";


        public const string updateImagem = "UPDATE IMAGEM                                   " +
                                           "SET imagem = @imagem                               " +
                                           ",dataCadastro = @dataCadastro                   " +
                                           ",idProduto = @idProduto                         " +
                                           ",idParceiro = @idParceiro                       ";


        public const string updateItemPedido = "UPDATE ITEM_PEDIDO                          " +
                                               "SET idPedido = @idPedido                    " +
                                               ",idParceiro = @idParceiro                   " +
                                               ",idItem = @idItem                           " +
                                               ",precoUnitario = @precoUnitario             " +
                                               ",quantidade = @quantidade                   " +
                                               ",nomeProduto = @nomeProduto                 " +
                                               ",valorRebate = @valorRebate                 " +
                                               ",nivel = @nivel                             " +
                                               ",pontos = @pontos                           ";

        
        public const string updateNewsletter = "UPDATE NEWSLETTER                          " +
                                               "SET email = @email                         " +
                                               ",data = @data                              ";


        public const string updateOrderPointsTemp = "UPDATE ORDERPOINTSTEMP                " +
                                              "SET idPedido = @idPedido                    " +
                                              ",idParceiro = @idParceiro                   " +
                                              ",idOrder = @idOrder                         " +
                                              ",Points = @Points                           " +
                                              ",dataHora = @dataHora                       ";


        public const string updateParceiro = "UPDATE PARCEIRO                              " +
                                             "SET idParceiro = @idParceiro                 " +
                                             "nome = @nome                                 " +
                                             ",dataCadastro = @dataCadastro                " +
                                             ",percentualPreco = @percentualPreco          " +
                                             ",percentualPontos = @percentualPontos        " +
                                             ",imagem = @imagem                            " +
                                             ",link = @link                                ";

        
        public const string updatePedido = "UPDATE PEDIDO                                  " +
                                           "SET idPedido = @idPedido                       " +
                                           ",idParceiro = @idParceiro                      " +
                                           ",data = @data                                  " +
                                           ",[status] = @status                            " +
                                           ",[nome] = @nome                                " +
                                           ",[formaPagamento] = @formaPagamento            " +
                                           ",[endereco] = @endereco                        " +
                                           ",[bairro] = @bairro                            " +
                                           ",[cidade] = @cidade                            " +
                                           ",[uf] = @uf                                    " +
                                           ",[cep] = @cep                                  " +
                                           ",[cpfCnpj] = @cpfCnpj                          " +
                                           ",[frete] = @frete                              ";


        public const string updateProduto   = "UPDATE PRODUTO                          " +
                                              "   SET idProduto		= @idProduto	   " +
                                              "      ,idParceiro	= @idParceiro	   " +
                                              "      ,link			= @link			   " +
                                              "      ,precoCheio	= @precoCheio	   " +
                                              "      ,preco			= @preco		   " +
                                              "      ,imagem		= @imagem		   " +
                                              "      ,pontos		= @pontos		   " +
                                              "      ,isDisponivel 	= @isDisponivel    " +
                                              "      ,isAtivo		= @isAtivo		   " +
                                              "      ,dataCadastro	= @dataCadastro	   " +
                                              "      ,dataAlteracao	= @dataAlteracao   " +
                                              "      ,usuario		= @usuario		   " +
                                              "      ,nome			= @nome			   " +
                                              "      ,nivel			= @nivel		   " +
                                              "      ,ordemDestaque	= @ordemDestaque   " +
                                              "      ,titulo		= @titulo		   " +
                                              "      ,descricao		= @descricao	   " +
                                              "      ,observacao	= @observacao	   " +
                                              "      ,frete			= @frete		   " +
                                              "      ,idCategoria	= @idCategoria	   " +
                                              "      ,totalUpdate	= @totalUpdate	   ";


        public const string updateRebate = "UPDATE REBATE                              " +
                                           "SET idProduto = @idProduto                 " +
                                           " ,idParceiro = @idParceiro                  " +
                                           " ,data = @data                              " +
                                           " ,valor = @valor                            ";


        public const string updateTracking = "UPDATE TRACKING                          " +
                                             "SET idPedido = @idPedido                 " +
                                             ",idParceiro = @idParceiro                " +
                                             ",idTracking = @idTracking                " +
                                             ",status = @status                        " +
                                             ",data = @data                            ";

        public const string updateUsuario = "UPDATE Usuario                            " +
                                             "SET nome = @nome                         " +
                                             ",email = @email                          " +
                                             ",login = @login                          " +
                                             ",senha = @senha                          " +
                                             ",isAtivo = @isAtivo                      " +
                                             ",dataCadastro = @dataCadastro            ";

        //***********************************************************************************************************************************
        //DELETE
        //***********************************************************************************************************************************
        public const string deleteAmbiente = "DELETE FROM AMBIENTE";
        public const string deleteAtributo = "DELETE FROM ATRIBUTO";
        public const string deleteCategoria = "DELETE FROM CATEGORIA";
        public const string deleteParceiro = "DELETE FROM PARCEIRO";
        public const string deleteImagem = "DELETE FROM IMAGEM";
        public const string deleteItemPedido = "DELETE FROM ITEMPEDIDO";
        public const string deleteNewsletter = "DELETE FROM NEWSLETTER";
        public const string deleteOrderPointsTemp = "DELETE FROM ORDERPOINTSTEMP";
        public const string deletePedido = "DELETE FROM PEDIDO";
        public const string deleteProduto = "DELETE PRODUTO";
        public const string deleteRebate = "DELETE FROM REBATE";
        public const string deleteTracking = "DELETE FROM TRACKING";
        public const string deleteUsuario = "DELETE FROM USUARIO";

        //***********************************************************************************************************************************
        //KEY LIST
        //***********************************************************************************************************************************
        public static readonly IList<string> keyAmbiente = new List<string>() { "idAmbiente" };
        public static readonly IList<string> keyAtributo = new List<string>() { "idAtributo" };
        public static readonly IList<string> keyCategoria = new List<string>() { "idCategoria", "idParceiro" };
        public static readonly IList<string> keyParceiro = new List<string>() { "idParceiro" };
        public static readonly IList<string> keyImagem = new List<string>() { "idImagem" };
        public static readonly IList<string> keyItemPedido = new List<string>() { "idItem", "idPedido", "idParceiro" };
        public static readonly IList<string> keyNewsLetter = new List<string>() { "idNewsletter" };
        public static readonly IList<string> keyOrderPointsTemp = new List<string>() { "idOrder", "idPedido", "idParceiro" };
        public static readonly IList<string> keyPedido = new List<string>() { "idPedido", "idParceiro" };
        public static readonly IList<string> keyProduto = new List<string>() { "idProduto", "idParceiro" };
        public static readonly IList<string> keyRebate = new List<string>() { "idProduto", "idParceiro" };
        public static readonly IList<string> keyTracking = new List<string>() { "idTracking" };
        public static readonly IList<string> keyUsuario = new List<string>() { "idUsuario" };

        //***********************************************************************************************************************************
        //WHERE KEY
        //***********************************************************************************************************************************
        public const string whereKeyAmbiente = "idAmbiente = @idAmbienteKey";
        public const string whereKeyAtributo = "idAtributo = @idAtributoKey";
        public const string whereKeyCategoria = "idCategoria = @idCategoriaKey AND idParceiro = @idParceiroKey";
        public const string whereKeyParceiro = "idParceiro = @idParceiroKey";
        public const string whereKeyImagem = "idImagem = @idImagemKey";
        public const string whereKeyItemPedido = "idItem = @idItemKey AND idPedido = @idPedidoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyNewsletter = "idNewsletter = @idNewsletterKey";
        public const string whereKeyOrderPointsTemp = "idOrder = @idOrderKey AND idPedido = @idPedidoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyPedido = "idPedido = @idPedidoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyProduto = "idProduto	= @idProdutoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyRebate = "idProduto = @idProdutoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyTracking = "idTracking = @idTrackingKey AND idPedido = @idPedidoKey AND idParceiro = @idParceiroKey";
        public const string whereKeyUsuario = "idUsuario = @idUsuarioKey";

        //***********************************************************************************************************************************
        //PROCEDURE DE PAGINAÇÃO
        //***********************************************************************************************************************************
        internal sealed class spPaginacao
        {
            public const string nameSp = "SP_SELECT_PAGE";

            internal sealed class Parameters
            {
                internal sealed class sqlSelect
                {
                    public const string name = "@SQLSELECT";
                    public const DbType type = DbType.String;
                }
                internal sealed class orderBy
                {
                    public const string name = "@ORDERBY";
                    public const DbType type = DbType.String;
                }
                internal sealed class start
                {
                    public const string name = "@START";
                    public const DbType type = DbType.Int32;
                }
                internal sealed class size
                {
                    public const string name = "@SIZE";
                    public const DbType type = DbType.Int32;
                }
                internal sealed class rowsCount
                {
                    public const string name = "@ROWSCOUNT";
                    public const DbType type = DbType.Int32;
                }
            }
        }
    }
}
