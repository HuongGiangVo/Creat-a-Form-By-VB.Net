Imports System.IO
Public Class Form1
    Dim StudentList As New List(Of Student)
    Dim TeacherList As New List(Of Teacher)
    Dim SList1 As New List(Of Student)
    Dim SList2 As New List(Of Student)
    Dim TList1 As New List(Of Teacher)
    Dim TList2 As New List(Of Teacher)

    Friend Sub ReadStudent_Click(sender As Object, e As EventArgs) Handles ReadStudent.Click
        ' Open file.txt with the Using statement.
        Using r As StreamReader = New StreamReader("Student.txt")
            ' Store contents in this String.
            Dim line As String
            Dim tmp(4) As String
            ' Read first line.
            line = r.ReadLine
            Dim st As Student = New Student()
            Do Until r.EndOfStream
                line = r.ReadLine()
                tmp = line.Split(",")
                st.id = CInt(tmp(0))
                st.name = CStr(tmp(1))
                st.age = CInt(tmp(2))
                st.mark = CDbl(tmp(3))
                st.dept = CInt(tmp(4))
                StudentList.Add(st)
                If (st.dept = 1) Then
                    SList1.Add(st)

                Else
                    SList2.Add(st)

                End If
            Loop
            ShowTB.Text &= "The Student List is: " + vbNewLine
            For Each item As Student In StudentList
                ShowTB.Text &= item.ToString

            Next
            ShowTB.Text &= "------------------ " + vbNewLine
            ShowTB.Text &= "The Student List in DEPT 1 is: " + vbNewLine
            For Each item As Student In SList1
                ShowTB.Text &= item.ToString
            Next
            ShowTB.Text &= "------------------ " + vbNewLine
            ShowTB.Text &= "The Student List in DEPT 2 is: " + vbNewLine
            For Each item As Student In SList2
                ShowTB.Text &= item.ToString
            Next

        End Using


    End Sub


    Structure Student
        Dim id As Integer
        Dim name As String
        Dim age As Integer
        Dim mark As Double
        Dim dept As Integer


        Public Overrides Function ToString() As String
            Return id.ToString() + " : " + name + " : " + age.ToString() + " : " + mark.ToString() + " : " + dept.ToString() + vbNewLine
        End Function
    End Structure
    Structure Teacher
        Dim id As Integer
        Dim name As String
        Dim age As Integer
        Dim salary As Double
        Dim degree As String
        Dim dept As Integer


        Public Overrides Function ToString() As String
            Return id.ToString() + " : " + name + " : " + age.ToString() + " : " + salary.ToString() + " : " + degree + " : " + dept.ToString() + vbNewLine
        End Function
    End Structure

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ShowTB.Clear()
    End Sub

    Private Sub ReadTeacher_Click(sender As Object, e As EventArgs) Handles ReadTeacher.Click
        Using t As StreamReader = New StreamReader("Teacher.txt")

            ' Store contents in this String.
            Dim line As String
            Dim tmp(5) As String
            ' Read first line.
            line = t.ReadLine
            Dim te As Teacher = New Teacher()
            Do Until t.EndOfStream
                line = t.ReadLine()
                tmp = line.Split(",")

                te.id = CInt(tmp(0))
                te.name = CStr(tmp(1))
                te.age = CInt(tmp(2))
                te.salary = CDbl(tmp(3))
                te.degree = CStr(tmp(4))
                te.dept = CStr(tmp(5))
                TeacherList.Add(te)
                If (te.dept = 1) Then
                    TList1.Add(te)
                Else
                    TList2.Add(te)

                End If

            Loop
            ShowTB.Text &= "The Teacher List is: " + vbNewLine
            For Each item As Teacher In TeacherList
                ShowTB.Text &= item.ToString

            Next
            ShowTB.Text &= "------------------ " + vbNewLine
            ShowTB.Text &= "The Teacher List in DEPT 1 is: " + vbNewLine
            For Each item As Teacher In TList1
                ShowTB.Text &= item.ToString
            Next
            ShowTB.Text &= "------------------ " + vbNewLine
            ShowTB.Text &= "The Teacher List in DEPT 2 is: " + vbNewLine
            For Each item As Teacher In TList2
                ShowTB.Text &= item.ToString
            Next

        End Using
    End Sub

    Private Sub AddSBT_Click(sender As Object, e As EventArgs) Handles AddSBT.Click
        If (IsExistStudent()) Then
            MessageBox.Show("Student with id: " + IDSTB.Text + " is already exist!")
        Else
            Dim st As Student = New Student()
            st.id = CInt(IDSTB.Text)
            st.name = CStr(nameSTB.Text)
            st.age = CInt(AgeSTB.Text)
            st.mark = CDbl(MarkTB.Text)
            st.dept = CInt(DeptSTB.Text)
            'Insert new student
            If (st.dept = 1) Then
                SList1.Add(st)
            Else
                SList2.Add(st)
            End If

        End If

        For Each item As Student In SList1
            ShowTB.Text &= item.ToString
        Next
        For Each item As Student In SList2
            ShowTB.Text &= item.ToString
        Next
    End Sub

    Function IsExistStudent() As Boolean
        For Each st In StudentList
            If (CInt(IDSTB.Text) = st.id) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub AddTBT_Click(sender As Object, e As EventArgs) Handles AddTBT.Click
        If (IsExistTeacher()) Then
            MessageBox.Show("Teacher with id: " + IDTTB.Text + " is already exist!")
        Else
            Dim st As Teacher = New Teacher()
            st.id = CInt(IDTTB.Text)
            st.name = CStr(NameTTB.Text)
            st.age = CInt(AgeTTB.Text)
            st.salary = CDbl(SalaryTB.Text)
            st.degree = CStr(DeGTB.Text)
            st.dept = CInt(DeptTTB.Text)
            'Insert new Teacher
            If (st.dept = 1) Then
                TList1.Add(st)
            Else
                TList2.Add(st)
            End If

        End If

        For Each item As Teacher In TList1
            ShowTB.Text &= item.ToString
        Next
        For Each item As Teacher In TList2
            ShowTB.Text &= item.ToString
        Next
    End Sub
    Function IsExistTeacher() As Boolean
        For Each t In TeacherList
            If (CInt(IDTTB.Text) = t.id) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub SaveBT_Click(sender As Object, e As EventArgs) Handles SaveBT.Click
        Dim sTextFile As New System.Text.StringBuilder
        For Each tmp In ShowTB.Text
            sTextFile.AppendLine(tmp.ToString)
        Next
        Dim sFileName As String = "FileUpdated.txt"

        System.IO.File.AppendAllText(sFileName, sTextFile.ToString)
        MsgBox("File is saved")
    End Sub

    Private Sub QuitBT_Click(sender As Object, e As EventArgs) Handles QuitBT.Click
        Me.Close()
    End Sub
End Class
