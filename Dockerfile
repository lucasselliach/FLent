FROM mcr.microsoft.com/windows/servercore/iis
SHELL ["powershell", "-command"]
COPY dotnet-hosting-3.1.13-win.exe .
RUN Start-Process dotnet-hosting-3.1.13-win.exe \
-ArgumentList "/passive" -wait -Passthru; \
Remove-Item -Force dotnet-hosting-3.1.13-win.exe
RUN Remove-Item -Recurse C:\inetpub\wwwroot\*
COPY publish C:/inetpub/wwwroot