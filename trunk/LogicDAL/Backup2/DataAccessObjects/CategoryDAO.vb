Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Imports System.Data.Common

Public Class CategoryDAO

    Public Shared Function GetAllCategories() As List(Of ICategory)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.ALL_CATEGORIES
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim categories As New List(Of ICategory)
        Dim category As ICategory

        Try
            While dr.Read()
                category = New Category(dr("catID"))
                category.Code = Utilities.GetFieldValue(dr("CategoryCD"))
                category.Description = Utilities.GetFieldValue(dr("CategoryDescription"))

                If dr("CatParentID") IsNot DBNull.Value Then
                    category.ParentCategory = GetCategoryByID(dr("CatParentID"))
                End If

                categories.Add(category)
            End While
        Catch ex As Exception
            Logger.Write("An error occurred trying to retreive category in position " & _
                         categories.Count & ". Exception: " & ex.Message)
            Throw New Exception("An error occurred trying to retreive categories. ", ex)
        Finally
            dr.Close()
            dr = Nothing
            db = Nothing
            cmd = Nothing
        End Try

        Return categories
    End Function

    Public Shared Function GetCategoryByID(ByVal id As Integer) As ICategory
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.GET_CATEGORY_BY_ID(id)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim category As ICategory = Nothing

        Try
            dr.Read()
            category = New Category(dr("catID"))
            category.Code = Utilities.GetFieldValue(dr("CategoryCD"))
            category.Description = Utilities.GetFieldValue(dr("CategoryDescription"))

            If dr("CatParentID") IsNot DBNull.Value Then
                category.ParentCategory = GetCategoryByID(dr("CatParentID"))
            End If

        Catch ex As Exception
            Logger.Write("An error occured while retreiving the category: " & ex.Message)
            Throw New Exception("An error occurred finding category with PK: " & id, ex)
        Finally
            dr.Close()
            db = Nothing
            cmd = Nothing
            dr = Nothing
        End Try

        Return category
    End Function

    Public Shared Sub DeleteCategory(ByVal category As ICategory)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.DELETE_CATEGORY(category.PrimaryKey)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Dim rowsAffected As Integer

        Try
            rowsAffected = db.ExecuteNonQuery(cmd)
        Catch ex As Exception
            Logger.Write("An error occurred deleting category: " & ex.Message)
            Throw New DeleteException("Could not delete category with PK: " & category.PrimaryKey, ex)
        Finally
            db = Nothing
            cmd = Nothing
        End Try

        Logger.Write("Deleted category with title: " & category.Description & _
                        rowsAffected & " rows were affected.")
    End Sub

    Public Shared Sub CreateCategory(ByVal category As ICategory)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.CREATE_CATEGORY(category)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            Dim rowsAffected As Integer = db.ExecuteNonQuery(cmd)
        Catch ex As Exception
            Throw New Exception("Error occurred during creation of new category.", ex)
        Finally
            db = Nothing
            cmd = Nothing
        End Try
    End Sub

    Public Shared Function ListParentCategories() As List(Of ICategory)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.ALL_PARENT_CATEGORIES
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim parentCategories As New List(Of ICategory)
        Dim category As ICategory = Nothing
        Try
            While dr.Read()
                category = New Category(dr("CatID"))
                category.Code = Utilities.GetFieldValue(dr("CategoryCD"))
                category.Description = Utilities.GetFieldValue(dr("CategoryDescription"))

                parentCategories.Add(category)

            End While
        Catch ex As Exception
            Throw New Exception("Problem retrieving all Parent Categories.", ex)
        Finally
            dr.Close()
            db = Nothing
            cmd = Nothing
            dr = Nothing
        End Try

        Return parentCategories
    End Function

    Public Shared Function GetCategoriesByParentID(ByVal id As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.CATEGORIES_BY_PARENT_ID(id)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)
        Dim dr As IDataReader = db.ExecuteReader(cmd)

        Dim parentCategories As New List(Of ICategory)
        Dim category As ICategory = Nothing
        Try
            While dr.Read()
                category = New Category(dr("CatID"))
                category.Code = Utilities.GetFieldValue(dr("CategoryCD"))
                category.Description = Utilities.GetFieldValue(dr("CategoryDescription"))

                parentCategories.Add(category)

            End While
        Catch ex As Exception
            Throw New Exception("Problem retrieving all Parent Categories.", ex)
        Finally
            dr.Close()
            db = Nothing
            cmd = Nothing
            dr = Nothing
        End Try

        Return parentCategories
    End Function

    Public Shared Sub UpdateCategory(ByVal category As ICategory)
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Dim sql As String = ConstantsLibrary.SQL_UPDATE_CATEGORY(category)
        Dim cmd As DbCommand = db.GetSqlStringCommand(sql)

        Try
            db.ExecuteNonQuery(cmd)
        Catch ex As Exception
            Throw New Exception("error updating category with PK: " & category.PrimaryKey, ex)
        Finally
            db = Nothing
            cmd = Nothing
        End Try
    End Sub
End Class
