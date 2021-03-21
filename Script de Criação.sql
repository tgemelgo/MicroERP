USE [master]
GO
CREATE DATABASE NOME_BANCO_DE_DADOS
go
ALTER DATABASE NOME_BANCO_DE_DADOS SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET ANSI_NULLS OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET ANSI_PADDING OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET ARITHABORT OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET AUTO_CLOSE ON 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET AUTO_SHRINK ON 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET  DISABLE_BROKER 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET TRUSTWORTHY OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET RECOVERY SIMPLE 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET  MULTI_USER 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET DB_CHAINING OFF 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Perola_Producao', N'ON'
GO
USE NOME_BANCO_DE_DADOS
GO
CREATE TYPE [Moeda] FROM [numeric](11, 2) NULL
GO
CREATE TYPE [Peso] FROM [numeric](8, 3) NULL
GO
CREATE TYPE [Porcentagem] FROM [numeric](5, 2) NULL
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [SPLIT]
(
	@ItemList NVARCHAR(MAX), 
	@delimiter CHAR(1)
)
RETURNS @IDTable TABLE (Item VARCHAR(50))  
AS      

BEGIN    
	DECLARE @tempItemList NVARCHAR(MAX)
	SET @tempItemList = @ItemList

	DECLARE @i INT    
	DECLARE @Item NVARCHAR(MAX)

	SET @tempItemList = REPLACE (@tempItemList, ' ', '')
	SET @i = CHARINDEX(@delimiter, @tempItemList)

	WHILE (LEN(@tempItemList) > 0)
	BEGIN
		IF @i = 0
			SET @Item = @tempItemList
		ELSE
			SET @Item = LEFT(@tempItemList, @i - 1)
		INSERT INTO @IDTable(Item) VALUES(@Item)
		IF @i = 0
			SET @tempItemList = ''
		ELSE
			SET @tempItemList = RIGHT(@tempItemList, LEN(@tempItemList) - @i)
		SET @i = CHARINDEX(@delimiter, @tempItemList)
	END 
	RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ambientes_NFe](
	[Ambiente_NFe] [tinyint] NOT NULL,
	[Descricao] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ambiente_NFe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ativacao_Software](
	[Modo_Autentica] [char](1) NULL,
	[Chave_Ativacao] [varchar](2000) NOT NULL,
	[Data_Ativacao] [smalldatetime] NULL,
	[Timestamp] [timestamp] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bancos](
	[Banco] [smallint] NOT NULL,
	[Descr_Banco] [varchar](50) NOT NULL,
	[Logo_Banco] [image] NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Bancos_1] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Boletos_Especies_Documentos](
	[Banco] [smallint] NOT NULL,
	[EspecieDoc] [smallint] NOT NULL,
	[Desc_EspecieDoc] [varchar](60) NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Boletos_Especies_Documentos] PRIMARY KEY CLUSTERED 
(
	[Banco] ASC,
	[EspecieDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Boletos_Gerados](
	[Boleto_Gerado] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal_Duplicata] [int] NOT NULL,
	[Empresa] [int] NOT NULL,
	[Data_Documento] [datetime] NOT NULL,
	[Conta_Corrente] [smallint] NOT NULL,
	[Codigo_Barras] [char](44) NOT NULL,
	[Linha_Digitavel] [char](54) NOT NULL,
	[Banco] [smallint] NOT NULL,
	[EspecieDoc] [smallint] NOT NULL,
	[ArquivoRemessao_Enviado] [bit] NOT NULL,
	[ArquivoRemessa_Lote] [int] NULL,
	[Boleto_Tipo_Ocorrencia] [int] NULL,
	[Boleto_Impresso] [bit] NOT NULL,
	[Boleto_Pago] [bit] NOT NULL,
	[Data_Pagamento] [datetime] NULL,
	[Valor_Pago] [dbo].[Moeda] NULL,
 CONSTRAINT [PK_Boletos] PRIMARY KEY CLUSTERED 
(
	[Boleto_Gerado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Boletos_Gerados_Instrucoes](
	[Boleto_Gerado_Instrucao] [int] IDENTITY(1,1) NOT NULL,
	[Boleto_Gerado] [int] NOT NULL,
	[Boleto_Instrucao] [smallint] NOT NULL,
	[Mensagem_Customizada] [varchar](300) NULL,
 CONSTRAINT [PK_Notas_Fiscais_Duplicatas_Instrucoes] PRIMARY KEY CLUSTERED 
(
	[Boleto_Gerado_Instrucao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Boletos_Instrucoes](
	[Boleto_Instrucao] [smallint] IDENTITY(1,1) NOT NULL,
	[Codigo_Instrucao] [smallint] NULL,
	[Banco] [smallint] NOT NULL,
	[Desc_Boleto_Instrucao] [varchar](100) NOT NULL,
	[NumeroDias] [tinyint] NULL,
	[Porcento] [dbo].[Porcentagem] NULL,
 CONSTRAINT [PK_Boletos_Instrucoes] PRIMARY KEY CLUSTERED 
(
	[Boleto_Instrucao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Boletos_Tipos_Ocorrencias](
	[Boleto_Tipo_Correncia] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [smallint] NOT NULL,
	[Cod_Ocorrencia] [smallint] NOT NULL,
	[Descricao] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Boletos_Tipos_Ocorrencias] PRIMARY KEY CLUSTERED 
(
	[Boleto_Tipo_Correncia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorias_Produtos](
	[Categoria_Produto] [int] IDENTITY(1,1) NOT NULL,
	[SubGrupo_Produto] [int] NOT NULL,
	[Desc_Categoria_Produto] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Categoria_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CFOPS](
	[CFOP] [smallint] NOT NULL,
	[Desc_CFOP] [varchar](200) NOT NULL,
	[Entrada] [bit] NOT NULL,
	[Tipo_Operacao] [smallint] NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_CFOPS] PRIMARY KEY CLUSTERED 
(
	[CFOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CFOPS_Regras](
	[CFOP] [smallint] NOT NULL,
	[Empresa] [int] NOT NULL,
	[Estado] [char](2) NULL,
	[Com_ST] [bit] NOT NULL,
	[Sem_ST] [bit] NOT NULL,
	[Com_Reducao] [bit] NOT NULL,
	[Sem_Reducao] [bit] NOT NULL,
	[Consumidor_Final] [bit] NOT NULL,
	[Revenda] [bit] NOT NULL,
	[Bonificacao] [bit] NOT NULL,
	[Remessa_Deposito] [bit] NOT NULL,
	[Devolucao] [bit] NOT NULL,
 CONSTRAINT [PK_CFOPS_Regras] PRIMARY KEY CLUSTERED 
(
	[CFOP] ASC,
	[Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Classificacoes_Fiscais](
	[Classificacao_Fiscal] [smallint] IDENTITY(1,1) NOT NULL,
	[Cod_Classificacao_Fiscal] [varchar](15) NOT NULL,
	[Classificacao_Fiscal_Nota] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Classificacoes_Fiscais_1] PRIMARY KEY CLUSTERED 
(
	[Classificacao_Fiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clientes](
	[Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Razao_Social] [varchar](100) NOT NULL,
	[Nome_Fantasia] [varchar](80) NULL,
	[Pessoa_Juridica] [bit] NOT NULL,
	[CPF_CNPJ] [varchar](14) NULL,
	[RG_IE] [varchar](15) NULL,
	[Sexo] [int] NULL,
	[Profissao_Ramo_Atividade] [varchar](60) NULL,
	[DDD1] [tinyint] NULL,
	[Fone1] [varchar](8) NULL,
	[DDD2] [tinyint] NULL,
	[Fone2] [varchar](8) NULL,
	[DDD3] [tinyint] NULL,
	[Fone3] [varchar](10) NULL,
	[Estado_Civil] [smallint] NULL,
	[Dt_Nasc_Fundacao] [smalldatetime] NULL,
	[Endereco_Correspondencia] [varchar](80) NULL,
	[Numero_Correspondencia] [varchar](10) NULL,
	[Complemento_Correspondencia] [varchar](30) NULL,
	[Bairro_Correspondencia] [varchar](30) NULL,
	[Cidade_Correspondencia] [varchar](30) NULL,
	[Cod_Cidade_Correspondencia_IBGE] [int] NOT NULL,
	[Estado_Correspondencia] [char](2) NULL,
	[Cod_Estado_Correspondencia_IBGE] [int] NOT NULL,
	[CEP_Correspondencia] [char](10) NULL,
	[Cod_Pais_Correspondencia_IBGE] [smallint] NOT NULL,
	[Endereco_Cobranca] [varchar](80) NULL,
	[Numero_Cobranca] [varchar](10) NULL,
	[Complemento_Cobranca] [varchar](30) NULL,
	[Bairro_Cobranca] [varchar](30) NULL,
	[Cidade_Cobranca] [varchar](30) NULL,
	[Estado_Cobranca] [char](2) NULL,
	[CEP_Cobranca] [char](10) NULL,
	[Endereco_Entrega] [varchar](80) NULL,
	[Numero_Entrega] [varchar](10) NULL,
	[Complemento_Entrega] [varchar](30) NULL,
	[Bairro_Entrega] [varchar](30) NULL,
	[Cidade_Entrega] [varchar](30) NULL,
	[Estado_Entrega] [char](2) NULL,
	[CEP_Entrega] [char](10) NULL,
	[Data_Cadastro] [smalldatetime] NOT NULL,
	[Data_Atualizacao] [smalldatetime] NOT NULL,
	[Forma_Pagamento] [int] NULL,
	[Tipo_Produto_Fornece] [int] NULL,
	[EMail] [varchar](80) NULL,
	[Home_Page] [varchar](80) NULL,
	[Tipo_Cliente] [bit] NOT NULL,
	[Tipo_Fornecedor] [bit] NOT NULL,
	[Vendedor] [int] NULL,
	[Transportadora] [int] NULL,
	[Reducao_ICMS] [bit] NOT NULL,
	[Nao_Incide_ST] [bit] NOT NULL,
	[Consumidor_Final] [bit] NOT NULL,
	[Inadimplente] [bit] NOT NULL,
	[Regime_Normal_RPA] [bit] NOT NULL,
	[Tabela_Preco] [smallint] NULL,
	[Observacoes] [text] NULL,
	[Observacoes_Nota] [varchar](60) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK__Clientes__5224328E] PRIMARY KEY CLUSTERED 
(
	[Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clientes_Contatos](
	[Clientes_Contatos] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [int] NOT NULL,
	[Nome] [varchar](80) NOT NULL,
	[DDD] [int] NULL,
	[Telefone] [varchar](8) NULL,
	[EMail] [varchar](80) NULL,
	[Data_Nasc] [smalldatetime] NULL,
 CONSTRAINT [PK__Clientes_Contato__6B99EBCE] PRIMARY KEY CLUSTERED 
(
	[Clientes_Contatos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Condicoes_Pagamento_Pedido](
	[Condicao_Pagamento_Pedido] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Cond_Pgto] [varchar](30) NULL,
	[Parcelado] [bit] NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Condicoes_Pagamento] PRIMARY KEY CLUSTERED 
(
	[Condicao_Pagamento_Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Condicoes_Pagamento_Pedido_Itens](
	[Condicao_Pagamento_Pedido_Item] [int] IDENTITY(1,1) NOT NULL,
	[Condicao_Pagamento_Pedido] [smallint] NOT NULL,
	[Prazo_dias] [smallint] NOT NULL,
 CONSTRAINT [PK_Condicoes_Pagamentos_Pedidos_Itens] PRIMARY KEY CLUSTERED 
(
	[Condicao_Pagamento_Pedido_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contadores](
	[Contador] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Contador] [varchar](50) NULL,
	[Proximo_Valor] [numeric](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Contador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Correntes](
	[Conta_Corrente] [smallint] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Banco] [smallint] NOT NULL,
	[Agencia] [varchar](10) NOT NULL,
	[Numero_Conta] [varchar](15) NOT NULL,
	[Boleto_Carteira] [varchar](3) NULL,
	[Boleto_CodigoCedente] [int] NULL,
	[Boleto_EspecieDoc] [smallint] NULL,
	[Boleto_Convenio] [int] NULL,
 CONSTRAINT [PK_Contas_Correntes] PRIMARY KEY CLUSTERED 
(
	[Conta_Corrente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Correntes_Boletos_Instrucoes](
	[Conta_Corrente_Boleto_Instrucao] [int] IDENTITY(1,1) NOT NULL,
	[Conta_Corrente] [smallint] NOT NULL,
	[Boleto_Instrucao] [smallint] NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Contas_Correntes_Boletos_Instrucoes] PRIMARY KEY CLUSTERED 
(
	[Conta_Corrente_Boleto_Instrucao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Pagar](
	[Conta_pagar] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Cliente] [int] NULL,
	[Numero_Documento] [varchar](30) NOT NULL,
	[Tipo_Documento] [int] NOT NULL,
	[Valor_Original] [numeric](18, 2) NOT NULL,
	[Valor_Pago] [numeric](18, 2) NOT NULL,
	[Data_Cadastro] [smalldatetime] NOT NULL,
 CONSTRAINT [PK__Contas_Pagar__0F624AF8] PRIMARY KEY CLUSTERED 
(
	[Conta_pagar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Pagar_Mov](
	[Conta_pagar_mov] [int] IDENTITY(1,1) NOT NULL,
	[Conta_pagar] [int] NOT NULL,
	[Conta_pagar_parcela] [int] NOT NULL,
	[Numero_Lote] [varchar](8) NOT NULL,
	[Tipo_Movimento] [int] NOT NULL,
	[Data_Movimento] [smalldatetime] NOT NULL,
	[Valor_Pago] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK__Contas_Pagar_Mov__4D562727] PRIMARY KEY CLUSTERED 
(
	[Conta_pagar_mov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Pagar_Parcela](
	[Conta_Pagar_Parcela] [int] IDENTITY(1,1) NOT NULL,
	[Conta_Pagar] [int] NOT NULL,
	[Parcela] [tinyint] NOT NULL,
	[Data_Cadastro] [smalldatetime] NOT NULL,
	[Data_Emissao] [smalldatetime] NOT NULL,
	[Data_Vencimento] [smalldatetime] NOT NULL,
	[Valor_Original] [numeric](18, 2) NOT NULL,
	[Valor_Pagar] [numeric](18, 2) NOT NULL,
	[Parcela_Paga] [bit] NOT NULL,
 CONSTRAINT [PK_f_Conta_Pagar_Parcela] PRIMARY KEY CLUSTERED 
(
	[Conta_Pagar_Parcela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Receber](
	[Conta_receber] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Cliente] [int] NULL,
	[Numero_Documento] [varchar](30) NOT NULL,
	[Nota_Fiscal] [int] NULL,
	[Tipo_Documento] [int] NOT NULL,
	[Tipo_Pagamento] [int] NOT NULL,
	[Valor_Original] [numeric](18, 2) NOT NULL,
	[Valor_Pago] [numeric](18, 2) NULL,
	[Data_Cadastro] [smalldatetime] NOT NULL,
 CONSTRAINT [PK__Contas_Receber__42D898B4] PRIMARY KEY CLUSTERED 
(
	[Conta_receber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Receber_mov](
	[Conta_Receber_Mov] [int] IDENTITY(1,1) NOT NULL,
	[Conta_Receber] [int] NOT NULL,
	[Conta_Receber_Parcela] [int] NOT NULL,
	[Numero_Lote] [varchar](10) NOT NULL,
	[Tipo_Movimento] [int] NOT NULL,
	[Data_Movimento] [smalldatetime] NOT NULL,
	[Valor_Pago] [numeric](18, 2) NOT NULL,
	[Protesto_Pago] [bit] NOT NULL,
	[Protesto_Pago_Data] [smalldatetime] NULL,
 CONSTRAINT [PK__Contas_Receber_m__55EB6D28] PRIMARY KEY CLUSTERED 
(
	[Conta_Receber_Mov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Contas_Receber_Parcela](
	[Conta_Receber_Parcela] [int] IDENTITY(1,1) NOT NULL,
	[Conta_Receber] [int] NOT NULL,
	[Parcela] [tinyint] NOT NULL,
	[Data_Cadastro] [smalldatetime] NOT NULL,
	[Data_Emissao] [smalldatetime] NOT NULL,
	[Data_Vencimento] [smalldatetime] NOT NULL,
	[Valor_Original] [numeric](18, 2) NOT NULL,
	[Valor_Receber] [numeric](18, 2) NOT NULL,
	[Parcela_Paga] [bit] NOT NULL,
	[Protesto] [bit] NOT NULL,
 CONSTRAINT [PK_Contas_Receber_Parcela] PRIMARY KEY CLUSTERED 
(
	[Conta_Receber_Parcela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CSOSN](
	[CSOSN] [char](3) NOT NULL,
	[Desc_CSOSN] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CSOSN] PRIMARY KEY CLUSTERED 
(
	[CSOSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Departamentos](
	[Departamento] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Departamento] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Empresas](
	[Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Razao_Social] [varchar](100) NOT NULL,
	[Nome_Fantasia] [varchar](80) NOT NULL,
	[DDD_Comercial] [varchar](2) NULL,
	[Telefone_Comercial] [varchar](8) NULL,
	[DDD_Fax] [varchar](2) NULL,
	[Telefone_Fax] [varchar](8) NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[IE] [varchar](20) NOT NULL,
	[Endereco] [varchar](80) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Complemento] [varchar](30) NULL,
	[Bairro] [varchar](30) NOT NULL,
	[Cidade] [varchar](30) NOT NULL,
	[Cod_Cidade_IBGE] [int] NOT NULL,
	[Estado] [char](2) NOT NULL,
	[Cod_Estado_IBGE] [int] NOT NULL,
	[CEP] [varchar](8) NOT NULL,
	[Cod_Pais_IBGE] [nchar](10) NOT NULL,
	[Proxima_Nota_Fiscal] [int] NOT NULL,
	[Serie_Nota_Fiscal] [varchar](5) NOT NULL,
	[EMail] [varchar](50) NULL,
	[Home_page] [varchar](50) NULL,
	[Mensagem_Padrao_Nota] [varchar](2000) NULL,
	[NFP_Ativar_Recurso] [bit] NOT NULL,
	[NFP_Usuario] [varchar](14) NULL,
	[NFP_Senha] [varchar](30) NULL,
	[NFP_Categoria_Usuario] [tinyint] NULL,
	[NFE_Ativar_Recurso] [bit] NOT NULL,
	[Serial_Number_Certifica_Digital] [varchar](50) NULL,
	[NFE_EnvioXML_Ativar_Recurso] [bit] NOT NULL,
	[NFE_EnvioXML_Email] [varchar](50) NULL,
	[NFE_EnvioXML_Servidor] [varchar](50) NULL,
	[NFE_EnvioXML_Servidor_Porta] [int] NULL,
	[NFE_EnvioXML_Servidor_Autenticacao] [bit] NULL,
	[NFE_EnvioXML_Usuario] [varchar](50) NULL,
	[NFE_EnvioXML_Senha] [varchar](50) NULL,
	[NFE_EnvioXML_Mensagem] [text] NULL,
	[Regime_Tributario] [tinyint] NULL,
	[Aliquota_Credito_Simples_Nacional] [dbo].[Porcentagem] NULL,
	[DataEntrega_Igual_DataSistema] [bit] NOT NULL,
	[Logo] [image] NULL,
	[Inativo] [bit] NOT NULL,
	[Aliquota_Consumidor_Final] [dbo].[Porcentagem] NULL,
 CONSTRAINT [PK__Filiais__1D671CE3] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Enderecos_WebService_NFe](
	[Estado] [varchar](4) NOT NULL,
	[Servico] [varchar](20) NOT NULL,
	[Ambiente] [tinyint] NOT NULL,
	[WebService] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Enderecos_WebService_NFe] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC,
	[Servico] ASC,
	[Ambiente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Escolaridades](
	[Escolaridade] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Escolaridade] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Escolaridade] PRIMARY KEY CLUSTERED 
(
	[Escolaridade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Estados](
	[Estado] [char](2) NOT NULL,
	[Nome_Estado] [varchar](30) NOT NULL,
	[Codigo_IBGE] [tinyint] NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Estados_Civis](
	[Estado_Civil] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Estado_Civil] [varchar](35) NULL,
 CONSTRAINT [PK__Estados_Civis__3864608B] PRIMARY KEY CLUSTERED 
(
	[Estado_Civil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Estoques](
	[Estoque] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NULL,
	[Produto] [int] NOT NULL,
	[Quantidade_Disponivel] [int] NOT NULL,
	[Quantidade_Reservada] [int] NOT NULL,
	[Quantidade_Total] [int] NOT NULL,
 CONSTRAINT [PK_Estoques] PRIMARY KEY CLUSTERED 
(
	[Estoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Formas_Pagamentos](
	[Forma_Pagamento] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Forma_Pgto] [varchar](50) NOT NULL,
	[Numero_Parcelas] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Forma_Pagamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Funcionarios](
	[Funcionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](50) NULL,
	[Complemento] [varchar](30) NULL,
	[Bairro] [varchar](30) NULL,
	[Cidade] [varchar](30) NULL,
	[Estado] [char](2) NULL,
	[CEP] [char](8) NULL,
	[DDD1] [char](2) NULL,
	[Fone1] [varchar](8) NULL,
	[DDD2] [char](2) NULL,
	[Fone2] [varchar](8) NULL,
	[Departamento] [smallint] NULL,
	[Funcao] [varchar](100) NULL,
	[Jornada_Diaria] [smalldatetime] NULL,
	[Entrada_Manha] [smalldatetime] NULL,
	[Saida_Manha] [smalldatetime] NULL,
	[Entrada_Tarde] [smalldatetime] NULL,
	[Saida_Tarde] [smalldatetime] NULL,
	[Data_Nascimento] [smalldatetime] NULL,
	[Cidade_Nascimento] [varchar](30) NULL,
	[Estado_Nascimento] [char](2) NULL,
	[Data_Admissao] [smalldatetime] NULL,
	[Data_Demissao] [smalldatetime] NULL,
	[Matricula] [int] NULL,
	[Escolaridade] [smallint] NULL,
	[Nacionalidade] [varchar](30) NULL,
	[Estado_Civil] [smallint] NULL,
	[Tipo_Vinculo] [smallint] NULL,
	[Banco] [smallint] NULL,
	[Agencia] [varchar](15) NULL,
	[Conta_Corrente] [varchar](15) NULL,
	[Tipo_Conta] [smallint] NULL,
	[RG] [varchar](15) NULL,
	[RG_Data_Emissao] [smalldatetime] NULL,
	[RG_Orgao_Emissao] [char](3) NULL,
	[Titulo_Eleitor] [varchar](20) NULL,
	[CPF] [varchar](11) NULL,
	[Carteira_Proficional] [varchar](11) NULL,
	[Serie] [varchar](5) NULL,
	[Pis] [varchar](20) NULL,
	[Qtde_Dependentes] [tinyint] NULL,
	[Qtde_Filhos] [tinyint] NULL,
	[Valor_Salario] [decimal](18, 2) NULL,
	[Valor_Perioculosidade] [decimal](18, 2) NULL,
	[Valor_Adicional_Noturno] [decimal](18, 2) NULL,
	[Valor_Seguro] [decimal](18, 2) NULL,
	[Data_Adesao] [smalldatetime] NULL,
	[Observacao] [text] NULL,
	[Inativo] [bit] NOT NULL,
	[Motorista] [bit] NOT NULL,
	[Nome_Pai] [varchar](80) NULL,
	[Nome_Mae] [varchar](80) NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[Funcionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Funcionarios_Dependentes](
	[Funcionario_Dependente] [int] IDENTITY(1,1) NOT NULL,
	[Funcionario] [int] NOT NULL,
	[Nome_Dependente] [varchar](80) NOT NULL,
	[DT_Nasc] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Funcionario_Dependente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grupos_Favoritos](
	[Grupo_Favorito] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Grupo_Favorito] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Grupo_Favorito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grupos_Produtos](
	[Grupo_Produto] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Grupo_Produto] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Grupo_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ICMS_Estados](
	[Origem] [char](2) NOT NULL,
	[Destino] [char](2) NOT NULL,
	[Icms] [numeric](5, 2) NOT NULL,
 CONSTRAINT [PK_ICMS] PRIMARY KEY CLUSTERED 
(
	[Origem] ASC,
	[Destino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Idiomas](
	[Idioma] [varchar](20) NOT NULL,
	[Descricao] [varchar](25) NOT NULL,
 CONSTRAINT [PK__Idiomas__30F848ED] PRIMARY KEY CLUSTERED 
(
	[Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mensagens_Notas](
	[Mensagem_Nota] [int] IDENTITY(1,1) NOT NULL,
	[Mensagem] [varchar](500) NOT NULL,
	[Query_Verifica_Utilizacao] [text] NULL,
	[Query_Substituicao] [text] NULL,
 CONSTRAINT [PK_Mensagens_Notas] PRIMARY KEY CLUSTERED 
(
	[Mensagem_Nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mensagens_Retorno_NFe](
	[Codigo_Mensagem_Retorno] [smallint] NOT NULL,
	[Descricao] [varchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo_Mensagem_Retorno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mensagens_Retorno_NFp](
	[Codigo_Mensagem_Retorno] [smallint] NOT NULL,
	[Descricao] [varchar](500) NULL,
 CONSTRAINT [PK__Mensagens_Retorn__76C185B7] PRIMARY KEY CLUSTERED 
(
	[Codigo_Mensagem_Retorno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Menus_Itens](
	[Menu_Item] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[Nivel] [smallint] NOT NULL,
	[ParentNivel] [smallint] NOT NULL,
	[Namespace] [varchar](50) NULL,
	[Formulario] [varchar](30) NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Menu_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Menus_Itens_Favoritos](
	[Menu_Item_Favorito] [int] IDENTITY(1,1) NOT NULL,
	[Grupo_Favorito] [int] NOT NULL,
	[Menu_Item] [int] NOT NULL,
	[Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Menu_Item_Favorito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Menus_Itens_Relatorios](
	[Menu_Item_Relatorio] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Item] [int] NOT NULL,
	[Nome_Relatorio] [varchar](80) NULL,
	[NameSpace] [varchar](100) NULL,
	[Relatorio] [varchar](50) NULL,
	[Descricao_Relatorio] [text] NULL,
	[Ativo] [bit] NOT NULL,
	[TodosReg_Enable] [bit] NOT NULL,
	[RegAtual_Enable] [bit] NOT NULL,
	[Value_Enable] [tinyint] NULL,
 CONSTRAINT [PK_Menus_Itens_Relatorios] PRIMARY KEY CLUSTERED 
(
	[Menu_Item_Relatorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Modalidades_Calculo_ICMS](
	[Modalidade_Calculo_ICMS] [tinyint] NOT NULL,
	[Descricao_Modalidade] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Modalidade_Calculo_ICMS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Modalidades_Calculo_ICMS_ST](
	[Modalidade_Calculo_ICMS_ST] [tinyint] NOT NULL,
	[Descricao_Mod_ST] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Modalidade_Calculo_ICMS_ST] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Modulos](
	[Modulo] [smallint] IDENTITY(1,1) NOT NULL,
	[Descricao_Modulo] [varchar](50) NOT NULL,
	[Imagem] [image] NULL,
	[Caminho_Imagem] [varchar](300) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK__Modulos__3FF073BA] PRIMARY KEY CLUSTERED 
(
	[Modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Modulos_Menus](
	[Modulo_Menu] [smallint] IDENTITY(1,1) NOT NULL,
	[Modulo] [smallint] NOT NULL,
	[Menu_Item] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Modulo_Menu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Moedas](
	[Moeda] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Moeda] [varchar](30) NULL,
	[Sigla] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Moeda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Movimentos_Estoque](
	[Movimento_Estoque] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Movimento_Estoque] [smallint] NOT NULL,
	[Empresa] [int] NULL,
	[Cliente] [int] NULL,
	[Numero_Documento] [varchar](30) NULL,
	[Descricao] [varchar](80) NOT NULL,
	[Data_Movimento] [smalldatetime] NOT NULL,
	[Valor_Total] [dbo].[Moeda] NOT NULL,
 CONSTRAINT [PK_Movimento_Estoque] PRIMARY KEY CLUSTERED 
(
	[Movimento_Estoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Movimentos_Estoque_Itens](
	[Movimento_Estoque_Item] [int] IDENTITY(1,1) NOT NULL,
	[Movimento_Estoque] [int] NOT NULL,
	[Produto] [int] NOT NULL,
	[Valor_Unitario] [dbo].[Moeda] NOT NULL,
	[Quantidade] [smallint] NOT NULL,
	[Valor_Total] [dbo].[Moeda] NOT NULL,
 CONSTRAINT [PK_Movimentos_Estoque_Itens] PRIMARY KEY CLUSTERED 
(
	[Movimento_Estoque_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Municipios](
	[Estado] [char](2) NOT NULL,
	[Codigo_IBGE] [int] NOT NULL,
	[Nome_Municipio] [varchar](35) NOT NULL,
 CONSTRAINT [PK_Municipios] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC,
	[Codigo_IBGE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais](
	[Nota_Fiscal] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Pedido] [int] NOT NULL,
	[Numero_Nota] [int] NOT NULL,
	[Serie_Nota] [varchar](5) NOT NULL,
	[Tipo_Entrada] [bit] NOT NULL,
	[Tipo_Saida] [bit] NOT NULL,
	[Impressa] [bit] NOT NULL,
	[Cancelada] [bit] NOT NULL,
	[Data_Emissao] [smalldatetime] NOT NULL,
	[Data_Entrega] [smalldatetime] NOT NULL,
	[CFOP] [smallint] NULL,
	[Cliente] [int] NOT NULL,
	[Transportadora] [int] NOT NULL,
	[Condicao_Pagamento_Pedido] [smallint] NOT NULL,
	[Valor_Base_ICMS] [dbo].[Moeda] NULL,
	[Valor_ICMS] [dbo].[Moeda] NULL,
	[Valor_Base_Substituicao_ICMS] [dbo].[Moeda] NULL,
	[Valor_Substituicao_ICMS] [dbo].[Moeda] NULL,
	[Valor_Cred_Simples_Nacional] [dbo].[Moeda] NULL,
	[Valor_IPI] [dbo].[Moeda] NULL,
	[Valor_Frete] [dbo].[Moeda] NULL,
	[ICMS_Frete] [dbo].[Moeda] NULL,
	[Valor_Seguro] [dbo].[Moeda] NULL,
	[ICMS_Seguro] [dbo].[Moeda] NULL,
	[Outros_Valores] [dbo].[Moeda] NULL,
	[Valor_Desconto] [dbo].[Moeda] NULL,
	[Valor_PIS] [dbo].[Moeda] NULL,
	[Valor_COFINS] [dbo].[Moeda] NULL,
	[Valor_Total_Produtos] [dbo].[Moeda] NULL,
	[Valor_Total_Nota] [dbo].[Moeda] NULL,
	[Tipo_Frete] [tinyint] NOT NULL,
	[Quantidade_Itens] [int] NOT NULL,
	[Especie] [varchar](30) NULL,
	[Marca] [varchar](30) NULL,
	[Numero] [varchar](30) NULL,
	[Peso_Bruto] [dbo].[Peso] NOT NULL,
	[Peso_Liquido] [dbo].[Peso] NOT NULL,
	[Chave_Acesso] [char](44) NULL,
	[Observacao] [varchar](200) NULL,
	[Estoque_Baixado] [bit] NOT NULL,
	[Consiliacao_Financeira_Realizada] [bit] NOT NULL,
	[Placa_Transporte] [varchar](8) NULL,
	[UF_Placa_Transporte] [char](2) NULL,
	[Reg_Nacional_Transportador] [varchar](20) NULL,
	[Exportacao_NFp] [bit] NOT NULL,
	[Exportacao_NFe] [bit] NOT NULL,
	[NFe_DocumentoXML] [text] NULL,
	[NFe_Protocolo] [varchar](15) NULL,
	[NFe_Protocolo_Data] [datetime] NULL,
	[Nota_Fiscal_Referencia] [int] NULL,
	[Descricao_CFOP_Complementar] [varchar](100) NULL,
	[Texto_Carta_Correcao] [varchar](1000) NULL,
	[NFe_ResultadoCartaCorrecaoXML] [text] NULL,
 CONSTRAINT [PK_Notas_Fiscais] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Duplicatas](
	[Nota_Fiscal_Duplicata] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal] [int] NOT NULL,
	[Numero_Parcela] [smallint] NOT NULL,
	[Data_Vencimento] [smalldatetime] NOT NULL,
	[Valor_Duplicata] [dbo].[Moeda] NOT NULL,
	[Impressa] [bit] NOT NULL,
 CONSTRAINT [PK_Notas_Fiscais_Duplicatas] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Duplicata] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Itens](
	[Nota_Fiscal_Item] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal] [int] NOT NULL,
	[Produto] [int] NOT NULL,
	[Desc_Produto] [varchar](200) NULL,
	[Desc_Unidade_Abrevidado] [varchar](20) NULL,
	[Quantidade] [int] NOT NULL,
	[Qtde_Por_Caixa] [smallint] NULL,
	[Valor_Unitario] [dbo].[Moeda] NOT NULL,
	[Valor_Total_Item] [dbo].[Moeda] NOT NULL,
	[Peso_Bruto] [dbo].[Peso] NOT NULL,
	[Peso_Liquido] [dbo].[Peso] NOT NULL,
	[CFOP] [smallint] NULL,
	[Classificacao_Fiscal] [smallint] NULL,
	[CSOSN] [char](3) NULL,
	[Situacao_Tributaria] [char](3) NULL,
	[Modalidade_Calculo_ICMS] [tinyint] NULL,
	[Percentual_Reducao_ICMS] [dbo].[Porcentagem] NULL,
	[Aliquota_ICMS] [dbo].[Porcentagem] NULL,
	[Valor_Base_ICMS] [dbo].[Moeda] NULL,
	[Valor_ICMS] [dbo].[Moeda] NULL,
	[Percentual_Credito_ICMS] [dbo].[Porcentagem] NULL,
	[Valor_Credito_ICMS] [dbo].[Moeda] NULL,
	[Aliquota_IPI] [dbo].[Porcentagem] NULL,
	[Valor_IPI] [dbo].[Moeda] NULL,
	[Modalidade_Calculo_ICMS_ST] [tinyint] NULL,
	[Percentual_Adicionado_Substituicao_Tributaria] [dbo].[Porcentagem] NULL,
	[Percentual_Reducao_Substituicao_Tributaria] [dbo].[Porcentagem] NULL,
	[Aliquota_Substituicao_Tributaria] [dbo].[Porcentagem] NULL,
	[Valor_Base_Substituicao_Tributaria] [dbo].[Moeda] NULL,
	[Valor_Substituicao_Tributaria] [dbo].[Moeda] NULL,
	[Situacao_Tributaria_PIS] [tinyint] NULL,
	[Valor_Base_PIS] [dbo].[Moeda] NULL,
	[Aliquota_PIS] [dbo].[Porcentagem] NULL,
	[Qtde_PIS] [int] NULL,
	[Valor_Aliquota_PIS] [dbo].[Moeda] NULL,
	[Valor_PIS] [dbo].[Moeda] NULL,
	[Situacao_Tributaria_COFINS] [tinyint] NULL,
	[Valor_Base_COFINS] [dbo].[Moeda] NULL,
	[Aliquota_COFINS] [dbo].[Porcentagem] NULL,
	[Qtde_COFINS] [int] NULL,
	[Valor_Aliquota_COFINS] [dbo].[Moeda] NULL,
	[Valor_COFINS] [dbo].[Moeda] NULL,
	[Aliquota_Cred_SN] [dbo].[Porcentagem] NULL,
	[Valor_Cred_SN] [dbo].[Moeda] NULL,
	[Valor_Imposto_Consumidor_Final] [dbo].[Moeda] NULL,
 CONSTRAINT [PK_Notas_Fiscais_Itens] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Lotes](
	[Nota_Fiscal_Lote] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Numero_Lote] [int] NOT NULL,
	[Retorno_Capturado] [bit] NOT NULL,
	[Data_Envio_Lote] [datetime] NULL,
	[Protocolo] [varchar](100) NULL,
	[Tipo_NFP] [bit] NOT NULL,
	[Tipo_NFe] [bit] NULL,
	[Tipo_Emissao_NFe] [tinyint] NULL,
	[Data_Processamento] [datetime] NULL,
	[Protocolo_Cancelamento_NFe] [varchar](50) NULL,
	[Data_Cancelamento_NFe] [datetime] NULL,
	[Arquivo_Envio] [varchar](2000) NULL,
	[Ambiente_NFe] [tinyint] NULL,
	[Danfe_Impresso] [bit] NOT NULL,
	[Codigo_Mensagem_Retorno_NFp] [smallint] NULL,
	[Mensagem_Retorno_NFp] [varchar](2000) NULL,
	[Codigo_Mensagem_Retorno_NFe] [smallint] NULL,
	[Mensagem_Retorno_NFe] [varchar](2000) NULL,
 CONSTRAINT [PK__Notas_Fiscais_Lo__461E4E5C] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Lote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Lotes_Contagens](
	[Nota_Fiscal_Lote_Contagem] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal_Lote] [int] NOT NULL,
	[Codigo_Evento] [varchar](30) NULL,
	[Contador] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Lote_Contagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Lotes_Itens](
	[Nota_Fiscal_Lote_Item] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal_Lote] [int] NOT NULL,
	[Nota_Fiscal] [int] NOT NULL,
 CONSTRAINT [PK_Notas_Fiscais_Lotes_Itens] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Lote_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Notas_Fiscais_Lotes_Mensagens](
	[Nota_Fiscal_Lote_Mensagem] [int] IDENTITY(1,1) NOT NULL,
	[Nota_Fiscal_Lote] [int] NOT NULL,
	[Tipo_Mensagem] [varchar](15) NULL,
	[Numero_nota] [int] NULL,
	[Codigo_Mensagem_Retorno_NFp] [smallint] NULL,
	[Codigo_Mensagem_Retorno_NFe] [smallint] NULL,
	[Data_Historico] [smalldatetime] NULL,
 CONSTRAINT [PK__Notas_Fiscais_Lo__668B1DEE] PRIMARY KEY CLUSTERED 
(
	[Nota_Fiscal_Lote_Mensagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Objetos_Entrada](
	[Objeto_Entrada] [varchar](50) NOT NULL,
	[Descricao_Objeto] [varchar](200) NOT NULL,
	[Nome_Arquivo] [varchar](50) NOT NULL,
	[Namespace] [varchar](50) NOT NULL,
	[Classe] [varchar](50) NOT NULL,
	[Metodo] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Objetos_Entrada__75E27017] PRIMARY KEY CLUSTERED 
(
	[Objeto_Entrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Origens_Produtos](
	[Origem_Produto] [tinyint] NOT NULL,
	[Desc_Origem_Produto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Origens_Produtos] PRIMARY KEY CLUSTERED 
(
	[Origem_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Paises](
	[Codigo_IBGE] [smallint] NOT NULL,
	[Nome_Pais] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo_IBGE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pedidos](
	[Pedido] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NOT NULL,
	[Cliente] [int] NOT NULL,
	[Vendedor] [int] NOT NULL,
	[Transportadora] [int] NULL,
	[Condicao_Pagamento_Pedido] [smallint] NOT NULL,
	[Gera_NF] [bit] NOT NULL,
	[NF_Gerada] [bit] NOT NULL,
	[Tabela_Preco] [smallint] NULL,
	[Data_Pedido] [smalldatetime] NOT NULL,
	[Data_Entrega] [smalldatetime] NOT NULL,
	[Cancelado] [bit] NOT NULL,
	[Bonificacao] [bit] NOT NULL,
	[Remessa_Deposito] [bit] NOT NULL,
	[Devolucao] [bit] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pedidos_Itens](
	[Pedido_Item] [int] IDENTITY(1,1) NOT NULL,
	[Pedido] [int] NOT NULL,
	[Produto] [int] NOT NULL,
	[Porcentagem_Desconto] [dbo].[Porcentagem] NULL,
	[Valor_Desconto] [dbo].[Moeda] NULL,
	[Qtde] [int] NOT NULL,
	[Valor_Unitario] [dbo].[Moeda] NOT NULL,
	[Valor_Total] [dbo].[Moeda] NOT NULL,
	[Porcentagem_Comissao] [dbo].[Porcentagem] NOT NULL,
	[Valor_Comissao] [dbo].[Moeda] NOT NULL,
 CONSTRAINT [PK_Pedidos_Itens] PRIMARY KEY CLUSTERED 
(
	[Pedido_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Produtos](
	[Produto] [int] NOT NULL,
	[Desc_Produto] [varchar](200) NULL,
	[Grupo_Produto] [int] NULL,
	[SubGrupo_Produto] [int] NULL,
	[Categoria_Produto] [int] NULL,
	[Unidade_Medida] [smallint] NOT NULL,
	[Classificacao_Fiscal] [smallint] NOT NULL,
	[EAN] [varchar](50) NULL,
	[Comissionado] [bit] NOT NULL,
	[Porcentagem_Comissao] [dbo].[Porcentagem] NULL,
	[Valor_Unitario] [dbo].[Moeda] NULL,
	[Valor_Custo_Unitario] [dbo].[Moeda] NULL,
	[Valor_Venda] [dbo].[Moeda] NOT NULL,
	[Peso_Bruto] [dbo].[Peso] NOT NULL,
	[Peso_Liquido] [dbo].[Peso] NOT NULL,
	[Qtde_Caixa] [bit] NOT NULL,
	[Qtde_Por_Caixa] [smallint] NULL,
	[Origem_Produto] [tinyint] NULL,
	[Imagem] [image] NULL,
	[CEST] [varchar](20) NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Produtos_Tributos](
	[Produto_Tributo] [int] IDENTITY(1,1) NOT NULL,
	[Produto] [int] NOT NULL,
	[Inicio_Vigencia] [smalldatetime] NOT NULL,
	[Empresa] [int] NOT NULL,
	[Origem] [char](2) NOT NULL,
	[Destino] [char](2) NOT NULL,
	[Situacao_Tributaria] [char](3) NULL,
	[CSOSN] [char](3) NULL,
	[CSOSN_RPA] [char](3) NULL,
	[ICMS_Estado] [bit] NOT NULL,
	[ICMS] [dbo].[Porcentagem] NOT NULL,
	[Modalidade_Calculo_ICMS] [tinyint] NULL,
	[Reducao_ICMS] [bit] NOT NULL,
	[Reducao_ICMS_Cliente] [bit] NOT NULL,
	[Reducao_ICMS_Geral] [bit] NOT NULL,
	[Porcentagem_Reducao_ICMS] [dbo].[Porcentagem] NULL,
	[Porcentagem_Credito_ICMS] [dbo].[Porcentagem] NULL,
	[IPI] [dbo].[Porcentagem] NULL,
	[Substituicao_Tributaria] [bit] NOT NULL,
	[Porcentagem_Substituicao_Tributaria] [dbo].[Porcentagem] NULL,
	[Reducao_ST] [bit] NOT NULL,
	[Porcentagem_Reducao_ST] [dbo].[Porcentagem] NULL,
	[Modalidade_Calculo_ICMS_ST] [tinyint] NULL,
	[Situacao_Tributaria_PIS] [tinyint] NULL,
	[Porcentagem_PIS] [dbo].[Porcentagem] NULL,
	[Situacao_Tributaria_COFINS] [tinyint] NULL,
	[Porcentagem_COFINS] [dbo].[Porcentagem] NULL,
	[Porcentagem_Reducao_ST_RPA] [dbo].[Porcentagem] NULL,
 CONSTRAINT [PK_Produtos_Tributos_1] PRIMARY KEY CLUSTERED 
(
	[Produto_Tributo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Produtos_Tributos_Mensagens](
	[Produto_Tributo_Mensagem] [int] IDENTITY(1,1) NOT NULL,
	[Produto_Tributo] [int] NOT NULL,
	[Mensagem_Nota] [int] NOT NULL,
 CONSTRAINT [PK_Produtos_Tributos_Mensagens] PRIMARY KEY CLUSTERED 
(
	[Produto_Tributo_Mensagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Propriedades](
	[Propriedade] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Propriedade] [varchar](300) NULL,
	[Nome_Propriedade] [varchar](100) NOT NULL,
	[Valor] [text] NULL,
 CONSTRAINT [PK__Propriedades__4A8310C6] PRIMARY KEY CLUSTERED 
(
	[Propriedade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Regimes_Tributarios](
	[Regime_Tributario] [tinyint] NOT NULL,
	[Desc_CRT] [varchar](60) NULL,
	[Calcular_Credito_ICMS] [bit] NOT NULL,
 CONSTRAINT [PK_Codigos_Regime_Tributario] PRIMARY KEY CLUSTERED 
(
	[Regime_Tributario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Romaneios](
	[Romaneio] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Funcionario_Motorista] [int] NULL,
	[Data_Romaneio] [smalldatetime] NULL,
 CONSTRAINT [PK_Romaneios] PRIMARY KEY CLUSTERED 
(
	[Romaneio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Romaneios_Itens](
	[Romaneio_Item] [int] IDENTITY(1,1) NOT NULL,
	[Romaneio] [int] NOT NULL,
	[Cliente] [int] NOT NULL,
	[Pedido] [int] NOT NULL,
	[Observacao] [varchar](100) NULL,
	[Ordem] [smallint] NULL,
 CONSTRAINT [PK_Romaneios_Itens] PRIMARY KEY CLUSTERED 
(
	[Romaneio_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sexos](
	[Sexo] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Sexo] [varchar](20) NULL,
 CONSTRAINT [PK_Sexos] PRIMARY KEY CLUSTERED 
(
	[Sexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Situacoes_Tributaria](
	[Situacao_Tributaria] [char](3) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Cobranca_ICMS] [bit] NOT NULL,
	[Aplicacao_Substituicao_Tributaria] [bit] NOT NULL,
	[Aplicacao_Reducao_ICMS] [bit] NOT NULL,
	[Suspencao] [bit] NOT NULL,
	[Direrimento] [bit] NOT NULL,
	[ICMS_Cobrado_Anteriormente] [bit] NOT NULL,
	[Modalidade_Calculo_ICMS] [tinyint] NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Situacoes_Tributaria] PRIMARY KEY CLUSTERED 
(
	[Situacao_Tributaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Situacoes_Tributaria_COFINS](
	[Situacao_Tributaria_COFINS] [tinyint] NOT NULL,
	[Descricao_SitTrib_COFINS] [varchar](150) NOT NULL,
	[Sufixo_NFe] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Situacao_Tributaria_COFINS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Situacoes_Tributaria_PIS](
	[Situacao_Tributaria_PIS] [tinyint] NOT NULL,
	[Descricao_SitTrib_PIS] [varchar](150) NOT NULL,
	[Sufixo_NFe] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Situacao_Tributaria_PIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SubGrupos_Produtos](
	[SubGrupo_Produto] [int] IDENTITY(1,1) NOT NULL,
	[Grupo_Produto] [int] NOT NULL,
	[Desc_SubGrupo_Produto] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubGrupo_Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tabelas_Precos](
	[Tabela_Preco] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Tabela_Preco] [varchar](30) NOT NULL,
	[Condicao_Pagamento_Pedido] [smallint] NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Tabelas_Precos] PRIMARY KEY CLUSTERED 
(
	[Tabela_Preco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tabelas_Precos_Itens](
	[Tabela_Preco_Item] [int] IDENTITY(1,1) NOT NULL,
	[Tabela_Preco] [smallint] NOT NULL,
	[Produto] [int] NOT NULL,
	[Valor_Venda] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Tabelas_Precos_Itens] PRIMARY KEY CLUSTERED 
(
	[Tabela_Preco_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Contas](
	[Tipo_Conta] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Conta] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos_Contas] PRIMARY KEY CLUSTERED 
(
	[Tipo_Conta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Documentos](
	[Tipo_Documento] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Documento] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tipo_Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Emissao_NFe](
	[Tipo_Emissao_NFe] [tinyint] NOT NULL,
	[Descricao] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Tipo_Emissao_NFe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Fretes](
	[Tipo_Frete] [tinyint] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Frete] [varchar](20) NOT NULL,
	[Tipo_Frete_NFe] [tinyint] NULL,
 CONSTRAINT [PK_Tipos_Fretes] PRIMARY KEY CLUSTERED 
(
	[Tipo_Frete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Movimentos](
	[Tipo_Movimento] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Movimento] [varchar](50) NOT NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tipo_Movimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Movimentos_Estoque](
	[Tipo_Movimento_Estoque] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Movimento_Estoque] [varchar](30) NOT NULL,
	[Entrada] [bit] NOT NULL,
	[Saida] [bit] NOT NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos_Movimentos_Estoque] PRIMARY KEY CLUSTERED 
(
	[Tipo_Movimento_Estoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Operacoes](
	[Tipo_Operacao] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Operacao] [varchar](50) NOT NULL,
	[Atualiza_Estoque] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos_Operacoes] PRIMARY KEY CLUSTERED 
(
	[Tipo_Operacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Pagamentos](
	[Tipo_Pagamento] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Pagamento] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tipo_Pagamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Produtos_Fornece](
	[Tipo_Produto_Fornece] [int] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Produto] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Tipo_Produto_Fornece] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tipos_Vinculos](
	[Tipo_Vinculo] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Tipo_Vinculo] [varchar](50) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos_Vinculos] PRIMARY KEY CLUSTERED 
(
	[Tipo_Vinculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Transportadoras](
	[Transportadora] [int] IDENTITY(1,1) NOT NULL,
	[Razao_Social] [varchar](100) NULL,
	[Nome_Fantasia] [varchar](60) NULL,
	[Pessoa_Contato] [varchar](60) NULL,
	[CNPJ] [varchar](15) NULL,
	[Inscricao_Estadual] [varchar](14) NULL,
	[Endereco] [varchar](80) NULL,
	[Numero] [varchar](50) NULL,
	[Complemento] [varchar](30) NULL,
	[Bairro] [varchar](30) NULL,
	[Cidade] [varchar](30) NULL,
	[Estado] [char](2) NULL,
	[CEP] [char](8) NULL,
	[DDD1] [char](2) NULL,
	[Fone1] [varchar](8) NULL,
	[DDD2] [char](2) NULL,
	[Fone2] [varchar](8) NULL,
	[EMail] [varchar](80) NULL,
	[Observacao] [text] NULL,
	[Inativo] [bit] NOT NULL,
	[Transportadora_Propria] [bit] NOT NULL,
	[Tipo_Frete] [tinyint] NOT NULL,
	[Reg_Nacional_Transportador] [varchar](20) NULL,
	[Placa] [varchar](8) NULL,
	[UF_Placa] [char](2) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Transportadora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Unidades_Medidas](
	[Unidade_Medida] [smallint] IDENTITY(1,1) NOT NULL,
	[Desc_Unidade] [varchar](50) NULL,
	[Desc_Unidade_Abreviado] [varchar](20) NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Unidades] PRIMARY KEY CLUSTERED 
(
	[Unidade_Medida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Usuarios](
	[Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Usuario] [varchar](50) NULL,
	[Senha] [varchar](200) NULL,
	[Ativo] [bit] NOT NULL,
	[Adm] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Usuarios_Acessos](
	[Usuario_Acesso] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NOT NULL,
	[Modulo] [smallint] NOT NULL,
	[Menu_Item] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario_Acesso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Vendedores](
	[Vendedor] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Vendedor] [varchar](80) NULL,
	[CPF] [varchar](11) NULL,
	[RG] [varchar](11) NULL,
	[Endereco] [varchar](80) NULL,
	[Numero] [varchar](15) NULL,
	[Complemento] [varchar](30) NULL,
	[Bairro] [varchar](30) NULL,
	[Cidade] [varchar](30) NULL,
	[Estado] [char](2) NULL,
	[CEP] [char](8) NULL,
	[DDD1] [char](2) NULL,
	[Fone1] [varchar](8) NULL,
	[DDD2] [char](2) NULL,
	[Fone2] [varchar](8) NULL,
	[EMail] [varchar](80) NULL,
	[Observacao] [text] NULL,
	[Inativo] [bit] NOT NULL,
 CONSTRAINT [PK_Vendedores] PRIMARY KEY CLUSTERED 
(
	[Vendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [vw_Class_Produto]
as
select 
	  p.Produto
	, p.Desc_Produto
	, p.Grupo_Produto
	, gp.Desc_Grupo_Produto
	, p.SubGrupo_Produto
	, sgp.Desc_SubGrupo_Produto
	, p.Categoria_Produto
	, ca.Desc_Categoria_Produto
	from produtos p
		left outer join grupos_produtos gp on gp.grupo_produto = p.grupo_produto
		left outer join subgrupos_produtos sgp on sgp.subgrupo_produto = p.subgrupo_produto
		left outer join categorias_produtos ca on ca.categoria_produto = p.Categoria_Produto
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [vw_Contas_Pagar_Abertas]  
as  
select     
	convert(bit, 0) as 'Sel'   
	, contas_pagar.Conta_Pagar    
	, cpp.Conta_Pagar_Parcela    
	, cpp.Parcela   
	, Contas_Pagar.Numero_Documento   
	, contas_pagar.Empresa    
	, f.Razao_Social as 'Desc_Filial'    
	, contas_pagar.Cliente    
	, cl.Razao_Social as 'Desc_Cliente'    
	, contas_pagar.Tipo_Documento    
	, td.Desc_Tipo_Documento    
	, contas_pagar.Valor_Original as 'Valor_Titulo'    
	, contas_pagar.Valor_Pago    
	, contas_pagar.Data_Cadastro as 'Data_Cadastro_titulo'   
	, cpp.Data_Cadastro    
	, cpp.Data_Vencimento    
	, cpp.Data_Emissao    
	, cpp.Valor_Original   
	, cpp.Valor_Pagar as 'Valor_Pagar_Parcela'  
	from contas_pagar    
		inner join Contas_Pagar_Parcela cpp on cpp.Conta_Pagar = contas_pagar.conta_pagar    
		inner join Empresas f on f.Empresa = contas_pagar.empresa    
		inner join Tipos_Documentos td on td.Tipo_Documento = contas_pagar.Tipo_Documento    
		left outer join clientes cl on cl.cliente = contas_pagar.cliente
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [vw_Contas_Pagar_Baixadas]
as  
select     
	cp.Conta_Pagar   
	, cpp.Conta_Pagar_Parcela   
	, Contas_Pagar_mov.Conta_pagar_mov   
	, cp.Empresa   
	, cp.Cliente   
	, cp.Numero_Documento   
	, cp.Tipo_Documento as 'Tipo_Documento_Titulo'   
	, cp.Valor_Original 'Valor_Original_Titulo'   
	, cp.Valor_Pago as 'Valor_Pago_Titulo'   
	, cp.Data_Cadastro as 'Data_Cadastro_Titulo'   
	, cpp.Parcela   
	, cpp.Data_Cadastro   
	, cpp.Data_Emissao   
	, cpp.Data_Vencimento   
	, cpp.Valor_Original   
	, cpp.Valor_Pagar   
	, cpp.Parcela_Paga   
	, Contas_Pagar_mov.Tipo_Movimento   
	, Contas_Pagar_mov.Data_Movimento   
	, Contas_Pagar_mov.Valor_Pago   
	, Contas_Pagar_mov.Numero_Lote   
	, cl.Razao_Social as 'Razao_Social_Cliente'   
	, F.Razao_Social as 'Razao_Social_Filial'  
	from Contas_Pagar_mov   
		inner join Contas_Pagar cp on cp.Conta_Pagar = Contas_Pagar_Mov.Conta_Pagar   
		inner join Contas_Pagar_Parcela cpp on cpp.Conta_pagar = cp.Conta_Pagar and cpp.Conta_Pagar_parcela = Contas_pagar_mov.Conta_Pagar_parcela   
		inner join Empresas f on f.Empresa = cp.Empresa
		left outer join Clientes cl on cl.cliente = cp.cliente
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [vw_Contas_Receber_Abertas]  
as  
select     
	convert(bit, 0) as 'Sel'   
	, contas_Receber.Conta_Receber   
	, cpp.Conta_Receber_Parcela    
	, cpp.Parcela   
	, contas_Receber.Numero_Documento   
	, contas_Receber.empresa    
	, f.Razao_Social as 'Desc_Filial'    
	, contas_Receber.Cliente    
	, cl.Razao_Social as 'Desc_Cliente'    
	, contas_Receber.Tipo_Documento    
	, td.Desc_Tipo_Documento    
	, contas_receber.Tipo_Pagamento   
	, tp.Desc_Tipo_Pagamento   
	, contas_Receber.Valor_Original as 'Valor_Titulo'
	, contas_Receber.Valor_Pago    
	, contas_Receber.Data_Cadastro as 'Data_Cadastro_titulo'   
	, cpp.Data_Cadastro    
	, cpp.Data_Vencimento    
	, cpp.Data_Emissao    
	, cpp.Valor_Original   
	, cpp.Valor_Receber as 'Valor_Receber_Parcela'  
	, cpp.Protesto
	from contas_Receber   
		inner join Contas_Receber_Parcela cpp on cpp.Conta_Receber = contas_Receber.conta_receber   
		inner join Empresas f on f.empresa = contas_Receber.empresa    
		inner join Tipos_Documentos td on td.Tipo_Documento = contas_Receber.Tipo_Documento    
		inner join Tipos_Pagamentos tp on tp.Tipo_Pagamento = contas_Receber.Tipo_Pagamento   
		left outer join clientes cl on cl.cliente = contas_Receber.cliente
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [vw_Contas_Receber_Baixadas]  
as 
SELECT
	cp.Conta_receber
	, cpp.Conta_Receber_Parcela
	, dbo.Contas_Receber_mov.Conta_Receber_Mov
	, cp.Empresa
	, cp.Cliente
	, cp.Numero_Documento
	, cp.Tipo_Documento AS 'Tipo_Documento_Titulo'
	, cp.Tipo_Pagamento AS 'Tipo_Pagamento_Titulo'
	, cp.Valor_Original AS 'Valor_Original_Titulo'
	, cp.Valor_Pago AS 'Valor_Pago_Titulo'
	, cp.Data_Cadastro AS 'Data_Cadastro_Titulo'
	, cpp.Parcela
	, cpp.Data_Cadastro
	, cpp.Data_Emissao
	, cpp.Data_Vencimento
	, cpp.Valor_Original
	, cpp.Valor_Receber
	, cpp.Parcela_Paga
	, Contas_Receber_mov.Tipo_Movimento
	, Contas_Receber_mov.Data_Movimento
	, Contas_Receber_mov.Valor_Pago
	, Contas_Receber_mov.Numero_Lote
	, cpp.Protesto
	, Contas_Receber_mov.Protesto_Pago
	, Contas_Receber_mov.Protesto_Pago_Data
	, cl.Razao_Social AS 'Razao_Social_Cliente'
	, F.Razao_Social AS 'Razao_Social_Filial'
	FROM dbo.Contas_Receber_mov 
		INNER JOIN dbo.Contas_Receber AS cp ON cp.Conta_receber = dbo.Contas_Receber_mov.Conta_Receber 
		INNER JOIN dbo.Contas_Receber_Parcela AS cpp ON cpp.Conta_Receber = cp.Conta_receber AND cpp.Conta_Receber_Parcela = dbo.Contas_Receber_mov.Conta_Receber_Parcela 
		INNER JOIN dbo.Empresas AS f ON f.Empresa = cp.Empresa 
		LEFT OUTER JOIN dbo.Clientes AS cl ON cl.Cliente = cp.Cliente
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [vw_Retornar_Menus_Items_Acessos]
as
select distinct mi.Menu_Item, mi.Descricao, mi.Nivel, mi.ParentNivel, mi.NameSpace, mi.Formulario, ua.Usuario, mo.Modulo
	from Menus_Itens mi
		inner join Modulos_Menus mm on mm.menu_item = mi.Menu_item
		inner join modulos mo on mo.modulo = mm.modulo
		left outer join Usuarios_Acessos ua on ua.Modulo = mm.Modulo 
	where 
		    ua.Menu_item is null
		and mi.ativo = 1
		and mi.ParentNivel not in (select Menu_Item from menus_itens where ativo = 0 and (nivel != 0 or ParentNivel != 0))
Union
select distinct mi.Menu_Item, mi.Descricao, mi.Nivel, mi.ParentNivel, mi.NameSpace, mi.Formulario, ua.Usuario, mo.Modulo
	from Menus_Itens mi
		inner join Modulos_Menus mm on mm.menu_item = mi.Menu_item
		inner join modulos mo on mo.modulo = mm.modulo
		left outer join Usuarios_Acessos ua on ua.Modulo = mm.Modulo and ua.Menu_item = mi.Menu_item
	where mi.ativo = 1
and mi.ParentNivel not in (select Menu_Item from menus_itens where ativo = 0 and (nivel != 0 or ParentNivel != 0))










GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [vw_Retornar_Modulos_Acessos]
AS
SELECT DISTINCT mo.Modulo, mo.Descricao_Modulo, ua.Usuario, mo.Caminho_Imagem
FROM         dbo.Menus_Itens AS mi INNER JOIN
                      dbo.Modulos_Menus AS mm ON mm.Menu_Item = mi.Menu_Item INNER JOIN
                      dbo.Modulos AS mo ON mo.Modulo = mm.Modulo INNER JOIN
                      dbo.Usuarios_Acessos AS ua ON ua.Modulo = mm.Modulo
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Boletos] ON [Boletos_Gerados]
(
	[Nota_Fiscal_Duplicata] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Boletos_Instrucoes] ON [Boletos_Instrucoes]
(
	[Banco] ASC,
	[Codigo_Instrucao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Clientes_Contatos] ON [Clientes_Contatos]
(
	[Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [IX_Contadores_Nome_Contador] ON [Contadores]
(
	[Nome_Contador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Contas_Correntes_Empresa] ON [Contas_Correntes]
(
	[Empresa] ASC,
	[Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contas_Pagar_Mov_Conta_pagar] ON [Contas_Pagar_Mov]
(
	[Conta_pagar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contas_Pagar_Mov_conta_pagar_parcela] ON [Contas_Pagar_Mov]
(
	[Conta_pagar_parcela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_contas_pagar_parcela_Conta_Pagar] ON [Contas_Pagar_Parcela]
(
	[Conta_Pagar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contas_Receber_mov_Conta_Receber] ON [Contas_Receber_mov]
(
	[Conta_Receber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contas_Receber_mov_Conta_Receber_parcela] ON [Contas_Receber_mov]
(
	[Conta_Receber_Parcela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Contas_Receber_Parcela_Conta_Receber] ON [Contas_Receber_Parcela]
(
	[Conta_Receber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Estoques] ON [Estoques]
(
	[Empresa] ASC,
	[Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [I_Idiomas_Idioma] ON [Idiomas]
(
	[Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Menus_Itens_Relatorios_Menu_Item] ON [Menus_Itens_Relatorios]
(
	[Menu_Item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Nota_Fiscal_Numero_Nota] ON [Notas_Fiscais]
(
	[Numero_Nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Notas_Fiscais_Lotes_Itens] ON [Notas_Fiscais_Lotes_Itens]
(
	[Nota_Fiscal_Lote] ASC,
	[Nota_Fiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Produtos_Tributos] ON [Produtos_Tributos]
(
	[Produto] ASC,
	[Empresa] ASC,
	[Origem] ASC,
	[Destino] ASC,
	[Inicio_Vigencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Bancos] ADD  CONSTRAINT [DF_Bancos_Inativo_1]  DEFAULT ((1)) FOR [Inativo]
GO
ALTER TABLE [Boletos_Especies_Documentos] ADD  CONSTRAINT [DF_EspeciesDoc_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Boletos_Gerados] ADD  CONSTRAINT [DF_Boletos_ArquivoRemessao_Enviado]  DEFAULT ((0)) FOR [ArquivoRemessao_Enviado]
GO
ALTER TABLE [Boletos_Gerados] ADD  CONSTRAINT [DF_Boletos_Boleto_Impresso]  DEFAULT ((0)) FOR [Boleto_Impresso]
GO
ALTER TABLE [Boletos_Gerados] ADD  CONSTRAINT [DF_Boletos_Gerados_Boleto_Pago]  DEFAULT ((0)) FOR [Boleto_Pago]
GO
ALTER TABLE [Categorias_Produtos] ADD  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [CFOPS] ADD  CONSTRAINT [DF_CFOPS_Entrada]  DEFAULT ((0)) FOR [Entrada]
GO
ALTER TABLE [CFOPS] ADD  CONSTRAINT [DF_CFOPS_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF__CFOPS_Reg__Com_S__05AEC38C]  DEFAULT ((0)) FOR [Com_ST]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF__CFOPS_Reg__Sem_S__06A2E7C5]  DEFAULT ((0)) FOR [Sem_ST]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF_CFOPS_Regras_Com_Reducao]  DEFAULT ((0)) FOR [Com_Reducao]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF_CFOPS_Regras_Sem_Reducao]  DEFAULT ((0)) FOR [Sem_Reducao]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF__CFOPS_Reg__Consu__07970BFE]  DEFAULT ((0)) FOR [Consumidor_Final]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF__CFOPS_Reg__Reven__088B3037]  DEFAULT ((0)) FOR [Revenda]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF__CFOPS_Reg__Bonif__0D4FE554]  DEFAULT ((0)) FOR [Bonificacao]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF_CFOPS_Regras_Remessa_Deposito]  DEFAULT ((0)) FOR [Remessa_Deposito]
GO
ALTER TABLE [CFOPS_Regras] ADD  CONSTRAINT [DF_CFOPS_Regras_Devolucao]  DEFAULT ((0)) FOR [Devolucao]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_PessoaFisica]  DEFAULT ((0)) FOR [Pessoa_Juridica]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF__Clientes__Data_C__7B4643B2]  DEFAULT (getdate()) FOR [Data_Cadastro]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF__Clientes__Data_A__7C3A67EB]  DEFAULT (getdate()) FOR [Data_Atualizacao]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Tipo_Cliente]  DEFAULT ((0)) FOR [Tipo_Cliente]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Tipo_Fornecedor]  DEFAULT ((0)) FOR [Tipo_Fornecedor]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Reducao_ICMS]  DEFAULT ((0)) FOR [Reducao_ICMS]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Nao_Incide_ST]  DEFAULT ((0)) FOR [Nao_Incide_ST]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Consumidor_Final]  DEFAULT ((0)) FOR [Consumidor_Final]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Inadimplante]  DEFAULT ((0)) FOR [Inadimplente]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF_Clientes_Regime_Normal_RPA]  DEFAULT ((0)) FOR [Regime_Normal_RPA]
GO
ALTER TABLE [Clientes] ADD  CONSTRAINT [DF__Clientes__Ativo__7D2E8C24]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Condicoes_Pagamento_Pedido] ADD  CONSTRAINT [DF_Condicoes_Pagamento_Pedido_Parcelado]  DEFAULT ((0)) FOR [Parcelado]
GO
ALTER TABLE [Condicoes_Pagamento_Pedido] ADD  CONSTRAINT [DF_Condicoes_Pagamento_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Contas_Correntes_Boletos_Instrucoes] ADD  CONSTRAINT [DF_Contas_Correntes_Boletos_Instrucoes_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Contas_Pagar] ADD  CONSTRAINT [DF__f_Contas___Data___5BCD9859]  DEFAULT (getdate()) FOR [Data_Cadastro]
GO
ALTER TABLE [Contas_Pagar_Mov] ADD  CONSTRAINT [DF__f_Contas___Data___618671AF]  DEFAULT (getdate()) FOR [Data_Movimento]
GO
ALTER TABLE [Contas_Pagar_Parcela] ADD  CONSTRAINT [DF_f_Conta_Pagar_Parcela_Parcela_Paga]  DEFAULT ((0)) FOR [Parcela_Paga]
GO
ALTER TABLE [Contas_Receber] ADD  CONSTRAINT [DF__f_Contas___Data___57FD0775]  DEFAULT (getdate()) FOR [Data_Cadastro]
GO
ALTER TABLE [Contas_Receber_mov] ADD  CONSTRAINT [DF__f_Contas___Data___6462DE5A]  DEFAULT (getdate()) FOR [Data_Movimento]
GO
ALTER TABLE [Contas_Receber_mov] ADD  CONSTRAINT [DF_Contas_Receber_mov_Protestado_Pago]  DEFAULT ((0)) FOR [Protesto_Pago]
GO
ALTER TABLE [Contas_Receber_Parcela] ADD  CONSTRAINT [DF_Contas_Receber_Parcela_Parcela_Paga]  DEFAULT ((0)) FOR [Parcela_Paga]
GO
ALTER TABLE [Contas_Receber_Parcela] ADD  CONSTRAINT [DF_Contas_Receber_Parcela_Protesto]  DEFAULT ((0)) FOR [Protesto]
GO
ALTER TABLE [Departamentos] ADD  CONSTRAINT [DF_Departamentos_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF_Empresas_NFP_Ativar_Recurso]  DEFAULT ((0)) FOR [NFP_Ativar_Recurso]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF_Empresas_NFE_Ativar_Recurso]  DEFAULT ((0)) FOR [NFE_Ativar_Recurso]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF_Empresas_NFE_EnvioXML_Ativar_Recurso]  DEFAULT ((0)) FOR [NFE_EnvioXML_Ativar_Recurso]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF_Empresas_NFE_EnvioXML_Servidor_Autenticacao]  DEFAULT ((0)) FOR [NFE_EnvioXML_Servidor_Autenticacao]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF_Empresas_DataEntrega_Igual_DataSistema]  DEFAULT ((0)) FOR [DataEntrega_Igual_DataSistema]
GO
ALTER TABLE [Empresas] ADD  CONSTRAINT [DF__Filiais__Ativo__44EA3301]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Escolaridades] ADD  CONSTRAINT [DF_Escolaridade_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Funcionarios] ADD  CONSTRAINT [DF_Funcionarios_Ativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Funcionarios] ADD  CONSTRAINT [DF__Funcionar__Motor__322C6448]  DEFAULT ((0)) FOR [Motorista]
GO
ALTER TABLE [Grupos_Produtos] ADD  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Menus_Itens] ADD  CONSTRAINT [DF__Menus_Ite__Nivel__3C54ED00]  DEFAULT ((0)) FOR [Nivel]
GO
ALTER TABLE [Menus_Itens] ADD  CONSTRAINT [DF__Menus_Ite__Paren__3D491139]  DEFAULT ((1)) FOR [ParentNivel]
GO
ALTER TABLE [Menus_Itens] ADD  CONSTRAINT [DF__Menus_Ite__Ativo__3E3D3572]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [Menus_Itens_Relatorios] ADD  CONSTRAINT [DF_Menus_Itens_Relatorios_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [Menus_Itens_Relatorios] ADD  DEFAULT ((1)) FOR [TodosReg_Enable]
GO
ALTER TABLE [Menus_Itens_Relatorios] ADD  DEFAULT ((1)) FOR [RegAtual_Enable]
GO
ALTER TABLE [Menus_Itens_Relatorios] ADD  DEFAULT ((0)) FOR [Value_Enable]
GO
ALTER TABLE [Modulos] ADD  CONSTRAINT [DF__Modulos__Ativo__4C8B54C9]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Table_1_Entrada]  DEFAULT ((0)) FOR [Tipo_Entrada]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_Tipo_Saida]  DEFAULT ((0)) FOR [Tipo_Saida]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_Impressa]  DEFAULT ((0)) FOR [Impressa]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_ICMS_Frete]  DEFAULT ((0)) FOR [ICMS_Frete]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_ICMS_Seguro]  DEFAULT ((0)) FOR [ICMS_Seguro]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF__Notas_Fis__Estoq__33208881]  DEFAULT ((0)) FOR [Estoque_Baixado]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF__Notas_Fis__Consi__50B0EB68]  DEFAULT ((0)) FOR [Consiliacao_Financeira_Realizada]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_Arquivo_Exportado]  DEFAULT ((0)) FOR [Exportacao_NFp]
GO
ALTER TABLE [Notas_Fiscais] ADD  CONSTRAINT [DF_Notas_Fiscais_Exportacao_NFe]  DEFAULT ((0)) FOR [Exportacao_NFe]
GO
ALTER TABLE [Notas_Fiscais_Duplicatas] ADD  CONSTRAINT [DF_Notas_Fiscais_Duplicatas_Numero_Parcela]  DEFAULT ((1)) FOR [Numero_Parcela]
GO
ALTER TABLE [Notas_Fiscais_Duplicatas] ADD  CONSTRAINT [DF__Notas_Fis__Impre__30441BD6]  DEFAULT ((0)) FOR [Impressa]
GO
ALTER TABLE [Notas_Fiscais_Lotes] ADD  CONSTRAINT [DF__Notas_Fis__Retor__64A2D57C]  DEFAULT ((0)) FOR [Retorno_Capturado]
GO
ALTER TABLE [Notas_Fiscais_Lotes] ADD  CONSTRAINT [DF_Notas_Fiscais_Lotes_Tipo_NFP]  DEFAULT ((0)) FOR [Tipo_NFP]
GO
ALTER TABLE [Notas_Fiscais_Lotes] ADD  CONSTRAINT [DF_Notas_Fiscais_Lotes_Tipo_NFe]  DEFAULT ((0)) FOR [Tipo_NFe]
GO
ALTER TABLE [Notas_Fiscais_Lotes] ADD  CONSTRAINT [DF_Notas_Fiscais_Lotes_Danfe_Impresso]  DEFAULT ((0)) FOR [Danfe_Impresso]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Mensagens] ADD  DEFAULT (getdate()) FOR [Data_Historico]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_Gera_NF]  DEFAULT ((0)) FOR [Gera_NF]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_NF_Gerada]  DEFAULT ((0)) FOR [NF_Gerada]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_Cancelado]  DEFAULT ((0)) FOR [Cancelado]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_Bonificacao]  DEFAULT ((0)) FOR [Bonificacao]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_Remessa_Deposito]  DEFAULT ((0)) FOR [Remessa_Deposito]
GO
ALTER TABLE [Pedidos] ADD  CONSTRAINT [DF_Pedidos_Devolucao]  DEFAULT ((0)) FOR [Devolucao]
GO
ALTER TABLE [Produtos] ADD  CONSTRAINT [DF_Produtos_Comissionado]  DEFAULT ((0)) FOR [Comissionado]
GO
ALTER TABLE [Produtos] ADD  CONSTRAINT [DF_Produtos_Qtde_Caixa]  DEFAULT ((0)) FOR [Qtde_Caixa]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_ICMS_Estado]  DEFAULT ((0)) FOR [ICMS_Estado]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_Reducao_ICMS]  DEFAULT ((0)) FOR [Reducao_ICMS]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_Reducao_ICMS_Cliente]  DEFAULT ((0)) FOR [Reducao_ICMS_Cliente]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_Reducao_ICMS_Geral]  DEFAULT ((0)) FOR [Reducao_ICMS_Geral]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_Substituicao_Tributaria]  DEFAULT ((0)) FOR [Substituicao_Tributaria]
GO
ALTER TABLE [Produtos_Tributos] ADD  CONSTRAINT [DF_Produtos_Tributos_Reducao_ST]  DEFAULT ((0)) FOR [Reducao_ST]
GO
ALTER TABLE [Regimes_Tributarios] ADD  CONSTRAINT [DF_Regime_Tributario_Calcular_Credito_ICMS]  DEFAULT ((0)) FOR [Calcular_Credito_ICMS]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_ICMS]  DEFAULT ((0)) FOR [Cobranca_ICMS]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_Substituicao_Tributaria]  DEFAULT ((0)) FOR [Aplicacao_Substituicao_Tributaria]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_Aplicacao_Reducao_ICMS]  DEFAULT ((0)) FOR [Aplicacao_Reducao_ICMS]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_Suspencao]  DEFAULT ((0)) FOR [Suspencao]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_Direrimento]  DEFAULT ((0)) FOR [Direrimento]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_ICMS_Cobrado_Anteriormente]  DEFAULT ((0)) FOR [ICMS_Cobrado_Anteriormente]
GO
ALTER TABLE [Situacoes_Tributaria] ADD  CONSTRAINT [DF_Situacoes_Tributaria_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [SubGrupos_Produtos] ADD  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tabelas_Precos] ADD  CONSTRAINT [DF_Tabelas_Precos_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Contas] ADD  CONSTRAINT [DF_Tipos_Contas_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Documentos] ADD  CONSTRAINT [DF__f_Tipos_D__Ativo__55209ACA]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Movimentos] ADD  CONSTRAINT [DF__f_Tipos_M__Ativo__49AEE81E]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Movimentos_Estoque] ADD  CONSTRAINT [DF_Tipos_Movimentos_Estoque_Entrada]  DEFAULT ((0)) FOR [Entrada]
GO
ALTER TABLE [Tipos_Movimentos_Estoque] ADD  CONSTRAINT [DF_Tipos_Movimentos_Estoque_Saida]  DEFAULT ((0)) FOR [Saida]
GO
ALTER TABLE [Tipos_Movimentos_Estoque] ADD  CONSTRAINT [DF_Tipos_Movimentos_Estoque_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Operacoes] ADD  CONSTRAINT [DF_Tipos_Operacoes_Atualiza_Estoque]  DEFAULT ((0)) FOR [Atualiza_Estoque]
GO
ALTER TABLE [Tipos_Pagamentos] ADD  CONSTRAINT [DF__f_Tipos_P__Ativo__4119A21D]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Tipos_Vinculos] ADD  CONSTRAINT [DF_Tipos_Vinculos_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Transportadoras] ADD  CONSTRAINT [DF_Table_1_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Transportadoras] ADD  DEFAULT ((0)) FOR [Transportadora_Propria]
GO
ALTER TABLE [Unidades_Medidas] ADD  CONSTRAINT [DF_Unidades_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Usuarios] ADD  CONSTRAINT [DF__Usuarios__Ativo__4F67C174]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [Usuarios] ADD  CONSTRAINT [DF_Usuarios_Adm]  DEFAULT ((0)) FOR [Adm]
GO
ALTER TABLE [Vendedores] ADD  CONSTRAINT [DF_Vendedores_Inativo]  DEFAULT ((0)) FOR [Inativo]
GO
ALTER TABLE [Boletos_Especies_Documentos]  WITH CHECK ADD  CONSTRAINT [FK_EspeciesDoc_Bancos] FOREIGN KEY([Banco])
REFERENCES [Bancos] ([Banco])
ON UPDATE CASCADE
GO
ALTER TABLE [Boletos_Especies_Documentos] CHECK CONSTRAINT [FK_EspeciesDoc_Bancos]
GO
ALTER TABLE [Boletos_Gerados]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Contas_Correntes] FOREIGN KEY([Conta_Corrente])
REFERENCES [Contas_Correntes] ([Conta_Corrente])
GO
ALTER TABLE [Boletos_Gerados] CHECK CONSTRAINT [FK_Boletos_Contas_Correntes]
GO
ALTER TABLE [Boletos_Gerados]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Gerados_Boletos_Especies_Documentos] FOREIGN KEY([Banco], [EspecieDoc])
REFERENCES [Boletos_Especies_Documentos] ([Banco], [EspecieDoc])
ON UPDATE CASCADE
GO
ALTER TABLE [Boletos_Gerados] CHECK CONSTRAINT [FK_Boletos_Gerados_Boletos_Especies_Documentos]
GO
ALTER TABLE [Boletos_Gerados]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Gerados_Boletos_Tipos_Ocorrencias] FOREIGN KEY([Boleto_Tipo_Ocorrencia])
REFERENCES [Boletos_Tipos_Ocorrencias] ([Boleto_Tipo_Correncia])
GO
ALTER TABLE [Boletos_Gerados] CHECK CONSTRAINT [FK_Boletos_Gerados_Boletos_Tipos_Ocorrencias]
GO
ALTER TABLE [Boletos_Gerados]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Gerados_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Boletos_Gerados] CHECK CONSTRAINT [FK_Boletos_Gerados_Empresas]
GO
ALTER TABLE [Boletos_Gerados]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Notas_Fiscais_Duplicatas] FOREIGN KEY([Nota_Fiscal_Duplicata])
REFERENCES [Notas_Fiscais_Duplicatas] ([Nota_Fiscal_Duplicata])
GO
ALTER TABLE [Boletos_Gerados] CHECK CONSTRAINT [FK_Boletos_Notas_Fiscais_Duplicatas]
GO
ALTER TABLE [Boletos_Gerados_Instrucoes]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Gerados_Instrucoes_Boletos_Gerados] FOREIGN KEY([Boleto_Gerado])
REFERENCES [Boletos_Gerados] ([Boleto_Gerado])
GO
ALTER TABLE [Boletos_Gerados_Instrucoes] CHECK CONSTRAINT [FK_Boletos_Gerados_Instrucoes_Boletos_Gerados]
GO
ALTER TABLE [Boletos_Gerados_Instrucoes]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Duplicatas_Instrucoes_Boletos_Instrucoes] FOREIGN KEY([Boleto_Instrucao])
REFERENCES [Boletos_Instrucoes] ([Boleto_Instrucao])
GO
ALTER TABLE [Boletos_Gerados_Instrucoes] CHECK CONSTRAINT [FK_Notas_Fiscais_Duplicatas_Instrucoes_Boletos_Instrucoes]
GO
ALTER TABLE [Boletos_Instrucoes]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Instrucoes_Bancos] FOREIGN KEY([Banco])
REFERENCES [Bancos] ([Banco])
ON UPDATE CASCADE
GO
ALTER TABLE [Boletos_Instrucoes] CHECK CONSTRAINT [FK_Boletos_Instrucoes_Bancos]
GO
ALTER TABLE [Boletos_Tipos_Ocorrencias]  WITH CHECK ADD  CONSTRAINT [FK_Boletos_Tipos_Ocorrencias_Bancos] FOREIGN KEY([Banco])
REFERENCES [Bancos] ([Banco])
GO
ALTER TABLE [Boletos_Tipos_Ocorrencias] CHECK CONSTRAINT [FK_Boletos_Tipos_Ocorrencias_Bancos]
GO
ALTER TABLE [Categorias_Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Categorias_Produtos_SubGrupos_Produtos] FOREIGN KEY([SubGrupo_Produto])
REFERENCES [SubGrupos_Produtos] ([SubGrupo_Produto])
GO
ALTER TABLE [Categorias_Produtos] CHECK CONSTRAINT [FK_Categorias_Produtos_SubGrupos_Produtos]
GO
ALTER TABLE [CFOPS]  WITH CHECK ADD  CONSTRAINT [FK_CFOPS_Tipos_Operacoes] FOREIGN KEY([Tipo_Operacao])
REFERENCES [Tipos_Operacoes] ([Tipo_Operacao])
GO
ALTER TABLE [CFOPS] CHECK CONSTRAINT [FK_CFOPS_Tipos_Operacoes]
GO
ALTER TABLE [CFOPS_Regras]  WITH CHECK ADD  CONSTRAINT [FK_CFOPs_CFOPs_Regras] FOREIGN KEY([CFOP])
REFERENCES [CFOPS] ([CFOP])
GO
ALTER TABLE [CFOPS_Regras] CHECK CONSTRAINT [FK_CFOPs_CFOPs_Regras]
GO
ALTER TABLE [CFOPS_Regras]  WITH CHECK ADD  CONSTRAINT [FK_CFOPs_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [CFOPS_Regras] CHECK CONSTRAINT [FK_CFOPs_Empresas]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Estados_Civis] FOREIGN KEY([Estado_Civil])
REFERENCES [Estados_Civis] ([Estado_Civil])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Estados_Civis]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Paises] FOREIGN KEY([Cod_Pais_Correspondencia_IBGE])
REFERENCES [Paises] ([Codigo_IBGE])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Paises]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Sexos] FOREIGN KEY([Sexo])
REFERENCES [Sexos] ([Sexo])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Sexos]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Tabelas_Precos] FOREIGN KEY([Tabela_Preco])
REFERENCES [Tabelas_Precos] ([Tabela_Preco])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Tabelas_Precos]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Tipos_Produtos_Fornece] FOREIGN KEY([Tipo_Produto_Fornece])
REFERENCES [Tipos_Produtos_Fornece] ([Tipo_Produto_Fornece])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Tipos_Produtos_Fornece]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Transportadoras] FOREIGN KEY([Transportadora])
REFERENCES [Transportadoras] ([Transportadora])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Transportadoras]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Vendedores] FOREIGN KEY([Vendedor])
REFERENCES [Vendedores] ([Vendedor])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Clientes_Vendedores]
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Forma_pgto_pgto] FOREIGN KEY([Forma_Pagamento])
REFERENCES [Formas_Pagamentos] ([Forma_Pagamento])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Forma_pgto_pgto]
GO
ALTER TABLE [Clientes_Contatos]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Contatos_Cliente] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Clientes_Contatos] CHECK CONSTRAINT [FK_Clientes_Contatos_Cliente]
GO
ALTER TABLE [Condicoes_Pagamento_Pedido_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Condicoes_Pagamentos_Pedidos_Itens_Condicoes_Pagamento_Pedido] FOREIGN KEY([Condicao_Pagamento_Pedido])
REFERENCES [Condicoes_Pagamento_Pedido] ([Condicao_Pagamento_Pedido])
GO
ALTER TABLE [Condicoes_Pagamento_Pedido_Itens] CHECK CONSTRAINT [FK_Condicoes_Pagamentos_Pedidos_Itens_Condicoes_Pagamento_Pedido]
GO
ALTER TABLE [Contas_Correntes]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Correntes_Bancos] FOREIGN KEY([Banco])
REFERENCES [Bancos] ([Banco])
GO
ALTER TABLE [Contas_Correntes] CHECK CONSTRAINT [FK_Contas_Correntes_Bancos]
GO
ALTER TABLE [Contas_Correntes]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Correntes_Contas_Correntes] FOREIGN KEY([Conta_Corrente])
REFERENCES [Contas_Correntes] ([Conta_Corrente])
GO
ALTER TABLE [Contas_Correntes] CHECK CONSTRAINT [FK_Contas_Correntes_Contas_Correntes]
GO
ALTER TABLE [Contas_Correntes]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Correntes_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Contas_Correntes] CHECK CONSTRAINT [FK_Contas_Correntes_Empresas]
GO
ALTER TABLE [Contas_Correntes_Boletos_Instrucoes]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Correntes_Boletos_Instrucoes_Boletos_Instrucoes] FOREIGN KEY([Boleto_Instrucao])
REFERENCES [Boletos_Instrucoes] ([Boleto_Instrucao])
GO
ALTER TABLE [Contas_Correntes_Boletos_Instrucoes] CHECK CONSTRAINT [FK_Contas_Correntes_Boletos_Instrucoes_Boletos_Instrucoes]
GO
ALTER TABLE [Contas_Correntes_Boletos_Instrucoes]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Correntes_Boletos_Instrucoes_Contas_Correntes] FOREIGN KEY([Conta_Corrente])
REFERENCES [Contas_Correntes] ([Conta_Corrente])
GO
ALTER TABLE [Contas_Correntes_Boletos_Instrucoes] CHECK CONSTRAINT [FK_Contas_Correntes_Boletos_Instrucoes_Contas_Correntes]
GO
ALTER TABLE [Contas_Pagar]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_Pagar_Cliente] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Contas_Pagar] CHECK CONSTRAINT [FK_f_Contas_a_Pagar_Cliente]
GO
ALTER TABLE [Contas_Pagar]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_Pagar_Filial] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Contas_Pagar] CHECK CONSTRAINT [FK_f_Contas_a_Pagar_Filial]
GO
ALTER TABLE [Contas_Pagar]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_Pagar_Tipo_Documento] FOREIGN KEY([Tipo_Documento])
REFERENCES [Tipos_Documentos] ([Tipo_Documento])
GO
ALTER TABLE [Contas_Pagar] CHECK CONSTRAINT [FK_f_Contas_a_Pagar_Tipo_Documento]
GO
ALTER TABLE [Contas_Pagar_Mov]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Pagar_Mov_Contas_Pagar_Parcela] FOREIGN KEY([Conta_pagar_parcela])
REFERENCES [Contas_Pagar_Parcela] ([Conta_Pagar_Parcela])
GO
ALTER TABLE [Contas_Pagar_Mov] CHECK CONSTRAINT [FK_Contas_Pagar_Mov_Contas_Pagar_Parcela]
GO
ALTER TABLE [Contas_Pagar_Mov]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_pagar_mov_Conta_a_pagar] FOREIGN KEY([Conta_pagar])
REFERENCES [Contas_Pagar] ([Conta_pagar])
GO
ALTER TABLE [Contas_Pagar_Mov] CHECK CONSTRAINT [FK_f_Contas_a_pagar_mov_Conta_a_pagar]
GO
ALTER TABLE [Contas_Pagar_Mov]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_pagar_mov_Tipo_Movimento] FOREIGN KEY([Tipo_Movimento])
REFERENCES [Tipos_Movimentos] ([Tipo_Movimento])
GO
ALTER TABLE [Contas_Pagar_Mov] CHECK CONSTRAINT [FK_f_Contas_a_pagar_mov_Tipo_Movimento]
GO
ALTER TABLE [Contas_Pagar_Parcela]  WITH CHECK ADD  CONSTRAINT [FK_contas_pagar_parcela_Conta_pagar] FOREIGN KEY([Conta_Pagar])
REFERENCES [Contas_Pagar] ([Conta_pagar])
GO
ALTER TABLE [Contas_Pagar_Parcela] CHECK CONSTRAINT [FK_contas_pagar_parcela_Conta_pagar]
GO
ALTER TABLE [Contas_Receber]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Receber_Notas_Fiscais] FOREIGN KEY([Nota_Fiscal])
REFERENCES [Notas_Fiscais] ([Nota_Fiscal])
GO
ALTER TABLE [Contas_Receber] CHECK CONSTRAINT [FK_Contas_Receber_Notas_Fiscais]
GO
ALTER TABLE [Contas_Receber]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_Cliente] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Contas_Receber] CHECK CONSTRAINT [FK_f_Contas_a_receber_Cliente]
GO
ALTER TABLE [Contas_Receber]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_Filial] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Contas_Receber] CHECK CONSTRAINT [FK_f_Contas_a_receber_Filial]
GO
ALTER TABLE [Contas_Receber]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_Tipo_Documento] FOREIGN KEY([Tipo_Documento])
REFERENCES [Tipos_Documentos] ([Tipo_Documento])
GO
ALTER TABLE [Contas_Receber] CHECK CONSTRAINT [FK_f_Contas_a_receber_Tipo_Documento]
GO
ALTER TABLE [Contas_Receber]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_Tipo_Pagamento] FOREIGN KEY([Tipo_Pagamento])
REFERENCES [Tipos_Pagamentos] ([Tipo_Pagamento])
GO
ALTER TABLE [Contas_Receber] CHECK CONSTRAINT [FK_f_Contas_a_receber_Tipo_Pagamento]
GO
ALTER TABLE [Contas_Receber_mov]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Receber_mov_Contas_Receber_Parcela] FOREIGN KEY([Conta_Receber_Parcela])
REFERENCES [Contas_Receber_Parcela] ([Conta_Receber_Parcela])
GO
ALTER TABLE [Contas_Receber_mov] CHECK CONSTRAINT [FK_Contas_Receber_mov_Contas_Receber_Parcela]
GO
ALTER TABLE [Contas_Receber_mov]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_mov_Conta_a_receber] FOREIGN KEY([Conta_Receber])
REFERENCES [Contas_Receber] ([Conta_receber])
GO
ALTER TABLE [Contas_Receber_mov] CHECK CONSTRAINT [FK_f_Contas_a_receber_mov_Conta_a_receber]
GO
ALTER TABLE [Contas_Receber_mov]  WITH CHECK ADD  CONSTRAINT [FK_f_Contas_a_receber_mov_f_Tipos_movimentos] FOREIGN KEY([Tipo_Movimento])
REFERENCES [Tipos_Movimentos] ([Tipo_Movimento])
GO
ALTER TABLE [Contas_Receber_mov] CHECK CONSTRAINT [FK_f_Contas_a_receber_mov_f_Tipos_movimentos]
GO
ALTER TABLE [Contas_Receber_Parcela]  WITH CHECK ADD  CONSTRAINT [FK_Contas_Receber_Parcela_Contas_Receber] FOREIGN KEY([Conta_Receber])
REFERENCES [Contas_Receber] ([Conta_receber])
GO
ALTER TABLE [Contas_Receber_Parcela] CHECK CONSTRAINT [FK_Contas_Receber_Parcela_Contas_Receber]
GO
ALTER TABLE [Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Regimes_Tributarios] FOREIGN KEY([Regime_Tributario])
REFERENCES [Regimes_Tributarios] ([Regime_Tributario])
GO
ALTER TABLE [Empresas] CHECK CONSTRAINT [FK_Empresas_Regimes_Tributarios]
GO
ALTER TABLE [Estoques]  WITH CHECK ADD  CONSTRAINT [FK_Estoques_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Estoques] CHECK CONSTRAINT [FK_Estoques_Produtos]
GO
ALTER TABLE [Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Departamentos] FOREIGN KEY([Departamento])
REFERENCES [Departamentos] ([Departamento])
GO
ALTER TABLE [Funcionarios] CHECK CONSTRAINT [FK_Funcionarios_Departamentos]
GO
ALTER TABLE [Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Escolaridade] FOREIGN KEY([Escolaridade])
REFERENCES [Escolaridades] ([Escolaridade])
GO
ALTER TABLE [Funcionarios] CHECK CONSTRAINT [FK_Funcionarios_Escolaridade]
GO
ALTER TABLE [Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Estados_Civis] FOREIGN KEY([Estado_Civil])
REFERENCES [Estados_Civis] ([Estado_Civil])
GO
ALTER TABLE [Funcionarios] CHECK CONSTRAINT [FK_Funcionarios_Estados_Civis]
GO
ALTER TABLE [Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Tipos_Contas] FOREIGN KEY([Tipo_Conta])
REFERENCES [Tipos_Contas] ([Tipo_Conta])
GO
ALTER TABLE [Funcionarios] CHECK CONSTRAINT [FK_Funcionarios_Tipos_Contas]
GO
ALTER TABLE [Funcionarios]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Tipos_Vinculos] FOREIGN KEY([Tipo_Vinculo])
REFERENCES [Tipos_Vinculos] ([Tipo_Vinculo])
GO
ALTER TABLE [Funcionarios] CHECK CONSTRAINT [FK_Funcionarios_Tipos_Vinculos]
GO
ALTER TABLE [Funcionarios_Dependentes]  WITH CHECK ADD  CONSTRAINT [FK_Funcionarios_Dependentes_Funcionarios] FOREIGN KEY([Funcionario])
REFERENCES [Funcionarios] ([Funcionario])
GO
ALTER TABLE [Funcionarios_Dependentes] CHECK CONSTRAINT [FK_Funcionarios_Dependentes_Funcionarios]
GO
ALTER TABLE [ICMS_Estados]  WITH CHECK ADD  CONSTRAINT [FK_ICMS_Estados_Estados] FOREIGN KEY([Origem])
REFERENCES [Estados] ([Estado])
GO
ALTER TABLE [ICMS_Estados] CHECK CONSTRAINT [FK_ICMS_Estados_Estados]
GO
ALTER TABLE [ICMS_Estados]  WITH CHECK ADD  CONSTRAINT [FK_ICMS_Estados_Estados1] FOREIGN KEY([Destino])
REFERENCES [Estados] ([Estado])
GO
ALTER TABLE [ICMS_Estados] CHECK CONSTRAINT [FK_ICMS_Estados_Estados1]
GO
ALTER TABLE [Menus_Itens_Favoritos]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Itens_Favoritos_Grupos_Favoritos] FOREIGN KEY([Grupo_Favorito])
REFERENCES [Grupos_Favoritos] ([Grupo_Favorito])
GO
ALTER TABLE [Menus_Itens_Favoritos] CHECK CONSTRAINT [FK_Menus_Itens_Favoritos_Grupos_Favoritos]
GO
ALTER TABLE [Menus_Itens_Favoritos]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Itens_Favoritos_Menus_Itens] FOREIGN KEY([Menu_Item])
REFERENCES [Menus_Itens] ([Menu_Item])
GO
ALTER TABLE [Menus_Itens_Favoritos] CHECK CONSTRAINT [FK_Menus_Itens_Favoritos_Menus_Itens]
GO
ALTER TABLE [Menus_Itens_Favoritos]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Itens_Favoritos_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [Usuarios] ([Usuario])
GO
ALTER TABLE [Menus_Itens_Favoritos] CHECK CONSTRAINT [FK_Menus_Itens_Favoritos_Usuarios]
GO
ALTER TABLE [Menus_Itens_Relatorios]  WITH NOCHECK ADD  CONSTRAINT [FK_Menus_Itens_Relatorios_Menus_Itens] FOREIGN KEY([Menu_Item])
REFERENCES [Menus_Itens] ([Menu_Item])
ON DELETE CASCADE
GO
ALTER TABLE [Menus_Itens_Relatorios] CHECK CONSTRAINT [FK_Menus_Itens_Relatorios_Menus_Itens]
GO
ALTER TABLE [Modulos_Menus]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_Menus_Menu_Item] FOREIGN KEY([Menu_Item])
REFERENCES [Menus_Itens] ([Menu_Item])
GO
ALTER TABLE [Modulos_Menus] CHECK CONSTRAINT [FK_Modulos_Menus_Menu_Item]
GO
ALTER TABLE [Modulos_Menus]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_Menus_Modulo] FOREIGN KEY([Modulo])
REFERENCES [Modulos] ([Modulo])
GO
ALTER TABLE [Modulos_Menus] CHECK CONSTRAINT [FK_Modulos_Menus_Modulo]
GO
ALTER TABLE [Movimentos_Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Movimento_Estoque_Clientes] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Movimentos_Estoque] CHECK CONSTRAINT [FK_Movimento_Estoque_Clientes]
GO
ALTER TABLE [Movimentos_Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Movimento_Estoque_Tipos_Movimentos_Estoque] FOREIGN KEY([Tipo_Movimento_Estoque])
REFERENCES [Tipos_Movimentos_Estoque] ([Tipo_Movimento_Estoque])
GO
ALTER TABLE [Movimentos_Estoque] CHECK CONSTRAINT [FK_Movimento_Estoque_Tipos_Movimentos_Estoque]
GO
ALTER TABLE [Movimentos_Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Movimentos_Estoque_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Movimentos_Estoque] CHECK CONSTRAINT [FK_Movimentos_Estoque_Empresas]
GO
ALTER TABLE [Movimentos_Estoque_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Movimentos_Estoque_Itens_Movimento_Estoque] FOREIGN KEY([Movimento_Estoque])
REFERENCES [Movimentos_Estoque] ([Movimento_Estoque])
GO
ALTER TABLE [Movimentos_Estoque_Itens] CHECK CONSTRAINT [FK_Movimentos_Estoque_Itens_Movimento_Estoque]
GO
ALTER TABLE [Movimentos_Estoque_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Movimentos_Estoque_Itens_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Movimentos_Estoque_Itens] CHECK CONSTRAINT [FK_Movimentos_Estoque_Itens_Produtos]
GO
ALTER TABLE [Municipios]  WITH CHECK ADD  CONSTRAINT [FK_Municipios_Estados] FOREIGN KEY([Estado])
REFERENCES [Estados] ([Estado])
GO
ALTER TABLE [Municipios] CHECK CONSTRAINT [FK_Municipios_Estados]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_CFOPS] FOREIGN KEY([CFOP])
REFERENCES [CFOPS] ([CFOP])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_CFOPS]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Clientes] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Clientes]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Condicoes_Pagamento_Pedido] FOREIGN KEY([Condicao_Pagamento_Pedido])
REFERENCES [Condicoes_Pagamento_Pedido] ([Condicao_Pagamento_Pedido])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Condicoes_Pagamento_Pedido]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Empresas]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Pedidos] FOREIGN KEY([Pedido])
REFERENCES [Pedidos] ([Pedido])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Pedidos]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Tipos_Fretes] FOREIGN KEY([Tipo_Frete])
REFERENCES [Tipos_Fretes] ([Tipo_Frete])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Tipos_Fretes]
GO
ALTER TABLE [Notas_Fiscais]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Transportadoras] FOREIGN KEY([Transportadora])
REFERENCES [Transportadoras] ([Transportadora])
GO
ALTER TABLE [Notas_Fiscais] CHECK CONSTRAINT [FK_Notas_Fiscais_Transportadoras]
GO
ALTER TABLE [Notas_Fiscais_Duplicatas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Duplicatas_Notas_Fiscais] FOREIGN KEY([Nota_Fiscal])
REFERENCES [Notas_Fiscais] ([Nota_Fiscal])
GO
ALTER TABLE [Notas_Fiscais_Duplicatas] CHECK CONSTRAINT [FK_Notas_Fiscais_Duplicatas_Notas_Fiscais]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_CFOPS] FOREIGN KEY([CFOP])
REFERENCES [CFOPS] ([CFOP])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_CFOPS]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Classificacoes_Fiscais] FOREIGN KEY([Classificacao_Fiscal])
REFERENCES [Classificacoes_Fiscais] ([Classificacao_Fiscal])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Classificacoes_Fiscais]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_CSOSN] FOREIGN KEY([CSOSN])
REFERENCES [CSOSN] ([CSOSN])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_CSOSN]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Modalidades_Calculo_ICMS] FOREIGN KEY([Modalidade_Calculo_ICMS])
REFERENCES [Modalidades_Calculo_ICMS] ([Modalidade_Calculo_ICMS])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Modalidades_Calculo_ICMS]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Modalidades_Calculo_ICMS_ST] FOREIGN KEY([Modalidade_Calculo_ICMS_ST])
REFERENCES [Modalidades_Calculo_ICMS_ST] ([Modalidade_Calculo_ICMS_ST])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Modalidades_Calculo_ICMS_ST]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Notas_Fiscais] FOREIGN KEY([Nota_Fiscal])
REFERENCES [Notas_Fiscais] ([Nota_Fiscal])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Notas_Fiscais]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Produtos]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria] FOREIGN KEY([Situacao_Tributaria])
REFERENCES [Situacoes_Tributaria] ([Situacao_Tributaria])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria_COFINS] FOREIGN KEY([Situacao_Tributaria_COFINS])
REFERENCES [Situacoes_Tributaria_COFINS] ([Situacao_Tributaria_COFINS])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria_COFINS]
GO
ALTER TABLE [Notas_Fiscais_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria_PIS] FOREIGN KEY([Situacao_Tributaria_PIS])
REFERENCES [Situacoes_Tributaria_PIS] ([Situacao_Tributaria_PIS])
GO
ALTER TABLE [Notas_Fiscais_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Itens_Situacoes_Tributaria_PIS]
GO
ALTER TABLE [Notas_Fiscais_Lotes]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Ambientes_NFe] FOREIGN KEY([Ambiente_NFe])
REFERENCES [Ambientes_NFe] ([Ambiente_NFe])
GO
ALTER TABLE [Notas_Fiscais_Lotes] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Ambientes_NFe]
GO
ALTER TABLE [Notas_Fiscais_Lotes]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Notas_Fiscais_Lotes] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Empresas]
GO
ALTER TABLE [Notas_Fiscais_Lotes]  WITH NOCHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Retorno_NFe] FOREIGN KEY([Codigo_Mensagem_Retorno_NFe])
REFERENCES [Mensagens_Retorno_NFe] ([Codigo_Mensagem_Retorno])
GO
ALTER TABLE [Notas_Fiscais_Lotes] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Retorno_NFe]
GO
ALTER TABLE [Notas_Fiscais_Lotes]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Retorno_NFp] FOREIGN KEY([Codigo_Mensagem_Retorno_NFp])
REFERENCES [Mensagens_Retorno_NFp] ([Codigo_Mensagem_Retorno])
GO
ALTER TABLE [Notas_Fiscais_Lotes] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Retorno_NFp]
GO
ALTER TABLE [Notas_Fiscais_Lotes]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Tipos_Emissao_NFe] FOREIGN KEY([Tipo_Emissao_NFe])
REFERENCES [Tipos_Emissao_NFe] ([Tipo_Emissao_NFe])
GO
ALTER TABLE [Notas_Fiscais_Lotes] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Tipos_Emissao_NFe]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Contagens]  WITH CHECK ADD  CONSTRAINT [fk_Notas_Fiscais_Lotes_Contagens_001] FOREIGN KEY([Nota_Fiscal_Lote])
REFERENCES [Notas_Fiscais_Lotes] ([Nota_Fiscal_Lote])
GO
ALTER TABLE [Notas_Fiscais_Lotes_Contagens] CHECK CONSTRAINT [fk_Notas_Fiscais_Lotes_Contagens_001]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Itens_Notas_Fiscais] FOREIGN KEY([Nota_Fiscal])
REFERENCES [Notas_Fiscais] ([Nota_Fiscal])
GO
ALTER TABLE [Notas_Fiscais_Lotes_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Itens_Notas_Fiscais]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Itens_Notas_Fiscais_Lotes] FOREIGN KEY([Nota_Fiscal_Lote])
REFERENCES [Notas_Fiscais_Lotes] ([Nota_Fiscal_Lote])
GO
ALTER TABLE [Notas_Fiscais_Lotes_Itens] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Itens_Notas_Fiscais_Lotes]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Mensagens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Mensagens_Retorno_NFp] FOREIGN KEY([Codigo_Mensagem_Retorno_NFp])
REFERENCES [Mensagens_Retorno_NFp] ([Codigo_Mensagem_Retorno])
GO
ALTER TABLE [Notas_Fiscais_Lotes_Mensagens] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Mensagens_Retorno_NFp]
GO
ALTER TABLE [Notas_Fiscais_Lotes_Mensagens]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Notas_Fiscais_Lotes] FOREIGN KEY([Nota_Fiscal_Lote])
REFERENCES [Notas_Fiscais_Lotes] ([Nota_Fiscal_Lote])
GO
ALTER TABLE [Notas_Fiscais_Lotes_Mensagens] CHECK CONSTRAINT [FK_Notas_Fiscais_Lotes_Mensagens_Notas_Fiscais_Lotes]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Condicoes_Pagamento] FOREIGN KEY([Condicao_Pagamento_Pedido])
REFERENCES [Condicoes_Pagamento_Pedido] ([Condicao_Pagamento_Pedido])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Condicoes_Pagamento]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Empresas]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Tabelas_Precos] FOREIGN KEY([Tabela_Preco])
REFERENCES [Tabelas_Precos] ([Tabela_Preco])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Tabelas_Precos]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Transportadoras] FOREIGN KEY([Transportadora])
REFERENCES [Transportadoras] ([Transportadora])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Transportadoras]
GO
ALTER TABLE [Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Vendedores] FOREIGN KEY([Vendedor])
REFERENCES [Vendedores] ([Vendedor])
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [FK_Pedidos_Vendedores]
GO
ALTER TABLE [Pedidos_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Itens_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Pedidos_Itens] CHECK CONSTRAINT [FK_Pedidos_Itens_Produtos]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Categorias_Produtos] FOREIGN KEY([Categoria_Produto])
REFERENCES [Categorias_Produtos] ([Categoria_Produto])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_Categorias_Produtos]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Classificacoes_Fiscais] FOREIGN KEY([Classificacao_Fiscal])
REFERENCES [Classificacoes_Fiscais] ([Classificacao_Fiscal])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_Classificacoes_Fiscais]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Grupos_Produtos] FOREIGN KEY([Grupo_Produto])
REFERENCES [Grupos_Produtos] ([Grupo_Produto])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_Grupos_Produtos]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Origens_Produtos] FOREIGN KEY([Origem_Produto])
REFERENCES [Origens_Produtos] ([Origem_Produto])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_Origens_Produtos]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_SubGrupos_Produtos] FOREIGN KEY([SubGrupo_Produto])
REFERENCES [SubGrupos_Produtos] ([SubGrupo_Produto])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_SubGrupos_Produtos]
GO
ALTER TABLE [Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Unidades_Medidas] FOREIGN KEY([Unidade_Medida])
REFERENCES [Unidades_Medidas] ([Unidade_Medida])
GO
ALTER TABLE [Produtos] CHECK CONSTRAINT [FK_Produtos_Unidades_Medidas]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_CSOSN] FOREIGN KEY([CSOSN])
REFERENCES [CSOSN] ([CSOSN])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_CSOSN]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_CSOSN1] FOREIGN KEY([CSOSN_RPA])
REFERENCES [CSOSN] ([CSOSN])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_CSOSN1]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Empresas] FOREIGN KEY([Empresa])
REFERENCES [Empresas] ([Empresa])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Empresas]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Modalidades_Calculo_ICMS_ST] FOREIGN KEY([Modalidade_Calculo_ICMS_ST])
REFERENCES [Modalidades_Calculo_ICMS_ST] ([Modalidade_Calculo_ICMS_ST])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Modalidades_Calculo_ICMS_ST]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Modalides_Calculo_ICMS] FOREIGN KEY([Modalidade_Calculo_ICMS])
REFERENCES [Modalidades_Calculo_ICMS] ([Modalidade_Calculo_ICMS])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Modalides_Calculo_ICMS]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Produtos]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria] FOREIGN KEY([Situacao_Tributaria])
REFERENCES [Situacoes_Tributaria] ([Situacao_Tributaria])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria_COFINS] FOREIGN KEY([Situacao_Tributaria_COFINS])
REFERENCES [Situacoes_Tributaria_COFINS] ([Situacao_Tributaria_COFINS])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria_COFINS]
GO
ALTER TABLE [Produtos_Tributos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria_PIS] FOREIGN KEY([Situacao_Tributaria_PIS])
REFERENCES [Situacoes_Tributaria_PIS] ([Situacao_Tributaria_PIS])
GO
ALTER TABLE [Produtos_Tributos] CHECK CONSTRAINT [FK_Produtos_Tributos_Situacoes_Tributaria_PIS]
GO
ALTER TABLE [Produtos_Tributos_Mensagens]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Mensagens_Mensagens_Notas] FOREIGN KEY([Mensagem_Nota])
REFERENCES [Mensagens_Notas] ([Mensagem_Nota])
GO
ALTER TABLE [Produtos_Tributos_Mensagens] CHECK CONSTRAINT [FK_Produtos_Tributos_Mensagens_Mensagens_Notas]
GO
ALTER TABLE [Produtos_Tributos_Mensagens]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Tributos_Mensagens_Produtos_Tributos] FOREIGN KEY([Produto_Tributo])
REFERENCES [Produtos_Tributos] ([Produto_Tributo])
GO
ALTER TABLE [Produtos_Tributos_Mensagens] CHECK CONSTRAINT [FK_Produtos_Tributos_Mensagens_Produtos_Tributos]
GO
ALTER TABLE [Romaneios_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Romaneios_Itens_Clientes] FOREIGN KEY([Cliente])
REFERENCES [Clientes] ([Cliente])
GO
ALTER TABLE [Romaneios_Itens] CHECK CONSTRAINT [FK_Romaneios_Itens_Clientes]
GO
ALTER TABLE [Romaneios_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Romaneios_Itens_Pedidos] FOREIGN KEY([Pedido])
REFERENCES [Pedidos] ([Pedido])
GO
ALTER TABLE [Romaneios_Itens] CHECK CONSTRAINT [FK_Romaneios_Itens_Pedidos]
GO
ALTER TABLE [Romaneios_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Romaneios_Itens_Romaneios] FOREIGN KEY([Romaneio])
REFERENCES [Romaneios] ([Romaneio])
GO
ALTER TABLE [Romaneios_Itens] CHECK CONSTRAINT [FK_Romaneios_Itens_Romaneios]
GO
ALTER TABLE [Situacoes_Tributaria]  WITH CHECK ADD  CONSTRAINT [FK_situacoes_tributaria_Modalides_Calculo_ICMS] FOREIGN KEY([Modalidade_Calculo_ICMS])
REFERENCES [Modalidades_Calculo_ICMS] ([Modalidade_Calculo_ICMS])
GO
ALTER TABLE [Situacoes_Tributaria] CHECK CONSTRAINT [FK_situacoes_tributaria_Modalides_Calculo_ICMS]
GO
ALTER TABLE [SubGrupos_Produtos]  WITH CHECK ADD  CONSTRAINT [FK_SubGrupos_Produtos_Grupos_Produtos] FOREIGN KEY([Grupo_Produto])
REFERENCES [Grupos_Produtos] ([Grupo_Produto])
GO
ALTER TABLE [SubGrupos_Produtos] CHECK CONSTRAINT [FK_SubGrupos_Produtos_Grupos_Produtos]
GO
ALTER TABLE [Tabelas_Precos]  WITH CHECK ADD  CONSTRAINT [FK_Tabelas_Precos_Condicoes_Pagamento_Pedido] FOREIGN KEY([Condicao_Pagamento_Pedido])
REFERENCES [Condicoes_Pagamento_Pedido] ([Condicao_Pagamento_Pedido])
GO
ALTER TABLE [Tabelas_Precos] CHECK CONSTRAINT [FK_Tabelas_Precos_Condicoes_Pagamento_Pedido]
GO
ALTER TABLE [Tabelas_Precos_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Tabelas_Precos_Itens_Produtos] FOREIGN KEY([Produto])
REFERENCES [Produtos] ([Produto])
GO
ALTER TABLE [Tabelas_Precos_Itens] CHECK CONSTRAINT [FK_Tabelas_Precos_Itens_Produtos]
GO
ALTER TABLE [Tabelas_Precos_Itens]  WITH CHECK ADD  CONSTRAINT [FK_Tabelas_Precos_Itens_Tabelas_Precos] FOREIGN KEY([Tabela_Preco])
REFERENCES [Tabelas_Precos] ([Tabela_Preco])
GO
ALTER TABLE [Tabelas_Precos_Itens] CHECK CONSTRAINT [FK_Tabelas_Precos_Itens_Tabelas_Precos]
GO
ALTER TABLE [Transportadoras]  WITH CHECK ADD  CONSTRAINT [FK_Transportadoras_Tipos_Fretes] FOREIGN KEY([Tipo_Frete])
REFERENCES [Tipos_Fretes] ([Tipo_Frete])
GO
ALTER TABLE [Transportadoras] CHECK CONSTRAINT [FK_Transportadoras_Tipos_Fretes]
GO
ALTER TABLE [Usuarios_Acessos]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Acessos_Menus_itens] FOREIGN KEY([Menu_Item])
REFERENCES [Menus_Itens] ([Menu_Item])
GO
ALTER TABLE [Usuarios_Acessos] CHECK CONSTRAINT [FK_Usuarios_Acessos_Menus_itens]
GO
ALTER TABLE [Usuarios_Acessos]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Acessos_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [Usuarios] ([Usuario])
GO
ALTER TABLE [Usuarios_Acessos] CHECK CONSTRAINT [FK_Usuarios_Acessos_Usuarios]
GO
ALTER TABLE [Enderecos_WebService_NFe]  WITH CHECK ADD  CONSTRAINT [chk_ambiente] CHECK  (([Ambiente]=(2) OR [Ambiente]=(1)))
GO
ALTER TABLE [Enderecos_WebService_NFe] CHECK CONSTRAINT [chk_ambiente]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE trigger [TRG_Contador]
	on [Contadores]
	after update
as
if exists(select * from inserted where proximo_valor is null)
begin
	update contadores set proximo_valor = 1 where contador = (select contador from inserted)
end









GO
ALTER TABLE [dbo].[Contadores] ENABLE TRIGGER [TRG_Contador]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [TRG_Produtos_para_Empresa]
on [Empresas]
for insert
as
set nocount on

-- Verifica se o estoque ع por empresa ou geral.
Declare @Estoque_Por_Empresa varchar(10)
select @Estoque_por_Empresa = Valor from propriedades where nome_propriedade = 'Estoque_por_empresa'

if (@Estoque_por_empresa = 'true')
begin
	insert estoques
	select empresa
		, produto
		, 0
		, 0
		, 0
		from produtos 
			cross join inserted
end

set nocount off
GO
ALTER TABLE [dbo].[Empresas] ENABLE TRIGGER [TRG_Produtos_para_Empresa]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE Trigger [TRG_Atualiza_Total_Estoque]
on [Estoques]
for insert, update
as
set nocount on
update e set e.Quantidade_Total = (isnull(e.Quantidade_Disponivel, 0) + isnull(e.Quantidade_Reservada, 0))
	from Estoques e 
		inner join inserted i on i.estoque = e.estoque
set nocount off






GO
ALTER TABLE [dbo].[Estoques] ENABLE TRIGGER [TRG_Atualiza_Total_Estoque]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [Trg_InserirMensagensLotes]
	on [Notas_Fiscais_Lotes]
	for insert, update
as
if exists(select count(nota_fiscal_Lote) from inserted where tipo_nfe = 1)
begin
	insert notas_fiscais_lotes_mensagens(Nota_Fiscal_Lote, Tipo_Mensagem, Codigo_Mensagem_Retorno_NFe)
	select Nota_Fiscal_lote, 'Historico', Codigo_Mensagem_Retorno_NFe from inserted where tipo_nfe = 1
End
GO
ALTER TABLE [dbo].[Notas_Fiscais_Lotes] ENABLE TRIGGER [Trg_InserirMensagensLotes]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [TRG_Cria_Estoque_Zerado]
on [Produtos]
for insert
as
set nocount on

-- Verifica se o estoque é por empresa ou geral.
Declare @Estoque_Por_Empresa varchar(10)
select @Estoque_por_Empresa = Valor from propriedades where nome_propriedade = 'Estoque_por_empresa'

if (@Estoque_por_empresa = 'true')
begin
	insert estoques
	select empresa
		, produto
		, 0
		, 0
		, 0
		from empresas 
			cross join inserted
end

if (@Estoque_por_empresa = 'false')
begin
	insert estoques
	select null
		, produto
		, 0
		, 0
		, 0
		from
			inserted
end
set nocount off
GO
ALTER TABLE [dbo].[Produtos] ENABLE TRIGGER [TRG_Cria_Estoque_Zerado]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Produção - 2=Homologação' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enderecos_WebService_NFe', @level2type=N'CONSTRAINT',@level2name=N'chk_ambiente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "mi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mm"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 106
               Right = 380
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mo"
            Begin Extent = 
               Top = 108
               Left = 228
               Bottom = 223
               Right = 395
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ua"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Retornar_Modulos_Acessos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Retornar_Modulos_Acessos'
GO
USE [master]
GO
ALTER DATABASE NOME_BANCO_DE_DADOS SET  READ_WRITE 
GO
