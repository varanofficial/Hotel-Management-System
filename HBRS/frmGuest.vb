﻿Imports System.Data.SqlClient

Public Class frmGuest
    Dim connectionString As String = "Data Source=PCNAMEHERE\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub bttnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnSave.Click
        con.Open()
        Dim fname As String = Trim(txtFName.Text)
        Dim mname As String = Trim(txtMName.Text)
        Dim lname As String = Trim(txtLName.Text)
        Dim add As String = Trim(txtAddress.Text)
        Dim num As String = Trim(txtNumber.Text)
        Dim email As String = Trim(txtEmail.Text)
        Dim stat As String = "Active"
        Dim remark As String = "Available"

        If fname = Nothing Or mname = Nothing Or lname = Nothing Or add = Nothing Or num = Nothing Then
            MsgBox("Please Fill All Fields", vbInformation, "Note")
        Else
            Dim add_guest As New SqlCommand("INSERT INTO tblGuest(GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,GuestGender,GuestEmail,Status,Remarks) values ('" &
                                              fname & "','" &
                                              mname & "','" &
                                              lname & "','" &
                                              add & "','" &
                                              num & "','" &
                                              cboGender.Text & "','" &
                                              email & "','" &
                                              stat & "','" &
                                              remark & "')", con)
            add_guest.ExecuteNonQuery()
            add_guest.Dispose()
            MsgBox("Guest Added!", vbInformation, "Note")
            txtFName.Clear()
            txtMName.Clear()
            txtLName.Clear()
            txtAddress.Clear()
            txtNumber.Clear()
            txtEmail.Clear()
        End If
        con.Close()
        display_guest()
    End Sub

    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_guest()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub display_guest()
        con.Open()
        Dim Dt As New DataTable("tblGuest")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblGuest", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvGuest.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("ID")
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestFName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestMName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestLName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestAddress"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestContactNumber"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Status"))
            lvGuest.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        txtFName.Clear()
        txtMName.Clear()
        txtLName.Clear()
        txtAddress.Clear()
        txtNumber.Clear()
        txtEmail.Clear()
    End Sub

    Private Sub txtFName_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class