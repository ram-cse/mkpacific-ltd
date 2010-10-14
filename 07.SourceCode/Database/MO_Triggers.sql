/*
 * Project: MONEY PACIFIC
 * 09-24-2010
 * 
/ */

use master
go
sp_configure 'clr enabled', 1
go
reconfigure
go


use MoneyPacific
Go

sp_configure 'clr enabled', 1
go
reconfigure
go


Drop TRIGGER trg_i_PacificCode

Drop ASSEMBLY MP_TRIGGER
Go

Create ASSEMBLY MP_TRIGGER
From 'C:\P12_MPTrigger.dll'
Go

Create TRIGGER trg_i_PacificCode
On PacificCode AFTER INSERT, UPDATE
AS
EXTERNAL NAME
MP_TRIGGER.[P12_MPTrigger.MPTrigger].KiemTraLuuTruKH
Go

Drop Procedure spGetParaPCode
Go

Create Procedure spGetParaPCode
AS
	Declare @Pid nvarchar
	select @Pid = [PacificCode].PacificCode from PacificCode
return @Pid
Go

/*
Declare @Pid nvarchar
Execute @Pid = spGetParaPCode
select @Pid
Go
/ */


--select PacificCode.PacificCode from PacificCode
--go
