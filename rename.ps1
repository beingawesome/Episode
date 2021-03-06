﻿$original = 'Episode'
$root = (Get-Location).Path
$project = ([System.IO.FileInfo]$root).Name

function Update-FileContents([System.IO.FileInfo]$file) {
    (Get-Content $file.FullName) | Foreach-Object {$_ -replace $original,$project} | Out-File $file.FullName
}

function Rename-File([System.IO.FileInfo]$file) {
    $updated = $file.Name.Replace($original, $project)    
    if($file.Name -ne $updated) {
        Rename-Item $file.FullName $updated
    }
}

function Rename-Directory([System.IO.DirectoryInfo]$dir) {
    $updated = $dir.Name.Replace($original, $project)
      
    if($dir.Name -ne $updated) {
        Rename-Item $dir.FullName $updated
    }
}

function Update-FileSystemEntry([string]$path) {
    $current = Get-Item $path

    if($current -is [System.IO.FileInfo]) {
        Update-FileContents -file $current
        Rename-File -file $current
    } else {        
        Rename-Directory -dir $current
    }
}

Get-ChildItem -Recurse | Select-Object -ExpandProperty FullName | Sort-Object -Descending | ForEach-Object -Process {Update-FileSystemEntry -path $_}
