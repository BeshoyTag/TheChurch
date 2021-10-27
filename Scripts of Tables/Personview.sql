USE [5admaa]
GO

/****** Object:  View [dbo].[Personview]    Script Date: 10/28/2021 1:38:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Personview]
AS
SELECT dbo.Person.Name AS الأسم, CASE WHEN PersonType = 1 THEN N'اب' WHEN PersonType = 2 THEN N'ام' WHEN PersonType = 3 THEN N'اخ' ELSE N'اخت' END AS [الصفة], dbo.Person.BarCode AS [رقم البحث], NationalID AS N'الرقم القومي', dbo.Person.SocialStatus AS [الحالة الاجتماعية], 
              dbo.Person.Telephone AS [رقم التليفون],dbo.Person.Mobile AS [رقم التليفون الارضي], dbo.Person.Birthday AS [تاريخ الميلاد], dbo.Church.Name AS الكنيسة, dbo.Person.RecognitionFather AS [الاب الكاهن], dbo.Khadma.Name AS [الاجتماع التابع له], dbo.Person.Khadem AS [الخادم المسؤال], 
             dbo.Education.Name AS [المرحلة التعليميه], dbo.Qualification.Name AS [المؤهل الدراسي], dbo.Person.Job AS الوظيفة, dbo.Person.Address AS العنوان, dbo.City.Name AS المحافظة, dbo.Person.Salary AS الراتب, dbo.Person.Total_Income AS [اجمالي الدخل], 
             dbo.Person.Total_Cost AS [اجمالي المصروفات], dbo.Person.Email AS الايميل, dbo.Person.Notes AS ملاحظات
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personview'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personview'
GO

