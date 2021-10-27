USE [5admaa]
GO

/****** Object:  View [dbo].[InsertPersonview]    Script Date: 10/28/2021 1:38:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[InsertPersonview]
AS
SELECT dbo.Person.Name AS الأسم, dbo.Person.Birthday AS [تاريخ الميلاد], dbo.Person.Mobile AS [رقم التليفون], dbo.Person.Telephone AS [رقم التليفون الارضي], dbo.Person.BarCode AS [رقم البحث], dbo.Education.Name AS [المرحلة التعليميه], dbo.Qualification.Name AS [المؤهل الدراسي], 
             dbo.Person.Email AS الايميل, dbo.Person.RecognitionFather AS [الاب الكاهن], dbo.Khadma.Name AS [الاجتماع التابع له], dbo.Person.Khadem AS [الخادم المسؤال], dbo.Person.Gender AS ذكر, dbo.Person.SocialStatus AS [الحالة الاجتماعية], dbo.Person.Salary AS الراتب, 
             dbo.Person.Address AS العنوان, dbo.City.Name AS المحافظة, dbo.Person.Notes AS ملاحظات, dbo.Church.Name AS الكنيسة, dbo.Person.Job AS الوظيفة, dbo.Person.Image AS [مسار الصوره], dbo.Person.Total_Income AS [اجمالي الدخل], dbo.Person.Total_Cost AS [اجمالي المصروفات]
FROM   dbo.Khadma INNER JOIN
             dbo.Person ON dbo.Khadma.ID = dbo.Person.KhadmaID LEFT OUTER JOIN
             dbo.City ON dbo.Person.CityID = dbo.City.ID LEFT OUTER JOIN
             dbo.Church ON dbo.Person.CurchID = dbo.Church.ID LEFT OUTER JOIN
             dbo.Qualification ON dbo.Person.QualificationID = dbo.Qualification.ID LEFT OUTER JOIN
             dbo.Education ON dbo.Person.EducationID = dbo.Education.ID
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[30] 2[16] 3) )"
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
         Top = -672
         Left = -68
      End
      Begin Tables = 
         Begin Table = "Khadma"
            Begin Extent = 
               Top = 0
               Left = 130
               Bottom = 96
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Person"
            Begin Extent = 
               Top = 49
               Left = 38
               Bottom = 268
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 144
               Left = 465
               Bottom = 240
               Right = 635
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Church"
            Begin Extent = 
               Top = 108
               Left = 783
               Bottom = 204
               Right = 953
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Qualification"
            Begin Extent = 
               Top = 244
               Left = 432
               Bottom = 340
               Right = 602
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Education"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 102
               Right = 1040
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
         Column = 4380
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InsertPersonview'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Alias = 2090
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InsertPersonview'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InsertPersonview'
GO

