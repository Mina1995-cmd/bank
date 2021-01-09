Module connection
    Dim cn As New ADODB.Connection
    Dim r_branch, r_customer, r_transaction As New ADODB.Recordset

    Sub connect()
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\Admin\Documents\Data.mdb"
        cn.Open()
    End Sub

    Sub recordset()
        r_branch.Open("select * from Branch_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        r_customer.Open("select * from Customer_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        r_transaction.Open("select * from Transaction_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub
End Module

