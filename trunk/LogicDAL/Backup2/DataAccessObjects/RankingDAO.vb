Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Class RankingDAO : Implements IRankingDAO
    Const SQL_STATISTICS As String = _
        "select count(Ranking.listId) as rankCount, " & _
        "   sum(Ranking.rankNum) as rankTotal, " & _
        "   avg(Ranking.rankNum) as rankAverage " & _
        "from Ranking where Ranking.listId={0}"
    Const SQL_LIST_TITLE As String = _
        "select listName from artListing where artListing.listId={0}"
    Const SQL_INSERT As String = _
        "insert into ranking (listId, rankNum) values({0},{1})"
    Const SQL_DEL As String = _
        "delete from ranking where listId={0}"

    Private log As LogEntry

    Public Function getRankingStatisticsByListingId(ByVal ArtListingID As Long) As RankingStatistics Implements IRankingDAO.getRankingStatisticsByListingId
        Dim dr As IDataReader
        Dim listTitle As String
        Dim stats As New RankingStatistics()
        Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
        Try
            Dim sql As String = String.Format(SQL_STATISTICS, ArtListingID)
            Logger.Write(sql)
            dr = db.ExecuteReader(CommandType.Text, sql)
            Dim str As String = String.Format(SQL_LIST_TITLE, ArtListingID)
            listTitle = db.ExecuteScalar(CommandType.Text, str)
            While (dr.Read())
                stats.ListId = ArtListingID
                stats.ListName = listTitle
                stats.RankCount = dr("rankCount")
                stats.RankAverage = dr("rankAverage")
                stats.RankTotal = dr("rankTotal")

                Logger.Write(TraceEventType.Information, stats.ToString())
            End While
            dr.Close()
        Catch ex As Exception
            Logger.Write(TraceEventType.Critical, ex.Message)
            Throw New Exception("Error Getting Listing Rank", ex)
        End Try
        Return stats
    End Function

    Public Function addRanking(ByVal value As Ranking) As Boolean Implements IRankingDAO.addRanking
        'LoggerUtil.logMessage(TraceEventType.Information, "Calling addRanking")
        Try
            Dim sql As String = String.Format(SQL_INSERT, value.ArtListing, value.Ranking)
            'LoggerUtil.logMessage(TraceEventType.Information, sql)
            Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
            db.ExecuteNonQuery(CommandType.Text, sql)
            Return True
        Catch ex As Exception
            'LoggerUtil.logMessage(TraceEventType.Critical, ex.Message)
            Return False
        End Try
    End Function

    Public Function clearRanking(ByVal id As Long) As Boolean Implements IRankingDAO.clearRanking
        'LoggerUtil.logMessage(TraceEventType.Information, "Calling clearRanking")
        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ConstantsLibrary.LOCAL_ART_DB)
            db.ExecuteNonQuery(CommandType.Text, String.Format(SQL_DEL, id))
            Return True
        Catch ex As Exception
            'LoggerUtil.logMessage(TraceEventType.Critical, ex.Message)
            Return False
        End Try
    End Function
End Class
