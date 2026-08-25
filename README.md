# revshells_for_me
I made this repo, for my own revshells cuz why not

If you use the ps revshells execute the byp.ps1 like this:

```
cat byp.ps1 | iconv -t UTF-16LE | base64 -w 0

powershell -EncodedCommand <base64output>
```