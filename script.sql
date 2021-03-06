
/****** Object:  Table [dbo].[Stock_KPI]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock_KPI](
	[stockcode] [varchar](50) NOT NULL,
	[index] [int] NOT NULL,
	[date] [int] NOT NULL,
	[KPI] [varchar](50) NOT NULL,
	[value] [float] NOT NULL,
 CONSTRAINT [PK_Stock_Category] PRIMARY KEY CLUSTERED 
(
	[stockcode] ASC,
	[index] ASC,
	[date] ASC,
	[KPI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stock_Item]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Item](
	[code] [nvarchar](50) NOT NULL,
	[index] [int] NOT NULL,
	[date] [int] NOT NULL,
	[start] [float] NOT NULL,
	[high] [float] NOT NULL,
	[low] [float] NOT NULL,
	[end] [float] NOT NULL,
	[volume] [float] NOT NULL,
 CONSTRAINT [PK_Stock_Item_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC,
	[index] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_Header]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock_Header](
	[code] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastindex] [int] NOT NULL,
	[lastprice] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stock_Full]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock_Full](
	[code] [nvarchar](50) NOT NULL,
	[index] [int] NOT NULL,
	[date] [int] NOT NULL,
	[start] [float] NOT NULL,
	[high] [float] NOT NULL,
	[low] [float] NOT NULL,
	[end] [float] NOT NULL,
	[volume] [float] NOT NULL,
	[RIZE] [float] NULL,
	[AVE5] [float] NULL,
	[AVE10] [float] NULL,
	[AVE20] [float] NULL,
	[AVE30] [float] NULL,
	[AVE60] [float] NULL,
	[AVE_VOLUME10] [float] NULL,
	[AVE_VOLUME20] [float] NULL,
	[LOW10] [float] NULL,
	[LOW20] [float] NULL,
	[HIGH10] [float] NULL,
	[HIGH20] [float] NULL,
	[HIGH60] [float] NULL,
	[POST1] [float] NULL,
	[POST2] [float] NULL,
	[POST3] [float] NULL,
	[POST4] [float] NULL,
	[POST5] [float] NULL,
	[0_ABOVE_AVE_10] [float] NULL,
	[0_ABOVE_AVE_20] [float] NULL,
	[0_ABOVE_AVE_60] [float] NULL,
	[A10_ABOVE_20] [float] NULL,
	[A10_ABOVE_60] [float] NULL,
	[A20_ABOVE_60] [float] NULL,
	[IS_BIG_RIZE] [float] NULL,
	[IS_MEDIUM_RIZE] [float] NULL,
	[RIZE2] [float] NULL,
	[DEF_SELL_SHORT_index] [float] NULL,
	[DEF_SELL_SHORT_date] [float] NULL,
	[DEF_SELL_SHORT_price] [float] NULL,
	[DEF_SELL_MEDIUM_index] [float] NULL,
	[DEF_SELL_MEDIUM_date] [float] NULL,
	[DEF_SELL_MEDIUM_price] [float] NULL,
	[DEF_SELL_LONG_index] [float] NULL,
	[DEF_SELL_LONG_date] [float] NULL,
	[DEF_SELL_LONG_price] [float] NULL,
	[DEF_SELL_END_index] [float] NULL,
	[DEF_SELL_END_date] [float] NULL,
	[DEF_SELL_END_price] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock_DaPan]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock_DaPan](
	[seq] [bigint] NULL,
	[date] [int] NOT NULL,
	[rize] [float] NOT NULL,
	[NUM_RIZE] [int] NOT NULL,
	[NUM_DOWN] [int] NOT NULL,
	[ave1] [float] NOT NULL,
	[ave2] [float] NOT NULL,
	[ave3] [float] NOT NULL,
	[ave4] [float] NOT NULL,
	[ave5] [float] NOT NULL,
	[dapan] [varchar](23) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stock_Attribute]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock_Attribute](
	[stockcode] [varchar](50) NOT NULL,
	[index] [int] NOT NULL,
	[attribute] [varchar](50) NOT NULL,
	[value] [float] NULL,
 CONSTRAINT [PK_Stock_Attribute] PRIMARY KEY CLUSTERED 
(
	[stockcode] ASC,
	[index] ASC,
	[attribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Score]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Score](
	[rulename] [varchar](50) NOT NULL,
	[intdate] [int] NULL,
	[kpis] [varchar](50) NOT NULL,
	[grade] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Group]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Group](
	[id] [int] NOT NULL,
	[rulegroup] [int] NOT NULL,
	[ruletype] [int] NOT NULL,
	[rulename] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Rule_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[rulegroup] ASC,
	[ruletype] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Filter_DaPan]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Filter_DaPan](
	[rulename] [varchar](50) NOT NULL,
	[kpiname] [varchar](50) NOT NULL,
	[kpivalue] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Filter]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Filter](
	[rulename] [varchar](50) NOT NULL,
	[kpiname] [varchar](50) NOT NULL,
	[kpiindex] [int] NOT NULL,
	[kpivalue] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Buy0]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Buy0](
	[type] [varchar](2) NOT NULL,
	[id] [int] NOT NULL,
	[rulename] [varchar](50) NOT NULL,
	[stockcode] [varchar](50) NOT NULL,
	[date] [int] NOT NULL,
	[index] [int] NOT NULL,
	[price] [float] NOT NULL,
	[pregrade] [float] NOT NULL,
	[grade] [float] NOT NULL,
	[kpis] [varchar](50) NOT NULL,
	[num_kpis] [varchar](255) NOT NULL,
	[dapan] [varchar](50) NOT NULL,
	[next1] [float] NOT NULL,
	[next2] [float] NOT NULL,
	[next3] [float] NOT NULL,
	[next4] [float] NOT NULL,
	[post1] [float] NOT NULL,
	[post2] [float] NOT NULL,
	[post3] [float] NOT NULL,
	[post4] [float] NOT NULL,
	[post5] [float] NOT NULL,
 CONSTRAINT [PK_Rule_Buy0] PRIMARY KEY CLUSTERED 
(
	[type] ASC,
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rule_Buy]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule_Buy](
	[type] [varchar](2) NOT NULL,
	[id] [int] NOT NULL,
	[rulename] [varchar](50) NOT NULL,
	[stockcode] [varchar](50) NOT NULL,
	[date] [int] NOT NULL,
	[index] [int] NOT NULL,
	[price] [float] NOT NULL,
	[pregrade] [float] NOT NULL,
	[grade] [float] NOT NULL,
	[kpis] [varchar](50) NOT NULL,
	[num_kpis] [varchar](255) NOT NULL,
	[dapan] [varchar](50) NOT NULL,
	[next1] [float] NOT NULL,
	[next2] [float] NOT NULL,
	[next3] [float] NOT NULL,
	[next4] [float] NOT NULL,
	[post1] [float] NOT NULL,
	[post2] [float] NOT NULL,
	[post3] [float] NOT NULL,
	[post4] [float] NOT NULL,
	[post5] [float] NOT NULL,
 CONSTRAINT [PK_Rule_Buy] PRIMARY KEY CLUSTERED 
(
	[type] ASC,
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ope_Simulate_Item]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ope_Simulate_Item](
	[ID] [int] NOT NULL,
	[type] [int] NULL,
	[buyrule] [varchar](500) NULL,
	[sellrule] [varchar](500) NULL,
	[stockcode] [varchar](50) NULL,
	[buydate] [int] NULL,
	[buyindex] [int] NULL,
	[buyprice] [float] NULL,
	[selldate] [int] NULL,
	[sellindex] [int] NULL,
	[sellprice] [float] NULL,
	[buyvolume] [int] NULL,
	[stockvalue] [float] NULL,
	[winvalue] [float] NULL,
	[holdstocknum] [int] NULL,
	[totalstockvalue] [float] NULL,
	[leftmoney] [float] NULL,
	[totalamount] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ope_Simulate]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ope_Simulate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [int] NOT NULL,
	[startdate] [int] NOT NULL,
	[enddate] [int] NOT NULL,
	[buyrule] [varchar](255) NOT NULL,
	[sellrule] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Ope_Simulate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ope_Analysis2]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ope_Analysis2](
	[type] [int] NULL,
	[stockcode] [varchar](50) NULL,
	[buyrule] [varchar](50) NULL,
	[sellrule] [varchar](50) NULL,
	[buydate] [int] NULL,
	[buyindex] [int] NULL,
	[buyprice] [float] NULL,
	[grade] [float] NULL,
	[selldate] [int] NULL,
	[sellindex] [int] NULL,
	[sellprice] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ope_Analysis]    Script Date: 12/16/2019 18:18:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ope_Analysis](
	[type] [varchar](2) NOT NULL,
	[id] [int] NOT NULL,
	[rulename] [varchar](50) NOT NULL,
	[stockcode] [varchar](50) NOT NULL,
	[date] [int] NOT NULL,
	[index] [int] NOT NULL,
	[price] [float] NOT NULL,
	[pregrade] [float] NOT NULL,
	[grade] [float] NOT NULL,
	[kpis] [varchar](50) NOT NULL,
	[num_kpis] [varchar](255) NOT NULL,
	[dapan] [varchar](50) NOT NULL,
	[next1] [float] NOT NULL,
	[next2] [float] NOT NULL,
	[next3] [float] NOT NULL,
	[next4] [float] NOT NULL,
	[post1] [float] NOT NULL,
	[post2] [float] NOT NULL,
	[post3] [float] NOT NULL,
	[post4] [float] NOT NULL,
	[post5] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
