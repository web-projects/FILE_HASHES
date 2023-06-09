SELECT TOP (500) 
       [PackageDeployID]
      ,[PackageDeployTypeID]
      ,[CompanyID]
      ,[PackageID]
      ,[AppId]
      ,[SerialNumber]
      ,[DeviceModel]
      ,[StatusCodeID]
      ,[Active]
      ,[StartDate]
      ,[EndDate]
      ,[PickedUpDate]
      ,[DeployedDate]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
      ,[DeployID]
  FROM [IPAv5PackageDeploy].[dbo].[PackageDeploy]
  ORDER BY PackageId DESC


SELECT TOP (1000) 
       [PackageDeployID]
      ,[PackageDeployTypeID]
      ,[CompanyID]
      ,[AppId]
      ,[PackageID]
      ,[StatusCodeID]
	   ,[StartDate]
      ,[EndDate]
      ,[Active]
      ,[DeployID]
      ,[SerialNumber]
      ,[DeviceModel]
FROM [IPAv5PackageDeploy].[dbo].[PackageDeploy]
--WHERE [AppId] = 64
WHERE [DeviceModel] like 'P200%'
ORDER BY [PackageDeployID] DESC

--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set StatusCodeID=0 where PackageDeployID=13
--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set AppId=64 where PackageDeployID=13
--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set AppId=160 where PackageDeployID=13

--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set StartDate='2021-01-01' where PackageDeployID=9
--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set EndDate='2041-01-01' where PackageDeployID=9
--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set StatusCodeID=0 where PackageDeployID=8
--update [IPAv5PackageDeploy].[dbo].[PackageDeploy] set UpdatedDate='' where PackageDeployID=9

USE [IPAv5PackageDeploy]
GO
BEGIN TRAN
Declare @PackageDeployId int, @PackageDeployTypeId int, @CompanyId int, @PackageId int, @StatusCodeID int, @Active bit
Declare @CreatedBy varchar(100), @UpdatedBy varchar(100), @DeployID int, @AppId int, @SerialNumber varchar(30), @DeviceModel varchar(20)
Set @PackageDeployTypeId=1
Set @CompanyId=199
Set @Active=1
Set @DeployID=4
Set @AppId=64
Set @CreatedBy='jon.bianco'
Set @UpdatedBy='jon.bianco'
Set @StatusCodeID=0
---
-- PackageDeployId: Next record in the table
Set @PackageDeployId=13
-- PackageId      : [IPAv5PackageDeploy].[dbo].[Package]
---
--m400 PackageId: 81=6.8.2.11, 82=6.8.2.17
--Set @PackageId=81
--Set @SerialNumber='401668973'
--Set @DeviceModel='M400WIFI/BT'
--
--p400 PackageId: 85=6.8.2.11, 86=6.8.2.17
--Set @PackageId=85
--Set @SerialNumber='275209472'
--Set @DeviceModel='P400Plus'
--
--p200 PackageId: 260=6.8.2.23
Set @PackageId=260
Set @SerialNumber='275437650'
Set @DeviceModel='P200Plus'
SET IDENTITY_INSERT [IPAv5PackageDeploy].[dbo].[PackageDeploy] ON
INSERT INTO [dbo].[PackageDeploy]
		   ([PackageDeployId], [PackageDeployTypeId], [CompanyId], [PackageId], 
		    [StartDate], [EndDate], [DeployedDate],
			[StatusCodeID], [Active],
		    [CreatedDate],[CreatedBy], [UpdatedBy],
		    [DeployID], [AppId], [SerialNumber], [DeviceModel])
     VALUES
		   (@PackageDeployId, @PackageDeployTypeId, @CompanyId, @PackageId, 
		   GETUTCDATE(), DATEADD(year, 20, GETUTCDATE()), NULL,
		   @StatusCodeID, @Active,
		   GETUTCDATE(), @CreatedBy, @UpdatedBy,
		   @DeployID, @AppId, @SerialNumber, @DeviceModel)
SELECT * FROM [PackageDeploy] WHERE [AppID] = @AppId
GO
SET IDENTITY_INSERT [IPAv5].[dbo].[Device] OFF
ROLLBACK TRAN
--COMMIT TRAN

