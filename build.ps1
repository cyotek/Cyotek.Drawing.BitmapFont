$path         = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$assemblyInfo = $path + "\src\Cyotek.Drawing.BitmapFont\Properties\AssemblyInfo.cs"
$nuspec       = $path + "\src\Cyotek.Drawing.BitmapFont\Cyotek.Drawing.BitmapFont.nuspec"
$id           = "Cyotek.Drawing.BitmapFont"
$version      = $null
$copyright    = $null
$title        = $null
$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding($False)

# first try and read the version and copyright from AssemblyInfo.cs
$lines = Get-Content $assemblyInfo

for ($i = 0; $i -lt $lines.length; $i++) 
{
    $line = $lines[$i];

    if($line -match ".*\[assembly: AssemblyInformationalVersion\(""(.*)""\)\].*")
    {
        $version = $Matches[1]
    }
    elseif($line -match ".*\[assembly: AssemblyCopyright\(""(.*)""\)\].*")
    {
        $copyright = $Matches[1]
    }
    elseif($line -match ".*\[assembly: AssemblyTitle\(""(.*)""\)\].*")
    {
        $title = $Matches[1]
    }
}

# next load and process the nuspec file
$lines = Get-Content $nuspec

for ($i = 0; $i -lt $lines.length; $i++) 
{
    $line = $lines[$i]

    $line = ($line -replace "(.*<id>)(.*)(</id>.*)", "`$1 $id `$3")
    $line = ($line -replace "(.*<version>)(.*)(</version>.*)", "`$1 $version `$3")
    $line = ($line -replace "(.*<title>)(.*)(</title>.*)", "`$1 $title `$3")
    $line = ($line -replace "(.*<copyright>)(.*)(</copyright>.*)", "`$1 $copyright `$3")

    $lines[$i] = $line
}

# Adds BOM :(
#Set-Content -Path $nuspec -Value $lines -Encoding UTF8
[System.IO.File]::WriteAllLines($nuspec, $lines, $Utf8NoBomEncoding)