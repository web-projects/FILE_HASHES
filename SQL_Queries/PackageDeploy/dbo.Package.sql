SELECT TOP (10) 
       [PackageID]
      ,[PackageTypeID]
      ,[Version]
      ,[DisplayName]
      ,[FileName]
      ,[FolderPath]
      ,[PackageDate]
      ,[HashValue]
      ,[Active]
      ,[CreatedDate]
      ,[CreatedBy]
  FROM [IPAv5PackageDeploy].[dbo].[Package]
  WHERE [FileName] like '%.idle.%'
  ORDER BY [PackageID] DESC

--- FOR DISTRIBUTION
SELECT TOP (1000) 
       [PackageID]
      ,[PackageTypeID]
      ,[Version]
      ,[DisplayName]
      ,[FileName]
      ,[FolderPath]
      ,[PackageDate]
      --,[ClientSourceFolderPath]
      --,[MinimumVersion]
      ,[HashValue]
      ,[InstallArguments]
      ,[Active]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
  FROM [IPAv5PackageDeploy].[dbo].[Package]
  --WHERE [FileName] like '%sphere.idle...%' AND [FileName] like '%p200%'
  --WHERE [FileName] like '%m400.%'
  --WHERE [FileName] like '%p400.%'
  --WHERE [FileName] like '%p200.%'
  WHERE [FileName] like '%.idle.%'
  ORDER BY [PackageID] DESC


--update [IPAv5PackageDeploy].[dbo].[Package] set HashValue=NULL WHERE PackageTypeID='3' AND PackageID='177'

--update [IPAv5PackageDeploy].[dbo].[Package] set PackageTypeID='3' WHERE PackageID='260'
--update [IPAv5PackageDeploy].[dbo].[Package] set MinimumVersion='1' WHERE PackageTypeID='3' AND PackageID='260'
--update [IPAv5PackageDeploy].[dbo].[Package] set FolderPath='DeploymentShare/Release Candidate/DevicePlatforms/Verifone/idleimage/' WHERE PackageID='260'
--update [IPAv5PackageDeploy].[dbo].[Package] set HashValue='41a2c47918902858' WHERE PackageID='260'

--update [IPAv5PackageDeploy].[dbo].[Package] set DisplayName='sphere.sphere.idle...199.p200.1.210823.tgz'  WHERE PackageID='260'
--update [IPAv5PackageDeploy].[dbo].[Package] set FileName='sphere.sphere.idle...199.p200.1.210823.tgz'  WHERE PackageID='260'
--update [IPAv5PackageDeploy].[dbo].[Package] set HashValue='b7cdf8b8b72f02d8' WHERE PackageID='260'


USE [IPAv5PackageDeploy]
GO
BEGIN TRAN
Declare @PackageTypeID int, @Version varchar(20), @DisplayName varchar(100), @FileName varchar(100), @FolderPath varchar(400), @PackageDate datetimeoffset(7), @MinimumVersion varchar(20), @HashValue varchar(128), @Active bit, @CreatedBy varchar(100)
Set @PackageTypeID=3
Set @Version='VIPA 6.8.2.X'
Set @DisplayName = 'sphere.sphere.idle...250.p200.2.230606.tgz'
Set @FileName = 'sphere.sphere.idle...250.p200.2.230606.tgz'
Set @FolderPath = 'DeploymentShare/Release Candidate/DevicePlatforms/Verifone/idleimage/'
Set @PackageDate = GETUTCDATE()
Set @MinimumVersion = '1'
Set @HashValue = 'ca5dced0a42e257f'
Set @Active=1
Set @CreatedBy='jon.bianco'

INSERT INTO [IPAv5PackageDeploy].[dbo].[Package]
		 ([PackageTypeID],[Version],[DisplayName],[FileName],[FolderPath],[PackageDate],[MinimumVersion],[HashValue],[Active],[CreatedDate],[CreatedBy],[UpdatedDate],[UpdatedBy])
     VALUES
           (@PackageTypeID, @Version, @DisplayName, @FileName,@FolderPath, @PackageDate, @MinimumVersion, @HashValue, @Active,GETUTCDATE(), @CreatedBy,GETUTCDATE(), @CreatedBy)
SELECT * FROM [Package] WHERE [FileName] = @FileName
		 ORDER BY [PackageID] DESC
GO
ROLLBACK TRAN
--COMMIT TRAN


DECLARE @HashThis NVARCHAR(32);  
SET @HashThis = CONVERT(NVARCHAR(32),'dslfdkjLK85kldhnv$n000#knf');  
SELECT HASHBYTES('SHA2_256', @HashThis);


DECLARE @HashThis16 NVARCHAR(32);  
SET @HashThis16 = CONVERT(NVARCHAR(16),'0123456789ABCDEF');  
SELECT HASHBYTES('MD5', @HashThis16);


DECLARE @HashThisValue NVARCHAR(32);  
SET @HashThisValue = CONVERT(NVARCHAR(16),'sphere.sphere.vipa.ux301.6_8_2_24.220210.tar');  
SELECT HASHBYTES('MD5', @HashThisValue);


-- compare 2 rows in the same table
SELECT COUNT(*) FROM (SELECT * FROM [IPAv5PackageDeploy].[dbo].[Package] WHERE PackageID=260 UNION SELECT * FROM [IPAv5PackageDeploy].[dbo].[Package] WHERE PackageID=153) a
