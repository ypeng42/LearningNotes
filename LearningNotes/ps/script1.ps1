<#
.Synopsis
some text here

.Description
this is a description

.Parameter a
print something

.Example
example will only showed up if detailed flag is specified
#>
param(
    [Parameter(Mandatory=$true)]
    [string]$a
)

# this is a comment
echo $a 