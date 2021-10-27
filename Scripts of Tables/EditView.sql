USE [5admaa]
GO

/****** Object:  View [dbo].[EditView]    Script Date: 10/28/2021 1:38:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[EditView]
AS
SELECT dbo.Person.Name AS الاسم, dbo.Person.NationalID AS [الرقم القومي], dbo.Person.SocialStatus AS [الحالة الاجتماعية], dbo.Person.Mobile AS [رقم التليفون], dbo.Person.Telephone AS [رقم التليفون الارضي], dbo.Person.Birthday AS [تاريخ الميلاد], dbo.Person.RecognitionFather AS [الاب الكاهن], 
             dbo.Khadma.Name AS [الاجتماع التابع له], dbo.Person.Khadem AS [الخادم المسؤال], dbo.Qualification.Name AS [المؤهل الدراسي], dbo.Education.Name AS [المرحلة التعليمية], dbo.Person.Job AS الوظيفة, dbo.City.Name AS المحافظة, dbo.Person.Address AS العنوان, dbo.Person.Salary AS الراتب, 
             dbo.Person.Total_Income AS [اجمالي الدخل], dbo.Person.Total_Cost AS [اجمالي المصروفات]
			 ,Image,BarCode
FROM   dbo.Person left JOIN
             dbo.Church ON dbo.Person.CurchID = dbo.Church.ID left JOIN
             dbo.City ON dbo.Person.CityID = dbo.City.ID left JOIN
             dbo.Education ON dbo.Person.EducationID = dbo.Education.ID left JOIN
             dbo.Khadma ON dbo.Person.KhadmaID = dbo.Khadma.ID left JOIN
             dbo.Qualification ON dbo.Person.QualificationID = dbo.Qualification.ID
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[53] 4[22] 2[21] 3) )"
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
         Begin Table = "Addresses"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Area"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 152
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Church"
            Begin Extent = 
               Top = 9
               Left = 615
               Bottom = 152
               Right = 837
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 9
               Left = 894
               Bottom = 152
               Right = 1116
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Education"
            Begin Extent = 
               Top = 9
               Left = 1173
               Bottom = 152
               Right = 1395
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Goverment"
            Begin Extent = 
               Top = 153
               Left = 336
               Bottom = 296
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Khadma"
            Begin Extent = 
               Top = 153
               Left = 615
               Bottom = 296
               Right = 837
            End
            DisplayFlags = 280
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EditView'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'          TopColumn = 0
         End
         Begin Table = "Login"
            Begin Extent = 
               Top = 153
               Left = 894
               Bottom = 323
               Right = 1116
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Person"
            Begin Extent = 
               Top = 153
               Left = 1173
               Bottom = 517
               Right = 1421
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "ProfileServices"
            Begin Extent = 
               Top = 207
               Left = 57
               Bottom = 404
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Qualification"
            Begin Extent = 
               Top = 297
               Left = 336
               Bottom = 440
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "service"
            Begin Extent = 
               Top = 297
               Left = 615
               Bottom = 467
               Right = 837
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServiceToken"
            Begin Extent = 
               Top = 324
               Left = 894
               Bottom = 521
               Right = 1116
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EditView'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EditView'
GO

