Module VBXpwn
    'VBXpwn v0.1 Beta
    'Written by Stan Hutcheon 2011
    'If there are extra files that i've not added, just let me know, or add them yourself and let me know anyway :D
    'If anything else is wrong or doesnt work, let me know also.
    'All content here was and has been written by Stan Hutcheon, if you use this code yourself, please give credit, its only fair :)
    '
    'Instructions:
    '-First configure VBXpwn by using VBXpwnSetup() with the required values:
    '--XpwnWorkingDirectory = "<directory that contains xpwn>"
    '--CurrentProgramHasGUI - Set to True if your program is using a graphical user interface. If your program is a conaole application, set to Falce
    '--RemoveEchoing - Set to True if you dont want VBXpwn to say whats happening.
    '--ListAllXpwnFiles (optional) - Set to true if you want VBXpwn to print a list of all the files that are used in this build
    '
    '-Second, VBXpwn will detect what files exist within your selected Xpwn directory and tell you what files may or may not be missing (only if RemoveEchoing is set to False).
    '
    'You are then free to use all the standard Xpwn commands. In VB if you just type 'xpwn' without quotes, you will get the whole list of commands.
    Public XpwnLocation As String
    Public ProgramHasGUI As Boolean
    Public RemoveStatusEchoing As Boolean
    Const quote As String = """"
    Private Property winstyle As ProcessWindowStyle

    Public bsdiff As Boolean = True
    Public bspatch As Boolean = True
    Public dmg As Boolean = True
    Public genpass As Boolean = True
    Public hdutil As Boolean = True
    Public hfsplus As Boolean = True
    Public imagetool As Boolean = True
    Public ipsw As Boolean = True
    Public itunespwn As Boolean = True
    Public xpwntool As Boolean = True
    Public libeay32 As Boolean = True
    Public libpng3 As Boolean = True
    Public zlib1 As Boolean = True

    Public Sub ShellWait(ByVal file As String, ByVal arg As String)
        Dim procNlite As New Process
        winstyle = 1
        procNlite.StartInfo.FileName = file
        procNlite.StartInfo.Arguments = " " & arg
        procNlite.StartInfo.WindowStyle = winstyle
        procNlite.Start()
        Do Until procNlite.HasExited

        Loop
        procNlite.WaitForExit()
    End Sub

    Sub VBXpwnSetup(ByVal XpwnWorkingDirectory As String, ByVal CurrentProgramHasGUI As Boolean, ByVal RemoveEchoing As Boolean, Optional ByVal ListAllXpwnFiles As Boolean = False)
        XpwnLocation = XpwnWorkingDirectory
        If CurrentProgramHasGUI = True Then
            ProgramHasGUI = True
        Else
            ProgramHasGUI = False
        End If
        If ListAllXpwnFiles = True Then
            If ProgramHasGUI = True Then
                MsgBox("All Xpwn Files:" + vbNewLine + "-bsdiff.exe" + vbNewLine + "-bspatch.exe" + vbNewLine + "-dmg.exe" + vbNewLine + "-genpass.exe" + vbNewLine + "-hdutil.exe" + vbNewLine + "-hfsplus.exe" + vbNewLine + "-imagetool.exe" + vbNewLine + "-ipsw.exe" + vbNewLine + "-itunespwn.exe" + vbNewLine + "-xpwntool.exe" + vbNewLine + "-libeay32.dll" + vbNewLine + "-libpng3.dll" + vbNewLine + "-zlib1.dll", MsgBoxStyle.Information, "All Xpwn Files")
            Else
                Console.WriteLine("All Xpwn Files:" + vbNewLine + "-bsdiff.exe" + vbNewLine + "-bspatch.exe" + vbNewLine + "-dmg.exe" + vbNewLine + "-genpass.exe" + vbNewLine + "-hdutil.exe" + vbNewLine + "-hfsplus.exe" + vbNewLine + "-imagetool.exe" + vbNewLine + "-ipsw.exe" + vbNewLine + "-itunespwn.exe" + vbNewLine + "-xpwntool.exe" + vbNewLine + "-libeay32.dll" + vbNewLine + "-libpng3.dll" + vbNewLine + "-zlib1.dll")
            End If
        End If
        If RemoveEchoing = True Then
            RemoveStatusEchoing = True
        End If
        CheckIfAllXpwnFilesExists()
    End Sub

    Sub CheckIfAllXpwnFilesExists()
        Dim NotExisting As String = "These files dont exist in your selected Xpwn directory:"
        Dim HasNotExistingBeenModified As Boolean = False
        Dim ConsoleAnswer As String
        If Not System.IO.File.Exists(XpwnLocation + "\bsdiff.exe") Then
            bsdiff = False
            NotExisting = NotExisting + vbNewLine + "-bsdiff.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\bspatch.exe") Then
            bspatch = False
            NotExisting = NotExisting + vbNewLine + "-bspatch.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\dmg.exe") Then
            dmg = False
            NotExisting = NotExisting + vbNewLine + "-dmg.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\genpass.exe") Then
            genpass = False
            NotExisting = NotExisting + vbNewLine + "-genpass.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\hdutil.exe") Then
            hdutil = False
            NotExisting = NotExisting + vbNewLine + "-hdutil.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\hfsplus.exe") Then
            hfsplus = False
            NotExisting = NotExisting + vbNewLine + "-hfsplus.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\imagetool.exe") Then
            imagetool = False
            NotExisting = NotExisting + vbNewLine + "-imagetool.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\ipsw.exe") Then
            ipsw = False
            NotExisting = NotExisting + vbNewLine + "-ipsw.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\itunespwn.exe") Then
            itunespwn = False
            NotExisting = NotExisting + vbNewLine + "-itunespwn.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\xpwntool.exe") Then
            xpwntool = False
            NotExisting = NotExisting + vbNewLine + "-xpwntool.exe"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\libeay32.dll") Then
            libeay32 = False
            NotExisting = NotExisting + vbNewLine + "-libeay32.dll"
            HasNotExistingBeenModified = True
        ElseIf Not System.IO.File.Exists(XpwnLocation + "\zlib1.dll") Then
            zlib1 = False
            NotExisting = NotExisting + vbNewLine + "-zlib1.dll"
            HasNotExistingBeenModified = True
        End If
        If HasNotExistingBeenModified = True Then
            If ProgramHasGUI = True Then
                NotExisting = NotExisting + vbNewLine + "some may be vital for xpwn to function, are you sure you want to continue?"
                If RemoveStatusEchoing = False Then
                    Dim answer = MsgBox(NotExisting, MsgBoxStyle.YesNo, "Some Xpwn files are missing...")
                    If answer = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            Else
                NotExisting = NotExisting + vbNewLine + "some may be vital for xpwn to function, are you sure you want to continue? y or n"
                If RemoveStatusEchoing = False Then
                    Do
                        Console.WriteLine(NotExisting)
                        ConsoleAnswer = Console.ReadLine()
                    Loop Until ConsoleAnswer = "y" Or ConsoleAnswer = "n"
                    If ConsoleAnswer = "n" Then
                        Console.WriteLine("aborting Xpwn setup...")
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub xpwn_bsdiff(ByVal oldfile As String, ByVal newfile As String, ByVal patchfile As String)
        If bsdiff = False Then
            Exit Sub
        End If
        ShellWait(XpwnLocation + "\bsdiff.exe", oldfile + " " + newfile + " " + patchfile)
    End Sub

    Public Sub xpwn_bspatch(ByVal oldfile As String, ByVal newfile As String, ByVal patchfile As String)
        If bspatch = False Then
            Exit Sub
        End If
        ShellWait(XpwnLocation + "\bspatch.exe", oldfile + " " + newfile + " " + patchfile)
    End Sub

    Public Sub xpwn_dmg(ByVal infile As String, ByVal outfile As String, ByVal key As String, ByVal partition As String, Optional ByVal extract As Boolean = False, Optional ByVal build As Boolean = False, Optional ByVal build2048 As Boolean = False, Optional ByVal res As Boolean = False, Optional ByVal iso As Boolean = False, Optional ByVal dmg As Boolean = False)
        If dmg = False Then
            Exit Sub
        End If
        Dim args As String = ""
        If extract = True Then
            args = args + " extract"
        ElseIf build = True Then
            args = args + " build"
        ElseIf build2048 = True Then
            args = args + " build2048"
        ElseIf res = True Then
            args = args + " res"
        ElseIf iso = True Then
            args = args + " iso"
        ElseIf dmg = True Then
            args = args + " dmg"
        End If
        args = args + " " + infile + " " + outfile + " -k " + key
        ShellWait(XpwnLocation + "\dmg.exe", args)
    End Sub

    Public Sub xpwn_genpass(ByVal platform As String, ByVal ramdisk_dmg As String, ByVal filesystem_dmg As String)
        If genpass = False Then
            Exit Sub
        End If
        ShellWait(XpwnLocation + "\genpass.exe", platform + " " + ramdisk_dmg + " " + filesystem_dmg)
    End Sub

    Public Sub xpwn_hfsplus(ByVal image_file As String, ByVal arguments As String, Optional ByVal ls As Boolean = False, Optional ByVal cat As Boolean = False, Optional ByVal mv As Boolean = False, Optional ByVal mkdir As Boolean = False, Optional ByVal add As Boolean = False, Optional ByVal rm As Boolean = False, Optional ByVal chmod As Boolean = False, Optional ByVal extract As Boolean = False, Optional ByVal extractall As Boolean = False, Optional ByVal rmall As Boolean = False, Optional ByVal addall As Boolean = False, Optional ByVal debug As Boolean = False, Optional ByVal symlink As Boolean = False, Optional ByVal getattr As Boolean = False, Optional ByVal grow As Boolean = False, Optional ByVal untar As Boolean = False)
        If hfsplus = False Then
            Exit Sub
        End If
        Dim args As String = " " + image_file
        If ls = True Then
            args = args + " ls"
        ElseIf cat = True Then
            args = args + " cat"
        ElseIf mv = True Then
            args = args + " mv"
        ElseIf mkdir = True Then
            args = args + " mkdir"
        ElseIf add = True Then
            args = args + " add"
        ElseIf rm = True Then
            args = args + " rm"
        ElseIf chmod = True Then
            args = args + " chmod"
        ElseIf extract = True Then
            args = args + " extract"
        ElseIf extractall = True Then
            args = args + " extractall"
        ElseIf rmall = True Then
            args = args + " rmall"
        ElseIf addall = True Then
            args = args + " addall"
        ElseIf debug = True Then
            args = args + " debug"
        ElseIf symlink = True Then
            args = args + " symlink"
        ElseIf getattr = True Then
            args = args + " getattr"
        ElseIf grow = True Then
            args = args + " grow"
        ElseIf untar = True Then
            args = args + " untar"
        End If
        args = args + " " + arguments
        ShellWait(XpwnLocation + "\hfsplus.exe", args)
    End Sub

    Public Sub xpwn_hdutil(ByVal image_file As String, ByVal key As String, ByVal arguments As String, Optional ByVal ls As Boolean = False, Optional ByVal cat As Boolean = False, Optional ByVal mv As Boolean = False, Optional ByVal mkdir As Boolean = False, Optional ByVal add As Boolean = False, Optional ByVal rm As Boolean = False, Optional ByVal chmod As Boolean = False, Optional ByVal extract As Boolean = False, Optional ByVal extractall As Boolean = False, Optional ByVal rmall As Boolean = False, Optional ByVal addall As Boolean = False, Optional ByVal grow As Boolean = False, Optional ByVal untar As Boolean = False)
        If hdutil = False Then
            Exit Sub
        End If
        Dim args As String = " " + image_file + " -k " + key
        If ls = True Then
            args = args + " ls"
        ElseIf cat = True Then
            args = args + " cat"
        ElseIf mv = True Then
            args = args + " mv"
        ElseIf mkdir = True Then
            args = args + " mkdir"
        ElseIf add = True Then
            args = args + " add"
        ElseIf rm = True Then
            args = args + " rm"
        ElseIf chmod = True Then
            args = args + " chmod"
        ElseIf extract = True Then
            args = args + " extract"
        ElseIf extractall = True Then
            args = args + " extractall"
        ElseIf rmall = True Then
            args = args + " rmall"
        ElseIf addall = True Then
            args = args + " addall"
        ElseIf grow = True Then
            args = args + " grow"
        ElseIf untar = True Then
            args = args + " untar"
        End If
        args = args + " " + arguments
        ShellWait(XpwnLocation + "\hfsplus.exe", args)
    End Sub

    Public Sub xpwn_imagetool(ByVal Extract_False__Inject_True As Boolean, Optional ByVal extract_sourceimg2or3 As String = "", Optional ByVal extract_destinationpng As String = "", Optional ByVal extract_iv As String = "", Optional ByVal extract_key As String = "", Optional ByVal inject_sourcepng As String = "", Optional ByVal inject_destinationimg2or3 As String = "", Optional ByVal inject_templateimg2or3 As String = "", Optional ByVal inject_iv As String = "", Optional ByVal inject_key As String = "")
        If imagetool = False Then
            Exit Sub
        End If
        Dim args As String = ""
        If Extract_False__Inject_True = False Then
            args = args + " extract " + extract_sourceimg2or3 + " " + extract_destinationpng + " " + extract_iv + " " + extract_key
        Else
            args = args + " inject " + inject_sourcepng + " " + inject_destinationimg2or3 + " " + inject_templateimg2or3 + " " + inject_iv + " " + inject_key
        End If
        ShellWait(XpwnLocation + "\imagetool.exe", args)
    End Sub
    Public Sub xpwn_ipsw(ByVal input_ipsw As String, ByVal output_ipsw As String, Optional ByVal bootimage As String = "", Optional ByVal recoveryimage As String = "", Optional ByVal systempartitionsize As String = "", Optional ByVal memory As Boolean = False, Optional ByVal bbupdate As Boolean = False, Optional ByVal nowipe As Boolean = False, Optional ByVal actiontoexclude As String = "", Optional ByVal unlock As Boolean = False, Optional ByVal use39 As Boolean = False, Optional ByVal use46 As Boolean = False, Optional ByVal cleanup As Boolean = False, Optional ByVal bootloader_3_9_file As String = "", Optional ByVal bootloader_4_6_file As String = "", Optional ByVal tars As String = "")
        If ipsw = False Then
            Exit Sub
        End If
        Dim args As String = " " + input_ipsw + " " + output_ipsw
        If Not bootimage = "" Then
            args = args + " -b " + bootimage
        ElseIf Not recoveryimage = "" Then
            args = args + " -r " + recoveryimage
        ElseIf Not systempartitionsize = "" Then
            args = args + " -s " + recoveryimage
        ElseIf memory = True Then
            args = args + " -memory"
        ElseIf bbupdate = True Then
            args = args + " -bbupdate"
        ElseIf nowipe = True Then
            args = args + " -nowipe"
        ElseIf Not actiontoexclude = "" Then
            args = args + " -e " + quote + actiontoexclude + quote
        ElseIf unlock = True Then
            args = args + " -unlock"
        ElseIf use39 = True Then
            args = args + " -use39"
        ElseIf use46 = True Then
            args = args + " -use46"
        ElseIf cleanup = True Then
            args = args + " -cleanup"
        ElseIf Not bootloader_3_9_file = "" Then
            args = args + " -3 " + bootloader_3_9_file
        ElseIf Not bootloader_4_6_file = "" Then
            args = args + " -4 " + bootloader_4_6_file
        ElseIf Not tars = "" Then
            args = args + " " + tars
        End If
        ShellWait(XpwnLocation + "\ipsw.exe", args)
    End Sub

    Public Sub xpwn_itunespwn(ByVal customipsw As String)
        If itunespwn = False Then
            Exit Sub
        End If
        ShellWait(XpwnLocation + "\itunespwn.exe", customipsw)
    End Sub

    Public Sub xpwn_xpwntool(ByVal infile As String, ByVal outfile As String, Optional ByVal x24k As Boolean = False, Optional ByVal xn8824k As Boolean = False, Optional ByVal template As String = "", Optional ByVal certificate As String = "", Optional ByVal key As String = "", Optional ByVal iv As String = "", Optional ByVal decrypt As Boolean = False)
        If xpwntool = False Then
            Exit Sub
        End If
        Dim args As String = " " + infile + " " + outfile
        If x24k = True Then
            args = args + " -x24k"
        ElseIf xn8824k = True Then
            args = args + " -xn8824k"
        ElseIf Not template = "" Then
            args = args + " -t " + template
        ElseIf Not certificate = "" Then
            args = args + " -c " + certificate
        ElseIf Not key = "" Then
            args = args + " -k " + key
        ElseIf Not iv = "" Then
            args = args + " -iv " + iv
        ElseIf decrypt = True Then
            args = args + " -decrypt"
        End If
        ShellWait(XpwnLocation + "\xpwntool.exe", args)
    End Sub
End Module
